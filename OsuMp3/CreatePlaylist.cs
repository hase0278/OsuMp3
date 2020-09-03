using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if(!File.Exists(Application.StartupPath + @"\" + playlistName.Text + ".ompl"))
            {
                File.Create(Application.StartupPath + @"\" + playlistName.Text + ".ompl");
                MessageBox.Show("Playlist created.", "Osu Music");
                Form1 osuMain = new Form1();
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
