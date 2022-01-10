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
    public partial class VizualizareRezultate : Form
    {
        public VizualizareRezultate()
        {
            InitializeComponent();
            
            fetchComboBox();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "Toate")
            {
                using (var db = new MapProjectDatabaseEntities())
                {
                    int classId = db.Classes.Where(s => s.ClassName == comboBox1.SelectedItem.ToString()).FirstOrDefault().Id;
                    populateList(classId);
                }
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Nume\t\tTest\t\tPunctaj");
                string Mark = "";
                string Test = "";
                string User = "";
                using (var db = new MapProjectDatabaseEntities())
                {
                    foreach (var x in db.Results)
                    {
                        AccountTest accountTest = db.AccountTests.Where(s => s.Id == x.AccountTestId).Select(s => s).FirstOrDefault();
                        User = accountTest.Account.User;
                        Test = accountTest.Test.Name;
                        Mark = x.Mark.ToString();
                        listBox1.Items.Add(User + "\t\t" + Test + "\t\t" + Mark);
                    }
                }
            }

        }

        private void populateList(int classId)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Nume\t\tTest\t\tPunctaj");
            string Mark = "";
            string Test = "";
            string User = "";
            using (var db = new MapProjectDatabaseEntities())
            {
                foreach(var x in db.Results)
                {
                    AccountTest accountTest = db.AccountTests.Where(s => s.Id == x.AccountTestId).Select(s => s).FirstOrDefault();
                    User = accountTest.Account.User;
                    Test = accountTest.Test.Name;
                    Mark = x.Mark.ToString();
                    if (accountTest.Account.ClassId == classId)
                        listBox1.Items.Add(User + "\t\t" + Test + "\t\t" + Mark);
                }
            }
        }

        private void fetchComboBox()
        {
            comboBox1.Items.Add("Toate");
            using(var db = new MapProjectDatabaseEntities())
            {
                foreach(var x in db.Classes)
                {
                    if (x.ClassName != "Admin") { comboBox1.Items.Add(x.ClassName);  }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
