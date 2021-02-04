using System;
using System.IO;
using System.Windows.Forms;

namespace OsuMp3
{
    public partial class CreatePlaylist : Form
    {
        public CreatePlaylist()
        {
            InitializeComponent();
        }

        private void createPlaylistBtn_Click(object sender, EventArgs e)
        {
            if (playlistName.Text.ToLower().Contains("default") || playlistName.Text.ToLower().Contains("now playing"))
            {
                MessageBox.Show("Invalid name! Please choose another name!");
            }
            else if(!File.Exists(Application.StartupPath + @"\" + playlistName.Text + ".ompl"))
            {
                File.Create(Application.StartupPath + @"\" + playlistName.Text + ".ompl");
                MessageBox.Show("Playlist created.", "Osu Music");
                songsCheckList osuMain = new songsCheckList();
                osuMain.loadExistingPlaylist();
                this.Close();
            }
            else
            {
                MessageBox.Show("Playlist with same name exists.", "Osu Music");
            }
        }
    }
}
