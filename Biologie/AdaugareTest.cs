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
    public partial class AdaugareTest : Form
    {
        Button adaugare = new Button();
        FunctiiPublice functii = new FunctiiPublice();

        public AdaugareTest()
        {
            InitializeComponent();
            fetchComboBox2();
            checkedListBox1.Items.Add("ID   Nivel \t Enunt");
            afiseazaEnunturi();
        }

        private void afiseazaEnunturi()
        {
            using (var db = new EntityFBio())
            {
                var query = from x in db.enunturi select x;
                foreach (var x in query)
                {
                    checkedListBox1.Items.Add(x.id + "\t" + x.dificultate + " \t       " + x.enunt);
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Test Nou")
            {
                buttonCreator("Adaugare", 445, 10, 150, 50);
            }
            else
            {
                adaugare.Hide();
            }
        }
        private void buttonCreator(string text, int x, int y, int w, int h)
        {
            adaugare.Location = new System.Drawing.Point(x, y);
            adaugare.Parent = this;
            adaugare.Text = text;
            adaugare.Size = new System.Drawing.Size(w, h);
            tableLayoutPanel2.Controls.Add(adaugare, 3, 0);
            adaugare.Font = comboBox1.Font;
            adaugare.ForeColor = comboBox1.ForeColor;
            adaugare.Anchor = AnchorStyles.Left;
            
            adaugare.Name = "adaugare";
            adaugare.Click += (s, e) =>
            {
                functii.adaugaTest(comboBox1.Text);
                fetchComboBox2();
            };
            adaugare.Show();
        }

        private void fetchComboBox2()
        {
            using (var db = new EntityFBio())
            {
                var query = from x in db.teste select x;
                foreach (var x in query)
                {
                    comboBox1.Items.Add(x.nume);
                }
            }
            comboBox1.Items.Add("Test Nou");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EntityFBio())
            {
                var query = db.teste.Where(x => x.nume == comboBox1.SelectedItem.ToString());
                string enunturiExistente = "";
                foreach (var x in query)
                    if (x.enunturi == "" || x.enunturi == null)
                    {                     
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.GetItemChecked(i))
                            {
                                char delimiter = '\t';
                                string[] words = checkedListBox1.Items[i].ToString().Split(delimiter);
                                if (i + 1 == checkedListBox1.Items.Count)
                                    x.enunturi += words[0];
                                else
                                    x.enunturi += words[0] + ",";
                                
                            }
                        }
                        MessageBox.Show("Au fost adaugate enunturile cu id:" + x.enunturi);
                    }
                    else
                    {
                        string enunturile = x.enunturi;
                        char[] delimiterChar = { ',', ' ' };
                        string[] words = enunturile.Split(delimiterChar);
                        foreach (string s in words)
                        {
                            var qn = db.enunturi.Where(c => c.id.ToString() == s).Select(c => c);
                            foreach (var y in qn)
                            { enunturiExistente += y.enunt + "\n"; }
                        }

                        DialogResult box = MessageBox.Show("Testul contine deja urmatoarele enunturi. Doriti sa le stergeti - YES? Doriti sa le suprascrieti? - NO\n" + enunturiExistente, "INFO", MessageBoxButtons.YesNo);
                        if (box == DialogResult.Yes)
                        {
                            x.enunturi = "";
                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
                                if (checkedListBox1.GetItemChecked(i))
                                {
                                    char delimiter = '\t';
                                    string[] word = checkedListBox1.Items[i].ToString().Split(delimiter);
                                    if (i + 1 == checkedListBox1.Items.Count)
                                        x.enunturi += word[0];
                                    else
                                        x.enunturi += word[0] + ",";
                                }

                            }
                            MessageBox.Show("Au fost adaugate enunturile cu id:" + x.enunturi);
                        }
                        else
                        {
                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
                                if (checkedListBox1.GetItemChecked(i))
                                {
                                    char delimiter = '\t';
                                    string[] word = checkedListBox1.Items[i].ToString().Split(delimiter);
                                    if (i + 1 == checkedListBox1.Items.Count)
                                        x.enunturi += word[0];
                                    else
                                        x.enunturi += word[0] + ",";

                                }

                            }
                            MessageBox.Show("Au fost adaugate enunturile cu id:" + x.enunturi);
                        }
                    }
                db.SaveChanges();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
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
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Minimized;
        }
    }
}
 
