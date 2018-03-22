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
    public partial class MeniuProfesor : Form
    {
        public MeniuProfesor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdaugareElev visa = new AdaugareElev();
            Hide();
            visa.Closed += (s, args) => Show();
            visa.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaugareTest visa = new AdaugareTest();
            Hide();
            visa.Closed += (s, args) => Show();
            visa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminTeste visa = new AdminTeste();
            Hide();
            visa.Closed += (s, args) => Show();
            visa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdaugareEnunt visa = new AdaugareEnunt();
            Hide();
            visa.Closed += (s, args) => Show();
            visa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VizualizareRezultate visa = new VizualizareRezultate();
            Hide();
            visa.FormClosed += (s, args) => Show();
            visa.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal|| this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Minimized;
            
        }
    }
}
