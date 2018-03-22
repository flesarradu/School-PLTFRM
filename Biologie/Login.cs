using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Biologie
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            FunctiiPublice login = new FunctiiPublice();
            if (login.verificaCont(textBox1.Text, textBox2.Text))
                if (login.isAdmin(textBox1.Text))
                {
                    MeniuProfesor visa = new MeniuProfesor();
                    Hide();
                    visa.Closed += (s, args) => Close();
                    visa.Show();
                }
                else
                {
                    MeniuElev visa = new MeniuElev(textBox1.Text);
                    Hide();
                    visa.Closed += (s, args) => Close();
                    visa.Show();
                }

            else
                MessageBox.Show("User/Parola gresite");
            

            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.BackColor = this.BackColor;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
            panel3.Hide();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel3.Hide();
                button1_Click_1(sender, e);
            }
        }
    }
}
