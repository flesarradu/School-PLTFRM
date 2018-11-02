using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biologie
{
    public partial class VizualizeazaImagine : Form
    {
        public string Url { get; set; }
        public Testare Ownerr  { get; set; }
        public VizualizeazaImagine(string ureleu)
        {
            InitializeComponent();
            Url = ureleu;
            Activate();
            WindowState = FormWindowState.Normal;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            pictureBox1.ImageLocation = Url;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VizualizeazaImagine_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ownerr.Enabled = true;
            Ownerr.Show();
        }

        private void VizualizeazaImagine_Load(object sender, EventArgs e)
        {
            Ownerr.Enabled = false;
            Ownerr.Hide();
        }
    }
}
