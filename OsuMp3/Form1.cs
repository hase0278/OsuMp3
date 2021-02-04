using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;
using System.Text;

namespace OsuMp3
{
    public partial class songsCheckList : Form
    {
        #region member variables
        private Mp3Player player;
        private ToolStripMenuItem addMultipleToPlaylist = new ToolStripMenuItem("Add songs to current playlist");
        private ToolStripMenuItem deleteMultipleSongToPlaylist = new ToolStripMenuItem("Delete songs from current playlist");
        private ToolStripMenuItem deleteFromPlaylist = new ToolStripMenuItem("Delete song from playlist");
        private static string path;
        private bool isFound = false;
        private readonly Timer timer = new Timer();
        private readonly Timer playNext = new Timer();
        private string playpause = "play";
        private Dictionary<string, string> DefSong = new Dictionary<string, string>();
        private Dictionary<string, string> addMultipleSong = new Dictionary<string, string>();
        private Dictionary<string, string> playListSongs = new Dictionary<string, string>();
        #endregion
        #region constructor
        public songsCheckList()
        {
            try
            {
                path = File.ReadAllText(Application.StartupPath + @"\path.conf");
            }
            catch(FileNotFoundException)
            {
                path = @"C:\osu!\Songs";
                File.WriteAllText(Application.StartupPath + @"\path.conf", path);
            }
            timer.Tick += TimerEventProcessor;
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
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findBtn.PerformClick();
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            setSelectVisible("", false, null);
        }
        private void TimeLeft_ValueChanged(object sender, EventArgs e)
        {
            if(timeLeft.Value == timeLeft.Maximum)
            {
                PlayStateChanged(8);
            }
        }
        private void Play_Click(object sender, EventArgs e)
        {
            
            
            if (playpause == "play")
            {
                if(player == null)
                {
                    player = new Mp3Player(addMultipleSong[nowPlaying.Text]);
                }
                Play();
            }
            else if (playpause == "pause")
            {
                Pause();
            }
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            if (player != null)
            {
                Stop();
                player = null;
            }
        }
        private void NowPlaying_TextChanged(object sender, EventArgs e)
        {
            albumPicture.Image.Dispose();
            if (playListSongs[addMultipleSong[nowPlaying.Text]] == "No Pic")
            {
                albumPicture.Image = Properties.Resources.circles;
            }
            else
            {
                albumPicture.Image = new Bitmap(@playListSongs[addMultipleSong[nowPlaying.Text]]);
            }
            
            if(player != null)
            {
                player.Dispose();
            }
            
            player = new Mp3Player(@addMultipleSong[nowPlaying.Text]);
            Play();
        }
        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                nowPlaying.SelectedIndex += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                nowPlaying.SelectedIndex = 0;
            }
        }
        private void Previous_Click(object sender, EventArgs e)
        {
            if (nowPlaying.SelectedIndex != 0)
            {
                nowPlaying.SelectedIndex -= 1;
            }
            else
            {
                nowPlaying.SelectedIndex = nowPlaying.Items.Count - 1;
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
                File.WriteAllText(Application.StartupPath + @"\path.conf", pathBox.Text);
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
                if (nowPlaying.GetItemText(nowPlaying.Items[x]).ToLower().Contains(search.Text.Replace(".mp3", "").ToLower()))
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
                    timeLeft.Maximum = Convert.ToInt32(player.getLength());
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
            if (player == null)
            {
                timer.Stop();
                timeLeft.Value = 0;
            }
            else
            {
                timeLeft.Value = (int)player.currentPosition();
                currentPosition.Text = TimeSpan.FromMilliseconds(player.getLength()).ToString("mm':'ss");
            }

        }
        private void TimeLeft_Scroll(object sender, EventArgs e)
        {
            player.SetPosition(timeLeft.Value);
        }
        private void SetOsuSongsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(search.Visible || !label1.Text.Equals("Now Playing : Default"))
            {

            }
            else
            {
                FolderSetVisible(true);
            } 
        }
        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!pathBox.Visible && !songListBox.Visible)
            {
                SearchVisible(true);
            }
        }
        private void ExtractPlayingMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractFile(addMultipleSong[nowPlaying.Text], nowPlaying.Text, ".mp3");
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
                    if(File.Exists(@savepath + @"\" + nowPlaying.Items[x].ToString() + ".mp3"))
                    {
                        File.Copy(@addMultipleSong[nowPlaying.Items[x].ToString()], @savepath + @"\" + nowPlaying.Items[x].ToString() + "_1.mp3", false);
                    }
                    else
                    {
                        File.Copy(@addMultipleSong[nowPlaying.Items[x].ToString()], @savepath + @"\" + nowPlaying.Items[x].ToString() + ".mp3", false);
                    }
                    success++;
                }
                catch (Exception)
                {
                    error++;
                    continue;
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
                //Do nothing
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
            player.SetVolume(volume.Value);
        }
        private void SetAlbumPictureAsWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!playListSongs[addMultipleSong[nowPlaying.Text]].Equals("No Pic"))
            {
                setPcWallPaper.setAsWallpaper(playListSongs[addMultipleSong[nowPlaying.Text]]);
                MessageBox.Show("Wallpaper set to " + @playListSongs[addMultipleSong[nowPlaying.Text]] + ".", "Osu Music");
            }
            else
            {
                Bitmap img = new Bitmap(Properties.Resources.circles);
                img.Save(@Application.StartupPath + @"\album.jpg");
                setPcWallPaper.setAsWallpaper(@Application.StartupPath+@"\album.jpg");
                MessageBox.Show("Wallpaper set to Nekodex - Circles.jpg.", "Osu Music");
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
                    if (Path.GetDirectoryName(addMultipleSong[nowPlaying.Text]).Equals(path))
                    {
                        throw new FileNotFoundException();
                    }
                }
                playlistFileWriter(@Application.StartupPath + @"\" + e.ClickedItem.Text + ".ompl", addMultipleSong[nowPlaying.Text].Replace(path, ""), true);
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
            string playlistName = label1.Text.Replace("Now Playing Playlist: ", "");
            foreach (string oldContent in playlistFileReader(playlistName))
            {
                if (oldContent.Equals(addMultipleSong[nowPlaying.Text].Replace(path, "")))
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
            if (!search.Visible && !pathBox.Visible)
            {
                setSelectVisible("Add", true, DefSong.Keys.ToArray());
            }        
        }
        private void DeleteMultipleSongsToolStripClicked(object sender, EventArgs e)
        {
            if (!search.Visible && !pathBox.Visible)
            {
                setSelectVisible("Delete", true, addMultipleSong.Keys.ToArray());
            }
        }
        private void actionSelectBtn_Click(object sender, EventArgs e)
        {
            if (multipleListBoxLbl.Text.ToLower().Contains("add"))
            {
                foreach(string toWrite in songListBox.CheckedItems)
                {
                    playlistFileWriter(Application.StartupPath + @"\" + label1.Text.Replace("Now Playing Playlist: ", "") + ".ompl", DefSong[toWrite].Replace(path, ""), true);
                }
                MessageBox.Show("Songs added in selected playlist. Refreshing", "Osu Music");
                loadPlaylist(label1.Text.Replace("Now Playing Playlist: ", ""));
            }else if (multipleListBoxLbl.Text.ToLower().Contains("delete"))
            {
                bool deleteItemFound = false;
                List<string> toWrite = new List<string>();
                string playlistName = label1.Text.Replace("Now Playing Playlist: ", "");
                foreach (string oldContent in playlistFileReader(playlistName))
                {
                    foreach(string keys in songListBox.CheckedItems)
                    {
                        if (addMultipleSong[keys].Replace(path, "").Equals(oldContent))
                        {
                            deleteItemFound = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (deleteItemFound)
                    {
                        deleteItemFound = false;
                        continue;
                    }
                    else
                    {
                        toWrite.Add(oldContent);
                    }
                }
                for (int index = 0; index < toWrite.Count; index++)
                {
                    if (toWrite[index].Equals(toWrite[0]))
                    {
                        playlistFileWriter(playlistName + ".ompl", toWrite[index], false);
                    }
                    else
                    {
                        playlistFileWriter(playlistName + ".ompl", toWrite[index], true);
                    }
                }
                MessageBox.Show("Song removed from playlist. Current playlist reload started.", "Osu Music");
                loadPlaylist(playlistName);
            }
            setSelectVisible("", false, null);
        }
        #endregion
        #endregion
        #region methods
        private void Play()
        {
            player.Play();
            player.isPlaying = true;
            PlayStateChanged(3);
        }
        private void Pause()
        {
            player.Pause();
            player.isPlaying = false;
            PlayStateChanged(2);
        }
        private void Stop()
        {
            player.Stop();
            player.isPlaying = false;
            PlayStateChanged(2);
        }
        private void loadPlaylist()
        {
            DefSong.Clear();
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
                nowPlaying.DataSource = addMultipleSong.Keys.ToArray();
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
                string line, file, song = " ", pic = " ", artist = "", title = "";
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
                                else if (line.Contains("Title:"))
                                {
                                    title = line.Replace("Title:", "");
                                }
                                else if (line.Contains("Artist:"))
                                {
                                    artist = line.Replace("Artist:", "");
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
                                try
                                {
                                    if(song.ToLower().Contains("collection") || song.ToLower().Contains("mappack") || song.ToLower().Contains("openings") || song.ToLower().Contains("endings"))
                                    {
                                        addMultipleSong.Add(Path.GetFileName(song).Replace(".mp3", "") + " - " + Path.GetDirectoryName(song).Replace(path + @"\", ""), song);
                                    }
                                    else
                                    {
                                        addMultipleSong.Add(title + " - " + artist, song);
                                    } 
                                }
                                catch (ArgumentException)
                                {
                                    
                                }
                                
                            }
                            else
                            {
                                if (!playListSongs.ContainsKey(song))
                                {
                                    playListSongs.Add(song, pic);
                                    try
                                    {
                                        if (song.ToLower().Contains("collection") || song.ToLower().Contains("mappack") || song.ToLower().Contains("openings") || song.ToLower().Contains("endings"))
                                        {
                                            addMultipleSong.Add(Path.GetFileName(song).Replace(".mp3", "") + " - " + Path.GetDirectoryName(song).Replace(path + @"\", ""), song);
                                        }
                                        else
                                        {
                                            addMultipleSong.Add(title + " - " + artist, song);
                                        }
                                    }
                                    catch (ArgumentException)
                                    {
                                        
                                    }
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
            if(label1.Text.Replace("Now Playing : ", "").Equals("Default"))
            {
                DefSong = new Dictionary<string, string>(addMultipleSong);
            }
            addMultipleSong.Clear();
            playListSongs.Clear();
            label1.Text = "Loading Audio Files. Please wait.";
            SetControlActivity(false);
            
            foreach(string localPath in playlistFileReader(playListName))
            {
                loader(@path + @localPath);
            }

            try
            {
                nowPlaying.DataSource = addMultipleSong.Keys.ToArray();
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
            if (playListSongs[addMultipleSong[nowPlaying.Text]].Equals("No Pic"))
            {
                string savePath = OpenFileDiag("Select Your File Save Destination: ");
                Properties.Resources.circles.Save(savePath + @"\" + "nekodex - circles.jpg");
                MessageBox.Show("jpg file extracted. Saved to: " + savePath, "Osu Music");
            }
            else
            {
                ExtractFile(playListSongs[addMultipleSong[nowPlaying.Text]], nowPlaying.Text, Path.GetExtension(playListSongs[addMultipleSong[nowPlaying.Text]]));
            }
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
            cancel.Visible = visibility;
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

        #region mp3PlayerClass

        class Mp3Player : IDisposable
        {
            [DllImport(@"winmm.dll")]
            private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallBack);
            public bool Repeat { get; set; }
            public bool isPlaying { get; set; }

            public void SetPosition(int miliseconds)
            {
                if (isPlaying)
                {
                    string command = "play MediaFile from " + miliseconds.ToString();
                    checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
                }
                else
                {
                    string command = "seek MediaFile to " + miliseconds.ToString();
                    checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
                }
            }

            public long getLength()
            {
                StringBuilder sb = new StringBuilder(128);
                mciSendString("status MediaFile length", sb, 128, IntPtr.Zero);
                
                return Convert.ToInt64(sb.ToString());
            }

            public long currentPosition()
            {
                StringBuilder sb = new StringBuilder(128);
                mciSendString("status MediaFile position", sb, 128, IntPtr.Zero);
                long songlength = (long)Convert.ToUInt64(sb.ToString());
                return songlength;
            }

            public void SetVolume(int volume)
            {
                string command = "setaudio MediaFile volume to " + volume.ToString();
                checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
            }

            public Mp3Player(string FileName)
            {
                string command = "open \"" + @FileName + "\" type mpegvideo alias MediaFile";
                try
                {
                    checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
                }
                catch (Exception)
                {
                    TagLib.File file = TagLib.File.Create(@FileName);
                    file.RemoveTags(TagLib.TagTypes.AllTags);
                    file.Save();
                    command = "open \"" + @FileName + "\" type mpegvideo alias MediaFile";
                    checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
                }
            }

            public void Play()
            {
                string command = "play MediaFile";
                if (Repeat)
                {
                    command += " REPEAT";
                }
                checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
            }

            public void Pause()
            {
                string command = "pause MediaFile";
                checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
            }
            public void Stop()
            {
                string command = "close MediaFile";
                checkMCIResult(mciSendString(command, null, 0, IntPtr.Zero));
            }

            private static void checkMCIResult(long code)
            {
                int err = (int)(code & 0xffffffff);
                if (err != 0)
                {
                    throw new Exception(string.Format("MCI error {0}", err));
                }
            }

            public void Dispose()
            {
                string command = "close MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }


        #endregion
        #region wallpaperHandlerClass
        public class setPcWallPaper
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
            public static void setAsWallpaper(string imgPath)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                {
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }

                SystemParametersInfo(20, 0, @imgPath, 0x01 | 0x02);
            }
        }
        #endregion
    }
}