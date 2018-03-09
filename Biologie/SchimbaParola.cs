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
    public partial class SchimbaParola : Form
    {
        string utilizator;
        public SchimbaParola(string user)
        {
            InitializeComponent();
            utilizator = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FunctiiPublice visa = new FunctiiPublice();
            if (visa.verificaCont(utilizator, textBox2.Text))
            {
                if (textBox1.Text == textBox3.Text)
                {
                    visa.schimbaParola(utilizator, textBox3.Text);
                    MessageBox.Show("Parola a fost schimbata cu succes");
                    Close();
                }
                else
                    MessageBox.Show("Parolele nu corespund.");
            }
            else
                MessageBox.Show("Parola este incorecta!");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
