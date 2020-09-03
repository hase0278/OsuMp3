namespace OsuMp3
{
    partial class CreatePlaylist
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
            this.playlistName = new System.Windows.Forms.TextBox();
            this.createPlaylistBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playlistName
            // 
            this.playlistName.Location = new System.Drawing.Point(56, 105);
            this.playlistName.Name = "playlistName";
            this.playlistName.Size = new System.Drawing.Size(254, 20);
            this.playlistName.TabIndex = 0;
            // 
            // createPlaylistBtn
            // 
            this.createPlaylistBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.createPlaylistBtn.Location = new System.Drawing.Point(137, 143);
            this.createPlaylistBtn.Name = "createPlaylistBtn";
            this.createPlaylistBtn.Size = new System.Drawing.Size(85, 23);
            this.createPlaylistBtn.TabIndex = 1;
            this.createPlaylistBtn.Text = "Create Playlist";
            this.createPlaylistBtn.UseVisualStyleBackColor = false;
            this.createPlaylistBtn.Click += new System.EventHandler(this.createPlaylistBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(53, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter your playlist\'s name:";
            // 
            // CreatePlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(392, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createPlaylistBtn);
            this.Controls.Add(this.playlistName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(408, 245);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(408, 245);
            this.Name = "CreatePlaylist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Osu Music";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox playlistName;
        private System.Windows.Forms.Button createPlaylistBtn;
        private System.Windows.Forms.Label label1;
    }
}