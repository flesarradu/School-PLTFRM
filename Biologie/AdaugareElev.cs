using Biologie.EntityFramework;
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
    public partial class AdaugareElev : Form
    {
        public AdaugareElev()
        {
            InitializeComponent();
            using (var db = new EntityFBio())
            {
                foreach(var x in db.Classes)
                {
                    if(x.ClassName!="Admin")
                        comboBox1.Items.Add(x.ClassName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text, parola = textBox2.Text;
            int clasa=0;
            if (checkBox1.Checked)
               clasa = 1;
            using(var db = new EntityFBio())
            {
                clasa = db.Classes.Where(s => s.ClassName == comboBox1.SelectedItem.ToString()).FirstOrDefault().Id;
            }
            FunctiiPublice login = new FunctiiPublice();
            login.adaugaCont(username, parola, clasa);
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(70, 177, 53, 12);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font, FontStyle.Regular);
            label5.ForeColor = Color.FromArgb(250, 242, 200);
        }
    }
}
