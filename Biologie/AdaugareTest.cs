﻿
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
                var query = from x in db.Questions select x;
                foreach (var x in query)
                {
                    checkedListBox1.Items.Add(x.Id + "\t" + x.Level + " \t       " + x.QuestionText);
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
                var query = from x in db.Tests select x;
                foreach (var x in query)
                {
                    comboBox1.Items.Add(x.Name);
                }
            }
            comboBox1.Items.Add("Test Nou");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Question> Questions = new List<Question>();
            using (var db = new EntityFBio())
            {
                var query = db.Tests.Where(x => x.Name == comboBox1.SelectedItem.ToString());
                foreach (var x in query)
                    if (faraEnunturi(x))
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.GetItemChecked(i))
                            {
                                char delimiter = '\t';
                                string[] words = checkedListBox1.Items[i].ToString().Split(delimiter);
                                Question en = db.Questions.FirstOrDefault(s => s.Id.ToString().Equals(words[0]));
                                Questions.Add(en);
                            }
                        }
                        foreach (var y in Questions)
                        {
                            db.QuestionTests.Add(new QuestionTest { QuestionId = y.Id, TestId = x.Id });
                        }

                        MessageBox.Show("Au fost adaugate enunturile in baza de date.");
                    }
                    else
                    {
                        string enunturile = "";
                        foreach (var xy in x.Questions)
                        {
                            enunturile += xy.QuestionText + ", ";
                        }
                        string enunturiExistente = "";
                        char[] delimiterChar = { ',', ' ' };
                        string[] words = enunturile.Split(delimiterChar);
                        foreach (string s in words)
                        {
                            var qn = db.Questions.Where(c => c.Id.ToString() == s).Select(c => c);
                            foreach (var y in qn)
                            { enunturiExistente += y.QuestionText + "\n"; }
                        }

                        DialogResult box = MessageBox.Show("Testul contine deja urmatoarele enunturi. Doriti sa le stergeti - YES? Doriti sa le suprascrieti? - NO\n" + enunturiExistente, "INFO", MessageBoxButtons.YesNo);
                        if (box == DialogResult.Yes)
                        {
                            //stergeEnunturi
                            clearTest(x);
                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
                                if (checkedListBox1.GetItemChecked(i))
                                {
                                    char delimiter = '\t';
                                    string[] word = checkedListBox1.Items[i].ToString().Split(delimiter);
                                    Question enunt = db.Questions.FirstOrDefault(s => s.Id.ToString().Equals(word[0]));
                                    Questions.Add(enunt);
                                }
                                foreach (var y in Questions)
                                {
                                    db.QuestionTests.Add(new QuestionTest { QuestionId = y.Id, TestId = x.Id });
                                }

                            }
                            MessageBox.Show("Au fost adaugate enunturile in baza de date");
                        }
                        else
                        {
                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
                                if (checkedListBox1.GetItemChecked(i))
                                {
                                    char delimiter = '\t';
                                    string[] word = checkedListBox1.Items[i].ToString().Split(delimiter);
                                    Question enunt = db.Questions.FirstOrDefault(s => s.Id.ToString().Equals(word[0]));
                                    Questions.Add(enunt);
                                }
                                foreach (var y in Questions)
                                {
                                    db.QuestionTests.Add(new QuestionTest { QuestionId = y.Id, TestId = x.Id });
                                }

                            }
                            MessageBox.Show("Au fost adaugate enunturile in baza de date");
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
        public bool faraEnunturi(Test test)
        {
            using (var db = new EntityFBio())
            {
                int x = db.QuestionTests.Where(s => s.TestId == test.Id).Select(s => s.Id).FirstOrDefault();
                return (x > 0) ? true : false;
            }
            return false;
        }
        public List<Question> getQuestions(Test test)
        {
            List<Question> Questions = new List<Question>();
            using (EntityFBio db = new EntityFBio())
            {
                var QuestionsTests = db.QuestionTests.Where(s => s.TestId == test.Id).Select(s => s);
                foreach (var x in QuestionsTests)
                {
                    Questions.Add(db.Questions.FirstOrDefault(s => s.Id == x.QuestionId));
                }
            }
            return Questions;
        }
        public bool clearTest(Test test)
        {
            using (var db = new EntityFBio())
            {
                var query = db.QuestionTests.Where(s => s.TestId == test.Id).Select(s => s);
                foreach (var x in query)
                {
                    db.QuestionTests.Remove(x);
                }
                db.SaveChanges();
            }
        }
    }
}
 
