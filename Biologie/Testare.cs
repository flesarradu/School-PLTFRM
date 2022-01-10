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
        bool exersare = false;
        int corecte = 0;
        int numarEnunturi = 0;
        int numarRaspunse = 0;
        int[] raspunse = new int[200];
        int lastID = 0;
        int abandon = 0;
        Label cerinta = new Label();
        Test Test = new Test();
        List<Question> Questions = new List<Question>();
        RadioButton[] checkboxs = new RadioButton[4];
        RadioButton[] radioButtonsImg = new RadioButton[4];
        TextBox campRaspuns = new TextBox();
        Button butonRaspuns = new Button();
        Button butonRaspuns1 = new Button();
        Button butonRaspuns2 = new Button();
        Account User = new Account();
        FunctiiPublice functii = new FunctiiPublice();
        PictureBox[] pictureBoxes = new PictureBox[4];
        public Testare(string user, string tes, bool exersareB)
       {    
            
            InitializeComponent();
            test = tes;
            u = user;
            exersare = exersareB;
            using (var db = new MapProjectDatabaseEntities())
            {
                Test = db.Tests.FirstOrDefault(s => s.Name == tes);
                Questions = functii.getQuestions(Test);
                User = db.Accounts.FirstOrDefault(s => s.User == u);
            }

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;

            numarEnunturi = Questions.Count;
            for (int i = 0; i < 200; i++)
            {
                raspunse[i] = 0;
            }
            //BUTOANE
            int yx = 70, xy = 350;
            butonRaspuns1.Parent = this;
            butonRaspuns2.Parent = this;
            butonRaspuns1.Location = new Point(1263, 780);
            butonRaspuns2.Location = new Point(1263, 780);
            butonRaspuns1.Size = new Size(250, 65);
            butonRaspuns2.Size = new Size(250, 65);
            butonRaspuns1.Anchor = AnchorStyles.Right;
            butonRaspuns2.Anchor = AnchorStyles.Right;
            butonRaspuns1.Font = labelCerinta.Font;
            butonRaspuns2.Font = labelCerinta.Font;
            butonRaspuns1.Font = new Font(butonRaspuns1.Font.FontFamily, 20);
            butonRaspuns2.Font = new Font(butonRaspuns2.Font.FontFamily, 20);
            butonRaspuns1.Text = "Raspunde";
            butonRaspuns2.Text = "Raspunde";
            butonRaspuns1.ForeColor = Color.FromArgb(250, 242, 200);
            butonRaspuns2.ForeColor = Color.FromArgb(245, 142, 107);
            butonRaspuns2.Click += (s, args) => {
                for (int i = 0; i < 4; i++)
                {
                    if (radioButtonsImg[i].Checked)
                    {
                        if (pictureBoxes[i].ImageLocation == Questions[lastID].Answer)
                        {
                            corecte++;
                        }
                        radioButtonsImg[i].Checked = false;
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
            butonRaspuns.Location = new Point(1263, 780);
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
            butonRaspuns2.Update();
            for (int i=0;i<4;i++)
            {
                checkboxs[i] = new RadioButton();
                checkboxs[i].Parent = this;
                checkboxs[i].Size = new Size(1650, 55);
                checkboxs[i].Location = new Point(yx, xy += 70);
                //tableLayoutPanel1.Controls.Add(checkboxs[i], 0, i+1);
                checkboxs[i].Anchor = AnchorStyles.Left;
                checkboxs[i].Margin = margin;
                checkboxs[i].Update();
            }
            yx = -75;
            xy = 600;
            for (int i = 0; i < 4; i++)
            {
                radioButtonsImg[i] = new RadioButton
                {
                    Parent = this,
                    Size = new Size(55, 55),
                    Location = new Point(yx += 325, xy),
                    //tableLayoutPanel1.Controls.Add(radioButtonsImg[i], i+1, 1);
                    Text = (i + 1).ToString()
                };
                radioButtonsImg[i].Anchor = AnchorStyles.Left;
                radioButtonsImg[i].Margin = margin;
                radioButtonsImg[i].Update();
            }
            xy = 300; yx = -190;
            for(int i = 0; i < 4; i++)
            {
                pictureBoxes[i] = new PictureBox
                {
                    Parent = this,
                    Size = new Size(275, 275),
                    Location = new Point(yx += 325, xy),
                    ImageLocation = "",
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                pictureBoxes[i].Anchor = AnchorStyles.Left;
                pictureBoxes[i].Margin = margin;
                pictureBoxes[i].Update();
                
            }
            pictureBoxes[0].Click += (s, args) => { VizualizeazaImagine vizualizeazaImagine = new VizualizeazaImagine(pictureBoxes[0].ImageLocation);
                vizualizeazaImagine.Ownerr = this;
                vizualizeazaImagine.Show(); 
                vizualizeazaImagine.FormClosed += (s1, args2) => { Activate(); };
            };
            pictureBoxes[1].Click += (s, args) => {
                VizualizeazaImagine vizualizeazaImagine = new VizualizeazaImagine(pictureBoxes[1].ImageLocation);
                vizualizeazaImagine.Ownerr = this;
                vizualizeazaImagine.Show();
                vizualizeazaImagine.FormClosed += (s1, args2) => { Activate(); };
            };
            pictureBoxes[2].Click += (s, args) => {
                VizualizeazaImagine vizualizeazaImagine = new VizualizeazaImagine(pictureBoxes[2].ImageLocation);
                vizualizeazaImagine.Ownerr = this;
                vizualizeazaImagine.Show();
                vizualizeazaImagine.FormClosed += (s1, args2) => { Activate(); };
            };
            pictureBoxes[3].Click += (s, args) => {
                VizualizeazaImagine vizualizeazaImagine = new VizualizeazaImagine(pictureBoxes[3].ImageLocation);
                vizualizeazaImagine.Ownerr = this;
                vizualizeazaImagine.Show();
                vizualizeazaImagine.FormClosed += (s1, args2) => { Activate(); };
            };

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
                        checkboxs[i].Checked = false;
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


            if (Questions[id].Type == 1)
                afiseazaEnunt1(Questions[id].QuestionText, Questions[id].Answer);
            else if (Questions[id].Type == 0)
                afiseazaEnunt0(Questions[id].QuestionText, Questions[id].Answer, Questions[id].choice1, Questions[id].choice2, Questions[id].choice3, Questions[id].choice4);
            else if (Questions[id].Type == 2) afiseazaEnunt2(Questions[id].QuestionText, Questions[id].Answer, Questions[id].choice1, Questions[id].choice2, Questions[id].choice3, Questions[id].choice4);
            
        }
        
        private void afiseazaEnunt1(string enunt, string raspuns)
        {
            //tableLayoutPanel1.Show();
            //tableLayoutPanel1.Controls.Remove(butonRaspuns);
            butonRaspuns.Hide();
            butonRaspuns2.Hide();
            //tableLayoutPanel1.Controls.Add(butonRaspuns1, 0, 5);
            for (int i=0;i<4;i++)
            {
                checkboxs[i].Hide();
                radioButtonsImg[i].Hide();
                pictureBoxes[i].Hide();
            }
            labelCerinta.Text = enunt;
            //tableLayoutPanel1.Controls.Remove(checkboxs[1]);
            //Camp de Raspuns

            //tableLayoutPanel1.Controls.Add(campRaspuns, 0, 2);
            campRaspuns.Show();

            //Buton raspuns

            butonRaspuns1.Show();
            
        }
        private void finalizareTest()
        {
            using (var db = new MapProjectDatabaseEntities())
            {
                double punctaj = 90.0 / numarEnunturi;
                decimal rezultatul = (decimal) punctaj * corecte + 10;
                rezultatul = Math.Round(rezultatul, 2);
                if (!exersare)
                {
                    AccountTest accountTest = new AccountTest();
                    accountTest.UserId = User.Id;
                    accountTest.TestId = Test.Id;
                    db.AccountTests.Add(accountTest);
                    db.SaveChanges();

                    db.Results.Add(new Result { Mark = rezultatul, AccountTestId = accountTest.Id });
                    db.SaveChanges();
                }
                MessageBox.Show("Rezultat: " + rezultatul + " puncte");
            }
            abandon = 1;
        }
        private void afiseazaEnunt0(string enunt, string raspuns, string v1, string v2, string v3, string v4)
        {
            //tableLayoutPanel1.Controls.Remove(campRaspuns);
            campRaspuns.Hide();
            //tableLayoutPanel1.Controls.Remove(butonRaspuns1);
            butonRaspuns1.Hide();
            butonRaspuns2.Hide();
            //tableLayoutPanel1.Controls.Add(butonRaspuns, 0, 5);
            //tableLayoutPanel1.Controls.Add(checkboxs[1], 0, 2);
            labelCerinta.Text = enunt;
            butonRaspuns.Show();
            //Checkbox Variante           
            for (int i = 0; i < 4; i++)
            { 
                checkboxs[i].Show();
                radioButtonsImg[i].Hide();
                pictureBoxes[i].Hide();
            }
            checkboxs[0].Text = v1;
            checkboxs[1].Text = v2;
            checkboxs[2].Text = v3;
            checkboxs[3].Text = v4;          
        }
        private void afiseazaEnunt2(string enunt, string raspuns, string v1, string v2, string v3, string v4)
        {
            //tableLayoutPanel1.Hide();
            //tableLayoutPanel1.Controls.Remove(campRaspuns);
            //tableLayoutPanel1.Enabled = false;
            campRaspuns.Hide();
            //tableLayoutPanel1.Controls.Remove(butonRaspuns1);
            butonRaspuns1.Hide();
            butonRaspuns.Hide();
            butonRaspuns2.Show();
            //Checkbox Variante           
            for (int i = 0; i < 4; i++)
            {
                radioButtonsImg[i].Show();
                checkboxs[i].Hide();
            }
            pictureBoxes[0].ImageLocation = v1;
            pictureBoxes[1].ImageLocation = v2;
            pictureBoxes[2].ImageLocation = v3;
            pictureBoxes[3].ImageLocation = v4;

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
            return lastID;
           
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
