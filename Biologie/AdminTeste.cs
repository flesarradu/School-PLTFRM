using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biologie.EntityFramework;

namespace Biologie
{
    public partial class AdminTeste : Form
    {
        public AdminTeste()
        {
            InitializeComponent();

            using (var db = new EntityFBio())
            {
                foreach (var x in db.Tests)
                {
                    comboBox1.Items.Add(x.Name);
                }
                foreach (var x in db.Classes)
                {
                    if (x.ClassName != "Admin")
                        comboBox2.Items.Add(x.ClassName);
                }
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EntityFBio())
            {
                //var query = db.Tests.Where(x => x.Name == comboBox1.SelectedItem.ToString());
                //foreach (var x in query)
                //    x.ClassId = db.Classes.FirstOrDefault(y => y.ClassName == comboBox2.SelectedItem.ToString()).Id;

                var query = db.Classes.Where(x => x.ClassName == comboBox2.SelectedItem.ToString());
                foreach(var x in query)
                {
                    x.TestId = db.Tests.FirstOrDefault(y => y.Name == comboBox1.SelectedItem.ToString()).Id;
                }
                db.SaveChanges();
                MessageBox.Show("Testul a fost adaugat cu succes.");
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
