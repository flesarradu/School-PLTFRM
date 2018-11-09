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
    public partial class AdaugareImagine : Form
    {

        public string ImageString { get; set; }

        string[] urls = new string[100];
        string[] names = new string[100];
        int k = 0;
        public AdaugareImagine(string image)
        {
            InitializeComponent();
            ImageString = "";
            pictureBox1.ImageLocation = image;
            comboBox1.Items.Add("Adauga Imagine Noua");
            fetchComboBox();
            button1.Hide();
            textBox2.Hide();
        }

        private void fetchComboBox()
        {
            using(var db = new EntityFBio())
            {
                foreach(var x in db.Images)
                {
                    comboBox1.Items.Add(x.Name);
                    urls[k] = x.Url;
                    names[k++] = x.Name;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { pictureBox1.ImageLocation = textBox1.Text.ToString(); ImageString = pictureBox1.ImageLocation; }
            finally { }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            ImageString = pictureBox1.ImageLocation.ToString();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EntityFBio())
            {
                DialogResult x = MessageBox.Show("Esti sigur ca doresti sa adaugi imaginea in baza de date?", "", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    EntityFramework.Image image = new EntityFramework.Image();
                    image.Url = pictureBox1.ImageLocation.ToString();
                    image.Name = textBox2.Text;
                    db.Images.Add(image);
                    if (db.SaveChanges() == 1)
                    {
                        MessageBox.Show("Imaginea a fost adaugata in baza de date");
                    }
                    else MessageBox.Show("Imaginea nu a fost adaugata in baza de date");
                }
                else MessageBox.Show("Imaginea nu a fost adaugata in baza de date");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Adauga Imagine Noua") { button1.Show(); textBox2.Show(); textBox1.Text = ""; textBox2.Text = "Nume"; }
            else
            {
                textBox2.Hide();
                button1.Hide();
                int i;
                for (i = 0; i < k; i++) if (names[i] == comboBox1.SelectedItem.ToString()) break;
                pictureBox1.ImageLocation = urls[i];
                textBox1.Text = urls[i];
            }
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
