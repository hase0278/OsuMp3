﻿using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Linq;

namespace OsuMp3
{
    public partial class Form1 : Form
    {
        #region member variables
        private readonly WindowsMediaPlayer player = new WindowsMediaPlayer();
        private static string path;
        private bool isFound = false;
        private readonly Timer timer = new Timer();
        private readonly Timer playNext = new Timer();
        private string playpause = "play";
        private Dictionary<string, string> playListSongs = new Dictionary<string, string>();

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        #endregion
        #region constructor
        public Form1()
        {
            try
            {
                path = File.ReadAllText(@"path.conf");
            }
            catch(FileNotFoundException)
            {
                path = @"C:\osu!\Songs";
                File.Create(@"path.conf").Close();
                File.WriteAllText(@"path.conf", path);
            }
            playNext.Tick += PlayNextEvent;
            timer.Tick += TimerEventProcessor;
            player.PlayStateChange += PlayStateChanged;
            InitializeComponent();
        }
        #endregion
        #region events
        private void Form1_Shown(object sender, EventArgs e)
        {
            loadPlaylist();

            pathBox.Text = path;
        }
        private void Play_Click(object sender, EventArgs e)
        {
            if(playpause == "play")
            {
                player.controls.play();
            }
            else if (playpause == "pause")
            {
                player.controls.pause();
            }
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }
        private void NowPlaying_TextChanged(object sender, EventArgs e)
        {
            albumPicture.Image.Dispose();
            if (playListSongs[nowPlaying.Text] == "No Pic")
            {
                albumPicture.Image = Properties.Resources.circles;
            }
            else
            {
                albumPicture.Image = new Bitmap(@playListSongs[nowPlaying.Text]);
            }
            player.URL = nowPlaying.Text;       
            player.controls.stop();
        }
        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                nowPlaying.SelectedIndex += 1;
                playNext.Start();
            }
            catch (ArgumentOutOfRangeException)
            {
                nowPlaying.SelectedIndex = 0;
                playNext.Start();
            }
        }
        private void Previous_Click(object sender, EventArgs e)
        {
            if (nowPlaying.SelectedIndex != 0)
            {
                nowPlaying.SelectedIndex -= 1;
                playNext.Start();
            }
            else
            {
                nowPlaying.SelectedIndex = nowPlaying.Items.Count - 1;
                playNext.Start();
            }
        }
        private void Browse_Click(object sender, EventArgs e)
        {
            ok.Visible = true;

            pathBox.Text = OpenFileDiag("Select osu songs folder:");
            
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            if (path != pathBox.Text)
            {
                File.WriteAllText(@"path.conf", pathBox.Text);
                path = pathBox.Text;
            }

            FolderSetVisible(false);
            ok.Visible = false;

            SetControlActivity(false);
            Form1_Shown(this, null);
        }
        private void FindBtn_Click(object sender, EventArgs e)
        {
            isFound = false;
            SearchResult.Items.Clear();
            SearchResult.Visible = false;
            for (int x = 0; x < nowPlaying.Items.Count; x++)
            {
                if (nowPlaying.GetItemText(nowPlaying.Items[x]).ToLower().Contains(search.Text.Trim(".mp3".ToCharArray()).ToLower()))
                {
                    SearchResult.Visible = true;
                    isFound = true;
                    SearchResult.Items.Add(nowPlaying.Items[x].ToString());
                }
                else
                {
                    if(x == (nowPlaying.Items.Count - 1) && !isFound)
                    {
                        isFound = false;
                    }
                    continue;
                }
            }

            if (!isFound)
            {
                MessageBox.Show("Music Not Found!", "Osu Music");
            }
        }
        private void PlayStateChanged(int newState)
        {
            switch (newState)
            {
                case 2:    // Paused
                    play.BackgroundImage.Dispose();
                    play.BackgroundImage = Properties.Resources.play;
                    playpause = "play";
                    break;
                case 3:    // Playing
                    play.BackgroundImage.Dispose();
                    timeLeft.Maximum = Convert.ToInt32(Math.Floor(player.currentMedia.duration));
                    play.BackgroundImage = Properties.Resources.pause;
                    playpause = "pause";
                    timer.Interval = 1000;
                    timer.Start();
                    break;
                case 8:    // MediaEnded
                    play.BackgroundImage.Dispose();
                    play.BackgroundImage = Properties.Resources.play;
                    playpause = "play";
                    next.PerformClick();
                    playNext.Start();
                    break;
                default:
                    play.BackgroundImage.Dispose();
                    play.BackgroundImage = Properties.Resources.play;
                    timeLeft.Value = 0;
                    playpause = "play";
                    break;
            }
        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            timeLeft.Value = (int)Math.Floor(player.controls.currentPosition);
            currentPosition.Text = TimeSpan.FromMinutes((int)Math.Floor(player.controls.currentPosition)).ToString("hh':'mm");
        }
        private void PlayNextEvent(object sender, EventArgs e)
        {
            player.controls.play();
            playNext.Stop();
        }
        private void TimeLeft_Scroll(object sender, EventArgs e)
        {
            player.controls.currentPosition = timeLeft.Value;
            timeLeft.Value = (int)Math.Floor(player.controls.currentPosition);
            currentPosition.Text = TimeSpan.FromMinutes((int)Math.Floor(player.controls.currentPosition)).ToString("hh':'mm");
        }
        private void SetOsuSongsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderSetVisible(true);
        }
        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchVisible(true);
        }
        private void ExtractPlayingMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractFile(nowPlaying.Text, Path.GetFileName(Path.GetDirectoryName(nowPlaying.Text).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ')), ".mp3");
        }
        private void ExtractAllMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savepath = @OpenFileDiag("Select Your File Save Destination: ");
            int success = 0, error = 0;
            for (int x = 0; x < nowPlaying.Items.Count; x++)
            {
                if(savepath == path)
                {
                    break;
                }else if(x == 0 && savepath != path)
                {
                    backgroundCopy.Visible = true;
                    MessageBox.Show("Files Copying on Background. Please wait.", "Osu Music");
                }
                Application.DoEvents();
                backgroundCopy.Text = "Files copying on background... \r\n" + (x+1) + " out of " + nowPlaying.Items.Count + " copied \r\n"+error+" failed"; ;
                try
                {
                    if(File.Exists(@savepath + @"\" + Path.GetFileName(Path.GetDirectoryName(nowPlaying.Items[x].ToString()).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ')) + ".mp3"))
                    {
                        File.Copy(@nowPlaying.Items[x].ToString(), @savepath + @"\" + Path.GetFileName(Path.GetDirectoryName(nowPlaying.Items[x].ToString()).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ')) + "_"+ x +".mp3", false);
                    }
                    else
                    {
                        File.Copy(@nowPlaying.Items[x].ToString(), @savepath + @"\" + Path.GetFileName(Path.GetDirectoryName(nowPlaying.Items[x].ToString()).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ')) + ".mp3", false);
                    }
                    success++;
                }
                catch (Exception)
                {
                    error++;
                }

                if (x == nowPlaying.Items.Count - 1)
                {
                    MessageBox.Show("Sucessfully copied " + success + " files. Error occured when copying " + error + " files.", "Osu Music");
                }
            }
            backgroundCopy.Visible = false;
        }
        private void SearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SearchResult.Text.Trim(' ') == "")
            {

            }
            else
            {
                SearchVisible(false);
                search.Text = "";
                nowPlaying.SelectedIndex = nowPlaying.Items.IndexOf(SearchResult.Text);
                SearchResult.Items.Clear();
                SearchResult.Visible = false;
            }
        }
        private void Volume_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = volume.Value;
        }
        private void SetAlbumPictureAsWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!playListSongs[nowPlaying.Text].Equals("No Pic"))
            {
                setAsWallpaper(playListSongs[nowPlaying.Text]);
            }
            else
            {
                Bitmap img = new Bitmap(Properties.Resources.circles);
                img.Save(@Application.StartupPath + @"\album.jpg");
                setAsWallpaper(@Application.StartupPath+@"\album.jpg");
                File.Delete(@Application.StartupPath + @"\album.jpg");
            }
            
        }
        #endregion
        #region methods
        private void loadPlaylist()
        {
            label1.Text = "Loading Audio Files. Please wait.";
            SetControlActivity(false);
            playListSongs.Clear();
            nowPlaying.Items.Clear();
            try
            {
                string line, file, song = " ", pic = " ";
                foreach (string osuFilePath in Directory.EnumerateFiles(path, "*.osu", SearchOption.AllDirectories))
                {
                    Application.DoEvents();
                    try
                    {
                        using (StreamReader sr = new StreamReader(osuFilePath))
                        {
                            bool hasPic = false;

                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains("AudioFilename: "))
                                {
                                    if ((file = Path.GetDirectoryName(osuFilePath) + @"\" + line.Split(new char[] { ' ' }, 2)[1]).Equals(song) || !line.Contains(".mp3"))
                                    {
                                        hasPic = true;
                                        break;
                                    }
                                    else
                                    {
                                        song = file;
                                    }
                                }
                                else if (line.Contains("0,0,") && (line.Contains(".jpg") || line.Contains(".png") || line.Contains(".jpeg")))
                                {
                                    pic = Path.GetDirectoryName(osuFilePath) + @"\" + line.Split(new char[] { '"' }, 3)[1].TrimStart(' ');
                                    hasPic = true;
                                    break;
                                }
                                else if (line.Equals("@//Break Periods"))
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (!hasPic)
                            {
                                playListSongs.Add(song, "No Pic");
                            }
                            else
                            {
                                if (!playListSongs.ContainsKey(song))
                                {
                                    playListSongs.Add(song, pic);
                                }
                                hasPic = false;
                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        continue;
                    }
                }
                nowPlaying.Items.AddRange(playListSongs.Keys.ToArray());
                SetControlActivity(true);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found! Select OSU Songs Directory", "Osu Music");
                Browse_Click(this, null);
                Ok_Click(this, null);
            }

            try
            {
                nowPlaying.SelectedIndex = 0;
                label1.Text = "Now Playing : Default Playlist";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No MP3 file found on directory! Select OSU Songs Directory", "Osu Music");
                Browse_Click(this, null);
                Ok_Click(this, null);
            }
        }
        private void SetControlActivity(bool state)
        {
            play.Enabled = state;
            stop.Enabled = state;
            next.Enabled = state;
            stop.Enabled = state;
        }
        private string OpenFileDiag(string Description)
        {
            using (FolderBrowserDialog openFile = new FolderBrowserDialog())
            {
                openFile.Description = Description;
                openFile.SelectedPath = path;
                openFile.ShowDialog();

                return openFile.SelectedPath;
            }
        }
        private void FolderSetVisible(bool visibility)
        {
            pathlbl.Visible = visibility;
            pathBox.Visible = visibility;
            browse.Visible = visibility;
        }
        private void SearchVisible(bool visibility)
        {
            searchlbl.Visible = visibility;
            search.Visible = visibility;
            findBtn.Visible = visibility;
        }
        private void ExtractFile(string sourceFileName, string destinationFileName, string extensionWithDot)
        {
            string savepath = @OpenFileDiag("Select Your File Save Destination: ");
            try
            {
                File.Copy(sourceFileName, savepath + @"\" + destinationFileName + extensionWithDot);
                MessageBox.Show(extensionWithDot.TrimStart('.') + " file extracted. Saved to: " + savepath, "Osu Music");
            }
            catch (IOException)
            {
                MessageBox.Show("File copy error! Either file exist or another path related error.", "Osu Music");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("System denied permission to copy file on selected directory. Please select another directory.", "Osu Music");
            }
        }
        private void ExtractAlbumPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playListSongs[nowPlaying.Text].Equals("No Pic"))
            {
                string savePath = OpenFileDiag("Select Your File Save Destination: ");
                Properties.Resources.circles.Save(savePath + @"\" + "nekodex - circles.jpg");
                MessageBox.Show("jpg file extracted. Saved to: " + savePath, "Osu Music");
            }
            else
            {
                ExtractFile(playListSongs[nowPlaying.Text], Path.GetFileName(Path.GetDirectoryName(playListSongs[nowPlaying.Text]).TrimStart(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ')), Path.GetExtension(playListSongs[nowPlaying.Text]));
            }
        }
        private void setAsWallpaper(string imgPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            key.SetValue(@"WallpaperStyle", 2.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
            key.Close();

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, @imgPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            MessageBox.Show("Wallpaper set to " + @imgPath + ".", "Osu Music");

        }
        #endregion
    }
}