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
using System.Data.EntityClient;



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

        }
    }
}
