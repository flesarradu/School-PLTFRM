using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using Biologie.EntityFramework;

namespace Biologie
{
    public partial class Testare : Form
    {
        string test="";
        string u = "";
        int corecte = 0;
        int numarEnunturi = 0;
        int numarRaspunse = 0;
        int[] raspunse = new int[200];
        int lastID = 0;
        int abandon = 0;
        Label cerinta = new Label();
        Test Test = new Test();
        List<Question> Questions = new List<Question>();
        CheckBox[] checkboxs = new CheckBox[4];
        TextBox campRaspuns = new TextBox();
        Button butonRaspuns = new Button();
        Button butonRaspuns1 = new Button();
        Account User = new Account();
        FunctiiPublice functii = new FunctiiPublice();
      
        public Testare(string user, string tes)
       {    
            
            InitializeComponent();
            test = tes;
            u = user;

            using (var db = new EntityFBio())
            {
                Test = db.Tests.FirstOrDefault(s => s.Name == tes);
                Questions = functii.getQuestions(Test);
                User = db.Accounts.FirstOrDefault(s => s.User == u);
            }
            for (int i = 0; i < 200; i++)
            {
                raspunse[i] = 0;
            }
            //BUTOANE
            int yx = 70, xy = 350;
            butonRaspuns1.Parent = this;
            butonRaspuns1.Location = new Point(1463, 801);
            butonRaspuns1.Size = new Size(250, 65);
            butonRaspuns1.Anchor = AnchorStyles.Right;
            butonRaspuns1.Font = labelCerinta.Font;
            butonRaspuns1.Font = new Font(butonRaspuns1.Font.FontFamily, 20);
            butonRaspuns1.Text = "Raspunde";
            butonRaspuns1.ForeColor = Color.FromArgb(250, 242, 200);
            campRaspuns.Parent = this;
            campRaspuns.Text = "";
            campRaspuns.Location = new Point(25, 400);
            campRaspuns.Anchor = AnchorStyles.Left;
            campRaspuns.Font = labelCerinta.Font;
            campRaspuns.Font = new Font(campRaspuns.Font.FontFamily, 20);
            campRaspuns.Size = new Size(470, 61);
            campRaspuns.BackColor = Color.FromArgb(199, 209, 175);
            campRaspuns.ForeColor = Color.FromArgb(245, 142, 107);
            butonRaspuns.Parent = this;
            butonRaspuns.Location = new Point(1463, 801);
            butonRaspuns.Size = new Size(250, 65);
            butonRaspuns.Anchor = AnchorStyles.Right;
            butonRaspuns1.Font = labelCerinta.Font;
            butonRaspuns1.Font = new Font(butonRaspuns1.Font.FontFamily, 20);
            butonRaspuns.Text = "Raspunde";
            butonRaspuns.ForeColor = butonRaspuns1.ForeColor;
            var margin = butonRaspuns1.Margin;
            margin.Left = 50;
            margin.Right = 50;
            
            butonRaspuns.ForeColor = Color.FromArgb(245, 142, 107);
          
            butonRaspuns1.ForeColor = Color.FromArgb(245, 142, 107);
            butonRaspuns1.Margin = margin;
            butonRaspuns.Margin = margin;
            campRaspuns.Margin = margin;
            campRaspuns.Update();
            butonRaspuns.Update();
            butonRaspuns1.Update();
            for (int i=0;i<4;i++)
            {
                checkboxs[i] = new CheckBox();
                checkboxs[i].Parent = this;
                checkboxs[i].Size = new Size(1650, 55);
                checkboxs[i].Location = new Point(yx, xy += 70);
                tableLayoutPanel1.Controls.Add(checkboxs[i], 0, i+1);
                checkboxs[i].Anchor = AnchorStyles.Left;
                checkboxs[i].Margin = margin;
                checkboxs[i].Update();
            }

            WindowState = FormWindowState.Normal;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            Activate();
            butonRaspuns.Click += (s, args) => {
                
                for (int i = 0; i < 4; i++)
                {
                    if (checkboxs[i].Checked)
                    {
                        if (checkboxs[i].Text.ToLower() == Questions[lastID].Answer.ToLower())
                        {
                            corecte++;                           
                        }
                        checkboxs[i].CheckState = CheckState.Unchecked;
                        numarRaspunse++;
                        Questions[lastID].Answered = true;
                        if (numarRaspunse < numarEnunturi)
                        {   
                           // afiseazaEnunt(Enunturi[numarRaspunse++].id);
                            afiseazaEnunt(getID());
                        }
                        else
                        {
                            DialogResult rez = MessageBox.Show("Doriti sa incheiati testul?", "Confirm", MessageBoxButtons.YesNoCancel);
                            if (rez == DialogResult.Yes)
                            {
                                finalizareTest();
                                Close();
                            }
                        }

                    }
                }

            };
            butonRaspuns1.Click += (s, args) =>
            { 
                butonRaspuns.Hide();
                campRaspuns.Hide();
                if (campRaspuns.Text.ToLower() == Questions[lastID].Answer.ToLower())
                {
                    corecte++;
                }
                campRaspuns.Text = "";
                numarRaspunse++;
                Questions[lastID].Answered = true;
                if (numarRaspunse < numarEnunturi)
                {
                    
                    // afiseazaEnunt(Enunturi[numarRaspunse++].id);
                    afiseazaEnunt(getID());
                }

                else
                {
                    DialogResult rez = MessageBox.Show("Doriti sa incheiati testul?", "Confirm", MessageBoxButtons.YesNoCancel);
                    if (rez == DialogResult.Yes)
                    {
                        finalizareTest();
                        Close();
                    }
                }
            };
            // afiseazaEnunt(Enunturi[numarRaspunse++].id);
            afiseazaEnunt(getID());
            
            
        }

