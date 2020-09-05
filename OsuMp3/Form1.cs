using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace OsuMp3
{
    public partial class songsCheckList : Form
    {
        #region member variables
        private readonly WindowsMediaPlayer player = new WindowsMediaPlayer();
        private ToolStripMenuItem addMultipleToPlaylist = new ToolStripMenuItem("Add songs to current playlist");
        private ToolStripMenuItem deleteMultipleSongToPlaylist = new ToolStripMenuItem("Delete songs from current playlist");
        private ToolStripMenuItem deleteFromPlaylist = new ToolStripMenuItem("Delete song from playlist");
        private static string path;
        private bool isFound = false;
        private readonly Timer timer = new Timer();
        private readonly Timer playNext = new Timer();
        private string playpause = "play";
        private List<string> addMultipleSong = new List<string>();
        private Dictionary<string, string> playListSongs = new Dictionary<string, string>();

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        #endregion
        #region constructor
        public songsCheckList()
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
            deleteFromPlaylist.Click += deleteToolStripClicked;
            addMultipleToPlaylist.Click += AddMultipleSongsToolStripClicked;
            deleteMultipleSongToPlaylist.Click += DeleteMultipleSongsToolStripClicked;
            InitializeComponent();
        }
        #endregion
        #region events
        #region normal events
        private void Form1_Shown(object sender, EventArgs e)
        {
            loadExistingPlaylist();
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
        #region playlistToolStripEvents
        private void createPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePlaylist createPlaylistWindow = new CreatePlaylist();
            createPlaylistWindow.FormClosing += new FormClosingEventHandler(CreatePlaylist_Closing);
            createPlaylistWindow.ShowDialog(this);
        }
        private void CreatePlaylist_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loadExistingPlaylist();
        }
        private void loadToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Equals("Default"))
            {
                loadPlaylist();
            }
            else
            {
                loadPlaylist(e.ClickedItem.Text);
                playlistToolStripMenuItem.DropDownItems.Add(deleteFromPlaylist);
                playlistToolStripMenuItem.DropDownItems.Add(addMultipleToPlaylist);
                playlistToolStripMenuItem.DropDownItems.Add(deleteMultipleSongToPlaylist);
            }
        }
        private void deletePlaylistToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (label1.Text.Contains(e.ClickedItem.Text))
                {
                    throw new FileLoadException();
                }
                File.Delete(Application.StartupPath + @"\" + e.ClickedItem.Text + ".ompl");
                MessageBox.Show("Playlist " + e.ClickedItem.Text + " has been deleted.", "Osu Music");
                loadExistingPlaylist();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while deleting playlist.", "Osu Music");
            }
        }

        private void addSongToPlaylistToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                foreach (string path in playlistFileReader(e.ClickedItem.Text))
                {
                    if (Path.GetDirectoryName(nowPlaying.Text).Equals(path))
                    {
                        throw new FileNotFoundException();
                    }
                }
                playlistFileWriter(@Application.StartupPath + @"\" + e.ClickedItem.Text + ".ompl", nowPlaying.Text, true);
                MessageBox.Show("Song added in selected playlist.", "Osu Music");

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Song already added in selected playlist.", "Osu Music");
            }
        }
        private void deleteToolStripClicked(object sender, EventArgs e)
        {
            List<string> toWrite = new List<string>();
            string playlistName = label1.Text.TrimStart("Now Playing Playlist: ".ToCharArray());
            foreach (string oldContent in playlistFileReader(playlistName))
            {
                if (oldContent.Equals(nowPlaying.Text))
                {
                    continue;
                }
                else
                {
                    toWrite.Add(oldContent);
                } 
            }
            for(int index = 0; index < toWrite.Count; index++)
            {
                if (toWrite[index].Equals(toWrite[0]))
                {
                    playlistFileWriter(playlistName+".ompl", toWrite[index], false);
                }
                else
                {
                    playlistFileWriter(playlistName+".ompl", toWrite[index], true);
                }
            }
            MessageBox.Show("Song removed from playlist. Current playlist reload started.", "Osu Music");
            loadPlaylist(playlistName);
        }
        private void AddMultipleSongsToolStripClicked(object sender, EventArgs e)
        {
            setSelectVisible("Add", true, addMultipleSong.ToArray());
        }
        private void DeleteMultipleSongsToolStripClicked(object sender, EventArgs e)
        {
            setSelectVisible("Delete", true, playListSongs.Keys.ToArray());
        }
        private void actionSelectBtn_Click(object sender, EventArgs e)
        {
            setSelectVisible("", false, null);
        }
        #endregion
        #endregion
        #region methods
        private void loadPlaylist()
        {
            if(addMultipleSong.Count != 0)
            {
                addMultipleSong.Clear();
            }
            label1.Text = "Loading Audio Files. Please wait.";
            SetControlActivity(false);
            playListSongs.Clear();
            loader(path);
            try
            {
                nowPlaying.DataSource = playListSongs.Keys.ToArray();
                nowPlaying.SelectedIndex = 0;
                label1.Text = "Now Playing : Default";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No MP3 file found on directory! Select OSU Songs Directory", "Osu Music");
                Browse_Click(this, null);
                Ok_Click(this, null);
            }
            try
            {
                playlistToolStripMenuItem.DropDownItems.Remove(deleteFromPlaylist);
                playlistToolStripMenuItem.DropDownItems.Remove(addMultipleToPlaylist);
                playlistToolStripMenuItem.DropDownItems.Remove(deleteMultipleSongToPlaylist);
            }
            catch(ArgumentOutOfRangeException)
            {
                //Do nothing
            }

        }
        private void loader(string localPath)
        {
            try
            {
                string line, file, song = " ", pic = " ";
                SearchOption optionSearch;
                if (localPath.Equals(path))
                {
                    optionSearch = SearchOption.AllDirectories;
                }
                else
                {
                    optionSearch = SearchOption.TopDirectoryOnly;
                }
                foreach (string osuFile in Directory.EnumerateFiles(Path.GetDirectoryName(localPath), "*.osu", optionSearch))
                {
                    Application.DoEvents();
                    try
                    {
                        using (StreamReader sr = new StreamReader(osuFile))
                        {
                            bool hasPic = false;

                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains("AudioFilename: "))
                                {
                                    if (localPath.Contains(".mp3"))
                                    {
                                        if (line.Contains(Path.GetFileName(localPath)))
                                        {
                                            addMultipleSong.Remove(song);
                                            song = localPath;
                                            continue;
                                        }
                                        else
                                        {
                                            throw new RuntimeBinderException();
                                        }
                                    }
                                    if ((file = Path.GetDirectoryName(osuFile) + @"\" + line.Split(new char[] { ' ' }, 2)[1]).Equals(song) || !line.Contains(".mp3"))
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
                                    pic = Path.GetDirectoryName(osuFile) + @"\" + line.Split(new char[] { '"' }, 3)[1].TrimStart(' ');
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
                    catch (RuntimeBinderException)
                    {
                        continue;
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show(localPath + " not found.", "Osu Music");
                    }
                }
                SetControlActivity(true);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found! Select OSU Songs Directory", "Osu Music");
                Browse_Click(this, null);
                Ok_Click(this, null);
            }
        }
        private void loadPlaylist(string playListName)
        {

            if (label1.Text.Contains("Default"))
            {
                addMultipleSong.AddRange(playListSongs.Keys.ToArray());
            }
            playListSongs.Clear();
            label1.Text = "Loading Audio Files. Please wait.";
            SetControlActivity(false);
            
            foreach(string localPath in playlistFileReader(playListName))
            {
                loader(localPath);
            }

            try
            {
                nowPlaying.DataSource = playListSongs.Keys.ToArray();
                nowPlaying.SelectedIndex = 0;
                label1.Text = "Now Playing Playlist: " + playListName;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No MP3 file found on playlist! Loading Default Playlist", "Osu Music");
                loadPlaylist();
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
        public void loadExistingPlaylist()
        {
            loadToolStripMenuItem.DropDownItems.Clear();
            deletePlaylistToolStripMenuItem.DropDownItems.Clear();
            addSongToPlaylistToolStripMenuItem.DropDownItems.Clear();
            loadToolStripMenuItem.DropDownItems.Add("Default");
            foreach(string osuPlaylistFile in Directory.EnumerateFiles(Application.StartupPath, "*.ompl"))
            {
                loadToolStripMenuItem.DropDownItems.Add(Path.GetFileNameWithoutExtension(osuPlaylistFile));
                deletePlaylistToolStripMenuItem.DropDownItems.Add(Path.GetFileNameWithoutExtension(osuPlaylistFile));
                addSongToPlaylistToolStripMenuItem.DropDownItems.Add(Path.GetFileNameWithoutExtension(osuPlaylistFile));
            }
        }
        private string[] playlistFileReader(string fileName)
        {
            List<string> paths = new List<string>();
            string line = "";
            using (StreamReader sr = new StreamReader(Application.StartupPath+@"\"+fileName+".ompl"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    paths.Add(line);
                }
            }
            return paths.ToArray();
        }
        private void playlistFileWriter(string fileName, string toWriteContent, bool doNotOverwrite)
        {
            using (StreamWriter sw = new StreamWriter(fileName, doNotOverwrite))
            {
                sw.WriteLine(toWriteContent);
            }
        }
        private void setSelectVisible(string action, bool visibility, string[] source)
        {
            multipleListBoxLbl.Text = "Select songs to " + action.ToLower() + " on playlist";
            songListBox.Visible = visibility;
            actionSelectBtn.Text = action;
            actionSelectBtn.Visible = visibility;
            multipleListBoxLbl.Visible = visibility;
            try
            {
                songListBox.Items.AddRange(source);
            }
            catch (ArgumentNullException)
            {
                songListBox.Items.Clear();
            }     
        }
        #endregion
    }
}