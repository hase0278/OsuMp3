namespace OsuMp3
{
    partial class songsCheckList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(songsCheckList));
            this.nowPlaying = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathlbl = new System.Windows.Forms.Label();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.searchlbl = new System.Windows.Forms.Label();
            this.timeLeft = new System.Windows.Forms.TrackBar();
            this.currentPosition = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOSUSongsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlayingMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractAllMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractAlbumPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAlbumPictureAsWallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSongToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundCopy = new System.Windows.Forms.Label();
            this.SearchResult = new System.Windows.Forms.ListBox();
            this.albumPicture = new System.Windows.Forms.PictureBox();
            this.previous = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.volume = new System.Windows.Forms.TrackBar();
            this.volumeLbl = new System.Windows.Forms.Label();
            this.songListBox = new System.Windows.Forms.CheckedListBox();
            this.multipleListBoxLbl = new System.Windows.Forms.Label();
            this.actionSelectBtn = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timeLeft)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            this.SuspendLayout();
            // 
            // nowPlaying
            // 
            this.nowPlaying.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.nowPlaying.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nowPlaying.ForeColor = System.Drawing.SystemColors.InfoText;
            this.nowPlaying.FormattingEnabled = true;
            this.nowPlaying.Location = new System.Drawing.Point(34, 314);
            this.nowPlaying.Name = "nowPlaying";
            this.nowPlaying.Size = new System.Drawing.Size(719, 21);
            this.nowPlaying.TabIndex = 1;
            this.nowPlaying.TextChanged += new System.EventHandler(this.NowPlaying_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Now Playing";
            // 
            // pathlbl
            // 
            this.pathlbl.AutoSize = true;
            this.pathlbl.Location = new System.Drawing.Point(12, 428);
            this.pathlbl.Name = "pathlbl";
            this.pathlbl.Size = new System.Drawing.Size(86, 13);
            this.pathlbl.TabIndex = 11;
            this.pathlbl.Text = "Osu songs folder";
            this.pathlbl.Visible = false;
            // 
            // pathBox
            // 
            this.pathBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pathBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pathBox.Location = new System.Drawing.Point(104, 425);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.Size = new System.Drawing.Size(144, 20);
            this.pathBox.TabIndex = 12;
            this.pathBox.Visible = false;
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ok.ForeColor = System.Drawing.SystemColors.Menu;
            this.ok.Location = new System.Drawing.Point(310, 425);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(50, 20);
            this.ok.TabIndex = 13;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Visible = false;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // browse
            // 
            this.browse.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.browse.ForeColor = System.Drawing.SystemColors.Menu;
            this.browse.Location = new System.Drawing.Point(254, 425);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(50, 20);
            this.browse.TabIndex = 14;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = false;
            this.browse.Visible = false;
            this.browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // search
            // 
            this.search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.search.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.search.ForeColor = System.Drawing.SystemColors.InfoText;
            this.search.Location = new System.Drawing.Point(80, 35);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(627, 20);
            this.search.TabIndex = 15;
            this.search.Visible = false;
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // findBtn
            // 
            this.findBtn.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.findBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.findBtn.Location = new System.Drawing.Point(713, 32);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 23);
            this.findBtn.TabIndex = 16;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Visible = false;
            this.findBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Location = new System.Drawing.Point(6, 38);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(75, 13);
            this.searchlbl.TabIndex = 17;
            this.searchlbl.Text = "Search Music:";
            this.searchlbl.Visible = false;
            // 
            // timeLeft
            // 
            this.timeLeft.Location = new System.Drawing.Point(33, 357);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(720, 45);
            this.timeLeft.TabIndex = 19;
            this.timeLeft.TickStyle = System.Windows.Forms.TickStyle.None;
            this.timeLeft.Scroll += new System.EventHandler(this.TimeLeft_Scroll);
            this.timeLeft.ValueChanged += new System.EventHandler(this.TimeLeft_ValueChanged);
            // 
            // currentPosition
            // 
            this.currentPosition.AutoSize = true;
            this.currentPosition.Location = new System.Drawing.Point(32, 341);
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.Size = new System.Drawing.Size(34, 13);
            this.currentPosition.TabIndex = 20;
            this.currentPosition.Text = "00:00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.playlistToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.setOSUSongsFolderToolStripMenuItem,
            this.extractPlayingMusicToolStripMenuItem,
            this.extractAllMusicToolStripMenuItem,
            this.extractAlbumPictureToolStripMenuItem,
            this.setAlbumPictureAsWallpaperToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // setOSUSongsFolderToolStripMenuItem
            // 
            this.setOSUSongsFolderToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.setOSUSongsFolderToolStripMenuItem.Name = "setOSUSongsFolderToolStripMenuItem";
            this.setOSUSongsFolderToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.setOSUSongsFolderToolStripMenuItem.Text = "Set OSU Songs Folder";
            this.setOSUSongsFolderToolStripMenuItem.Click += new System.EventHandler(this.SetOsuSongsFolderToolStripMenuItem_Click);
            // 
            // extractPlayingMusicToolStripMenuItem
            // 
            this.extractPlayingMusicToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.extractPlayingMusicToolStripMenuItem.Name = "extractPlayingMusicToolStripMenuItem";
            this.extractPlayingMusicToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.extractPlayingMusicToolStripMenuItem.Text = "Extract Playing Music";
            this.extractPlayingMusicToolStripMenuItem.Click += new System.EventHandler(this.ExtractPlayingMusicToolStripMenuItem_Click);
            // 
            // extractAllMusicToolStripMenuItem
            // 
            this.extractAllMusicToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.extractAllMusicToolStripMenuItem.Name = "extractAllMusicToolStripMenuItem";
            this.extractAllMusicToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.extractAllMusicToolStripMenuItem.Text = "Extract All Music";
            this.extractAllMusicToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllMusicToolStripMenuItem_Click);
            // 
            // extractAlbumPictureToolStripMenuItem
            // 
            this.extractAlbumPictureToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.extractAlbumPictureToolStripMenuItem.Name = "extractAlbumPictureToolStripMenuItem";
            this.extractAlbumPictureToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.extractAlbumPictureToolStripMenuItem.Text = "Extract Album Picture";
            this.extractAlbumPictureToolStripMenuItem.Click += new System.EventHandler(this.ExtractAlbumPictureToolStripMenuItem_Click);
            // 
            // setAlbumPictureAsWallpaperToolStripMenuItem
            // 
            this.setAlbumPictureAsWallpaperToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.setAlbumPictureAsWallpaperToolStripMenuItem.Name = "setAlbumPictureAsWallpaperToolStripMenuItem";
            this.setAlbumPictureAsWallpaperToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.setAlbumPictureAsWallpaperToolStripMenuItem.Text = "Set Album Picture As Wallpaper";
            this.setAlbumPictureAsWallpaperToolStripMenuItem.Click += new System.EventHandler(this.SetAlbumPictureAsWallpaperToolStripMenuItem_Click);
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPlaylistToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.deletePlaylistToolStripMenuItem,
            this.addSongToPlaylistToolStripMenuItem});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // createPlaylistToolStripMenuItem
            // 
            this.createPlaylistToolStripMenuItem.Name = "createPlaylistToolStripMenuItem";
            this.createPlaylistToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.createPlaylistToolStripMenuItem.Text = "Create Playlist";
            this.createPlaylistToolStripMenuItem.Click += new System.EventHandler(this.createPlaylistToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.loadToolStripMenuItem.Text = "Load Playlist";
            this.loadToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.loadToolStripMenuItem_DropDownItemClicked);
            // 
            // deletePlaylistToolStripMenuItem
            // 
            this.deletePlaylistToolStripMenuItem.Name = "deletePlaylistToolStripMenuItem";
            this.deletePlaylistToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deletePlaylistToolStripMenuItem.Text = "Delete Playlist";
            this.deletePlaylistToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.deletePlaylistToolStripMenuItem_DropDownItemClicked);
            // 
            // addSongToPlaylistToolStripMenuItem
            // 
            this.addSongToPlaylistToolStripMenuItem.Name = "addSongToPlaylistToolStripMenuItem";
            this.addSongToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.addSongToPlaylistToolStripMenuItem.Text = "Add This Song to Playlist";
            this.addSongToPlaylistToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.addSongToPlaylistToolStripMenuItem_DropDownItemClicked);
            // 
            // backgroundCopy
            // 
            this.backgroundCopy.AutoSize = true;
            this.backgroundCopy.Location = new System.Drawing.Point(588, 393);
            this.backgroundCopy.Name = "backgroundCopy";
            this.backgroundCopy.Size = new System.Drawing.Size(146, 13);
            this.backgroundCopy.TabIndex = 22;
            this.backgroundCopy.Text = "Files copying on background:";
            this.backgroundCopy.Visible = false;
            // 
            // SearchResult
            // 
            this.SearchResult.FormattingEnabled = true;
            this.SearchResult.Location = new System.Drawing.Point(80, 52);
            this.SearchResult.Name = "SearchResult";
            this.SearchResult.Size = new System.Drawing.Size(627, 56);
            this.SearchResult.TabIndex = 23;
            this.SearchResult.Visible = false;
            this.SearchResult.SelectedIndexChanged += new System.EventHandler(this.SearchResult_SelectedIndexChanged);
            // 
            // albumPicture
            // 
            this.albumPicture.Image = global::OsuMp3.Properties.Resources.circles;
            this.albumPicture.Location = new System.Drawing.Point(35, 67);
            this.albumPicture.Name = "albumPicture";
            this.albumPicture.Size = new System.Drawing.Size(719, 228);
            this.albumPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumPicture.TabIndex = 10;
            this.albumPicture.TabStop = false;
            // 
            // previous
            // 
            this.previous.BackColor = System.Drawing.Color.Transparent;
            this.previous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previous.BackgroundImage")));
            this.previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previous.ForeColor = System.Drawing.SystemColors.Menu;
            this.previous.Location = new System.Drawing.Point(291, 378);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(41, 28);
            this.previous.TabIndex = 7;
            this.previous.UseVisualStyleBackColor = false;
            this.previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.Transparent;
            this.next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("next.BackgroundImage")));
            this.next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.next.ForeColor = System.Drawing.SystemColors.Menu;
            this.next.Location = new System.Drawing.Point(438, 378);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(42, 28);
            this.next.TabIndex = 6;
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.Transparent;
            this.stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stop.BackgroundImage")));
            this.stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stop.ForeColor = System.Drawing.SystemColors.Menu;
            this.stop.Location = new System.Drawing.Point(391, 378);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(41, 28);
            this.stop.TabIndex = 5;
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("play.BackgroundImage")));
            this.play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.play.ForeColor = System.Drawing.SystemColors.Menu;
            this.play.Location = new System.Drawing.Point(338, 378);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(47, 28);
            this.play.TabIndex = 3;
            this.play.UseVisualStyleBackColor = false;
            this.play.Click += new System.EventHandler(this.Play_Click);
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(80, 380);
            this.volume.Maximum = 1000;
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(103, 45);
            this.volume.TabIndex = 24;
            this.volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volume.Value = 1000;
            this.volume.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // volumeLbl
            // 
            this.volumeLbl.AutoSize = true;
            this.volumeLbl.Location = new System.Drawing.Point(30, 386);
            this.volumeLbl.Name = "volumeLbl";
            this.volumeLbl.Size = new System.Drawing.Size(51, 13);
            this.volumeLbl.TabIndex = 25;
            this.volumeLbl.Text = "Volume : ";
            // 
            // songListBox
            // 
            this.songListBox.FormattingEnabled = true;
            this.songListBox.Location = new System.Drawing.Point(34, 67);
            this.songListBox.Name = "songListBox";
            this.songListBox.Size = new System.Drawing.Size(720, 349);
            this.songListBox.TabIndex = 26;
            this.songListBox.Visible = false;
            // 
            // multipleListBoxLbl
            // 
            this.multipleListBoxLbl.AutoSize = true;
            this.multipleListBoxLbl.Location = new System.Drawing.Point(33, 41);
            this.multipleListBoxLbl.Name = "multipleListBoxLbl";
            this.multipleListBoxLbl.Size = new System.Drawing.Size(10, 13);
            this.multipleListBoxLbl.TabIndex = 27;
            this.multipleListBoxLbl.Text = " ";
            // 
            // actionSelectBtn
            // 
            this.actionSelectBtn.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.actionSelectBtn.Location = new System.Drawing.Point(324, 418);
            this.actionSelectBtn.Name = "actionSelectBtn";
            this.actionSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.actionSelectBtn.TabIndex = 28;
            this.actionSelectBtn.Text = "button1";
            this.actionSelectBtn.UseVisualStyleBackColor = false;
            this.actionSelectBtn.Visible = false;
            this.actionSelectBtn.Click += new System.EventHandler(this.actionSelectBtn_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cancel.Location = new System.Drawing.Point(405, 418);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 29;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Visible = false;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // songsCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.actionSelectBtn);
            this.Controls.Add(this.songListBox);
            this.Controls.Add(this.volumeLbl);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.SearchResult);
            this.Controls.Add(this.backgroundCopy);
            this.Controls.Add(this.currentPosition);
            this.Controls.Add(this.searchlbl);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.search);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.pathlbl);
            this.Controls.Add(this.albumPicture);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.next);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.play);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nowPlaying);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.multipleListBoxLbl);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "songsCheckList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Osu Music";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.timeLeft)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nowPlaying;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.PictureBox albumPicture;
        private System.Windows.Forms.Label pathlbl;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TrackBar timeLeft;
        private System.Windows.Forms.Label currentPosition;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOSUSongsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractPlayingMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractAllMusicToolStripMenuItem;
        private System.Windows.Forms.Label backgroundCopy;
        private System.Windows.Forms.ListBox SearchResult;
        private System.Windows.Forms.ToolStripMenuItem extractAlbumPictureToolStripMenuItem;
        private System.Windows.Forms.TrackBar volume;
        private System.Windows.Forms.Label volumeLbl;
        private System.Windows.Forms.ToolStripMenuItem setAlbumPictureAsWallpaperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSongToPlaylistToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox songListBox;
        private System.Windows.Forms.Label multipleListBoxLbl;
        private System.Windows.Forms.Button actionSelectBtn;
        private System.Windows.Forms.Button cancel;
    }
}