        private void Testare_Load(object sender, EventArgs e)
        {

        }
        private void afiseazaEnunt(int id)
        {
            foreach (var x in Questions)
            {
                if (x.Id == id)
                {
                    if (x.Type == 1)
                        afiseazaEnunt1(x.QuestionText, x.Answer);
                    else if (x.Type == 0)
                        afiseazaEnunt0(x.QuestionText, x.Answer, x.choice1, x.choice2, x.choice3, x.choice4);
                }
            }
        }
        
        private void afiseazaEnunt1(string enunt, string raspuns)
        {
            tableLayoutPanel1.Controls.Remove(butonRaspuns);
            butonRaspuns.Hide();
            tableLayoutPanel1.Controls.Add(butonRaspuns1, 0, 5);
            for (int i=0;i<4;i++)
            {
                checkboxs[i].Hide();
            }
            labelCerinta.Text = enunt;
            tableLayoutPanel1.Controls.Remove(checkboxs[1]);
            //Camp de Raspuns

            tableLayoutPanel1.Controls.Add(campRaspuns, 0, 2);
            campRaspuns.Show();

            //Buton raspuns

            butonRaspuns1.Show();
            
        }
        private void finalizareTest()
        {
            using (var db = new EntityFBio())
            {
                double punctaj = 90.0 / numarEnunturi;
                double rezultatul = punctaj * corecte + 10;
                rezultatul = Math.Round(rezultatul, 2);
                db.Results.Add(new Result { TestId = Test.Id, Mark = rezultatul, UserId = User.Id });
                db.SaveChanges();
                MessageBox.Show("Rezultat: " + rezultatul + " puncte");
            }
            abandon = 1;
        }
        private void afiseazaEnunt0(string enunt, string raspuns, string v1, string v2, string v3, string v4)
        {
            tableLayoutPanel1.Controls.Remove(campRaspuns);
            campRaspuns.Hide();
            tableLayoutPanel1.Controls.Remove(butonRaspuns1);
            butonRaspuns1.Hide();
            tableLayoutPanel1.Controls.Add(butonRaspuns, 0, 5);
            tableLayoutPanel1.Controls.Add(checkboxs[1], 0, 2);
            labelCerinta.Text = enunt;
            butonRaspuns.Show();
            //Checkbox Variante           
            for (int i = 0; i < 4; i++)
            { 
                checkboxs[i].Show();
            }
            checkboxs[0].Text = v1;
            checkboxs[1].Text = v2;
            checkboxs[2].Text = v3;
            checkboxs[3].Text = v4;          
        }
        private int getID()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int n=0;
            
            int[] vct = new int[200];
            for (int i = 0; i < numarEnunturi; i++)
                if (!Questions[i].Answered)
                {
                    vct[n++] = i;
                }
            int idNumber = 0;
            if (n > 1)
                idNumber = rand.Next(0, n - 1);
         
            lastID = vct[idNumber];
            return Questions[vct[idNumber]].Id;
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriti sa abandonati testul? \nRezultatul se va inregistra in server!", "Confirmare", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                finalizareTest();
                Application.Exit();
            }
           
        }

        private void Testare_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (abandon == 0)
                finalizareTest();            
        }
    }
}
