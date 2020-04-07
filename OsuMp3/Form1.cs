﻿using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace OsuMp3
{
    public partial class Form1 : Form
    {
        private readonly WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        private static string path = @"C:\Osu!\Songs";
        private bool isFound = false;
        private readonly Timer timer = new Timer();
        private readonly Timer playNext = new Timer();
        public Form1()
        {
            playNext.Tick += PlayNextEvent;
            timer.Tick += TimerEventProcessor;
            player.PlayStateChange += PlayStateChanged;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            nowPlaying.Items.Clear();

            try
            {
                nowPlaying.Items.AddRange(Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories));  //searches dir for mp3 files
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found! Select OSU Songs Directory", "Osu MP3 Player");
                Browse_Click(this, null);
                Ok_Click(this, null);
            }

            pathBox.Text = path;

            try
            {
                nowPlaying.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No MP3 file found on directory! Select OSU Songs Directory", "Osu MP3 Player");
                Browse_Click(this, null);
                Ok_Click(this, null);
            }
        }
        private void Play_Click(object sender, EventArgs e)
        {
            if (play.Text == "Play")
            {
                player.controls.play();
            }
            else if (play.Text == "Pause")
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
            player.URL = nowPlaying.Text;

            try
            {
                albumPicture.Image = new Bitmap(Directory.EnumerateFiles(@Path.GetDirectoryName(player.URL), "*.jpg", SearchOption.TopDirectoryOnly).First());
            }
            catch (InvalidOperationException)
            {
                try
                {
                    albumPicture.Image = new Bitmap(Directory.EnumerateFiles(@Path.GetDirectoryName(player.URL), "*.png", SearchOption.TopDirectoryOnly).First());
                }
                catch (InvalidOperationException)
                {
                    albumPicture.Image = Properties.Resources.circles;
                }
            }

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
        private void Ok_Click(object sender, EventArgs e)
        {
            if (path != pathBox.Text)
            {
                path = pathBox.Text;
            }

            FolderSetVisible(false);
            ok.Visible = false;

            Form1_Load(this, null);
        }
        private void FindBtn_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < nowPlaying.Items.Count; x++)
            {
                if (nowPlaying.GetItemText(nowPlaying.Items[x]).ToLower().Contains(search.Text.Trim(".mp3".ToCharArray()).ToLower()))
                {
                    isFound = true;
                    nowPlaying.SelectedIndex = x;
                    search.Text = "";
                    SearchVisible(false);
                    break;
                }
                else
                {
                    if(x == (nowPlaying.Items.Count - 1))
                    {
                        isFound = false;
                    }
                    continue;
                }
            }

            if (!isFound)
            {
                MessageBox.Show("Music Not Found!", "OSU Music Player");
            }
        }
        private void PlayStateChanged(int newState)
        {
            switch (newState)
            {
                case 1:    // Stopped
                    timeLeft.Value = 0;
                    currentPosition.Text = TimeSpan.FromMinutes((int)Math.Floor(player.controls.currentPosition)).ToString("hh':'mm");
                    timer.Stop();
                    if (play.Text == "Pause")
                    {
                        play.Text = "Play";
                    }
                    break;
                case 2:    // Paused
                    if (play.Text == "Pause")
                    {
                        play.Text = "Play";
                    }
                    timer.Stop();

                    break;
                case 3:    // Playing
                    if (play.Text == "Play")
                    {
                        play.Text = "Pause";
                    }

                    timer.Interval = 1000;
                    timer.Start();
                    break;
                case 8:    // MediaEnded
                    if (play.Text == "Pause")
                    {
                        play.Text = "Play";
                    }
                    next.PerformClick();
                    playNext.Start();
                    break;
                default:
                    currentPosition.Text = "00:00";
                    timeLeft.Value = 0;
                    timer.Stop();
                    play.Text = "Play";
                    break;
            }
        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            timeLeft.Maximum = Convert.ToInt32(Math.Floor(player.currentMedia.duration));
            timeLeft.Value = Convert.ToInt32(Math.Floor(player.controls.currentPosition));
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
            timeLeft.Value = Convert.ToInt32(Math.Floor(player.controls.currentPosition));
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
        private void ExtractPlayingMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savepath = @OpenFileDiag("Select Your File Save Destination: ");
            try
            {
                File.Copy(nowPlaying.Text, savepath +@"\"+ Path.GetDirectoryName(nowPlaying.Text).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ') + ".mp3");
                MessageBox.Show("mp3 file extracted. Saved to: "+savepath, "Osu Mp3 Player");
            }
            catch (IOException)
            {
                MessageBox.Show("File aready exists!", "Osu Mp3 Player");
            }
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
                    MessageBox.Show("Files Copying on Background. Please wait.", "Osu Music Player");
                }
                Application.DoEvents();
                backgroundCopy.Text = "Files copying on background... \r\n" + (x+1) + " out of " + nowPlaying.Items.Count + " copied \r\n"+error+" failed"; ;
                try
                {
                    if(File.Exists(@savepath + @"\" + Path.GetDirectoryName(nowPlaying.Items[x].ToString()).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ') + ".mp3"))
                    {
                        File.Copy(@nowPlaying.Items[x].ToString(), @savepath + @"\" + Path.GetFileName(nowPlaying.Items[x].ToString()).TrimStart("0123456789".ToCharArray()).TrimStart(' ') + ".mp3", true);
                    }
                    else
                    {
                        File.Copy(@nowPlaying.Items[x].ToString(), @savepath + @"\" + Path.GetDirectoryName(nowPlaying.Items[x].ToString()).Trim(path.ToCharArray()).TrimStart("0123456789".ToCharArray()).TrimStart(' ') + ".mp3", true);
                    }
                    success++;
                }
                catch (DirectoryNotFoundException)
                {
                    try
                    {
                        File.Copy(@nowPlaying.Items[x].ToString(), @savepath + @"\" + Path.GetFileName(nowPlaying.Items[x].ToString()).TrimStart("0123456789".ToCharArray()).TrimStart(' ') + ".mp3", true);
                        success++;
                    }
                    catch (Exception)
                    {
                        error++;
                    }
                }
                catch (Exception)
                {
                    error++;
                }

                if (x == nowPlaying.Items.Count - 1)
                {
                    MessageBox.Show("Sucessfully copied " + success + " files. Error occured when copying " + error + " files.", "Osu Mp3 Player");
                }
            }
            backgroundCopy.Visible = false;
        }
    }
}