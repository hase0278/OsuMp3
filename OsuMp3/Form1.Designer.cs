namespace OsuMp3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nowPlaying = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.albumPicture = new System.Windows.Forms.PictureBox();
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
            this.backgroundCopy = new System.Windows.Forms.Label();
            this.SearchResult = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.albumPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeLeft)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nowPlaying
            // 
            this.nowPlaying.BackColor = System.Drawing.SystemColors.ScrollBar;
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
            this.label1.Location = new System.Drawing.Point(32, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Now Playing";
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.play.ForeColor = System.Drawing.SystemColors.Menu;
            this.play.Location = new System.Drawing.Point(366, 364);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(75, 23);
            this.play.TabIndex = 3;
            this.play.Text = "Play";
            this.play.UseVisualStyleBackColor = false;
            this.play.Click += new System.EventHandler(this.Play_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.stop.ForeColor = System.Drawing.SystemColors.Menu;
            this.stop.Location = new System.Drawing.Point(366, 393);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 5;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.next.ForeColor = System.Drawing.SystemColors.Menu;
            this.next.Location = new System.Drawing.Point(493, 364);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 6;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // previous
            // 
            this.previous.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.previous.ForeColor = System.Drawing.SystemColors.Menu;
            this.previous.Location = new System.Drawing.Point(229, 364);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(75, 23);
            this.previous.TabIndex = 7;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = false;
            this.previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // albumPicture
            // 
            this.albumPicture.Image = global::OsuMp3.Properties.Resources.circles;
            this.albumPicture.Location = new System.Drawing.Point(35, 61);
            this.albumPicture.Name = "albumPicture";
            this.albumPicture.Size = new System.Drawing.Size(719, 225);
            this.albumPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumPicture.TabIndex = 10;
            this.albumPicture.TabStop = false;
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
            this.searchlbl.Location = new System.Drawing.Point(-1, 42);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(75, 13);
            this.searchlbl.TabIndex = 17;
            this.searchlbl.Text = "Search Music:";
            this.searchlbl.Visible = false;
            // 
            // timeLeft
            // 
            this.timeLeft.Location = new System.Drawing.Point(58, 333);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(702, 45);
            this.timeLeft.TabIndex = 19;
            this.timeLeft.Scroll += new System.EventHandler(this.TimeLeft_Scroll);
            // 
            // currentPosition
            // 
            this.currentPosition.AutoSize = true;
            this.currentPosition.Location = new System.Drawing.Point(31, 338);
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.Size = new System.Drawing.Size(34, 13);
            this.currentPosition.TabIndex = 20;
            this.currentPosition.Text = "00:00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
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
            this.extractAllMusicToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // setOSUSongsFolderToolStripMenuItem
            // 
            this.setOSUSongsFolderToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.setOSUSongsFolderToolStripMenuItem.Name = "setOSUSongsFolderToolStripMenuItem";
            this.setOSUSongsFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.setOSUSongsFolderToolStripMenuItem.Text = "Set OSU Songs Folder";
            this.setOSUSongsFolderToolStripMenuItem.Click += new System.EventHandler(this.SetOsuSongsFolderToolStripMenuItem_Click);
            // 
            // extractPlayingMusicToolStripMenuItem
            // 
            this.extractPlayingMusicToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.extractPlayingMusicToolStripMenuItem.Name = "extractPlayingMusicToolStripMenuItem";
            this.extractPlayingMusicToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractPlayingMusicToolStripMenuItem.Text = "Extract Playing Music";
            this.extractPlayingMusicToolStripMenuItem.Click += new System.EventHandler(this.ExtractPlayingMusicToolStripMenuItem_Click);
            // 
            // extractAllMusicToolStripMenuItem
            // 
            this.extractAllMusicToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.extractAllMusicToolStripMenuItem.Name = "extractAllMusicToolStripMenuItem";
            this.extractAllMusicToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractAllMusicToolStripMenuItem.Text = "Extract All Music";
            this.extractAllMusicToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllMusicToolStripMenuItem_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Osu Music";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.albumPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeLeft)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

