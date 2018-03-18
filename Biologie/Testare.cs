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


namespace Biologie
{
    public partial class Testare : Form
    {
        string test="";
        string u = "";
        int corecte = 0;
        int numarEnunturi = 0;
        int numarRaspunse = 0;
        int[] raspunse = new int[100];
        int lastID = 0;
        int abandon = 0;
       // Label cerinta = new Label();
        List<enunturi> Enunturi = new List<enunturi>();
        CheckBox[] labels = new CheckBox[4];
        TextBox campRaspuns = new TextBox();
        Button butonRaspuns = new Button();
        Button butonRaspuns1 = new Button();
      
        public Testare(string user, string tes)
       {    
            
            InitializeComponent();
            test = tes;
            u = user;
            for (int i = 0; i < 100; i++)
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
                labels[i] = new CheckBox();
                labels[i].Parent = this;
                labels[i].Size = new Size(1650, 55);
                labels[i].Location = new Point(yx, xy += 70);
                tableLayoutPanel1.Controls.Add(labels[i], 0, i+1);
                labels[i].Anchor = AnchorStyles.Left;
                labels[i].Margin = margin;
                labels[i].Update();
            }

             WindowState = FormWindowState.Normal;
             FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             Bounds = Screen.PrimaryScreen.Bounds;
             Activate();
            List<DataContracts.SqlModels.Test> enunturiTest = new List<DataContracts.SqlModels.Test>();
            using (var db = new EntityFBio())
            {   
                string enunturi = "";
                var query = from y in db.teste select y;
                foreach (var y in query)
                {
                    if (y.nume == tes)
                        enunturi = y.enunturi;
                }
                char[] delimiterChar = { ',', ' ' };
                string[] words = enunturi.Split(delimiterChar);
                foreach (string s in words)
                {
                    if (s != "")
                        enunturiTest.Add(new DataContracts.SqlModels.Test() { Id = Guid.NewGuid() });
                }

                foreach (var x in enunturiTest)
                {
                   // var q = from y in db.enunturi where y.id.Equals(x.enuntID) select y;
                  //  foreach (var z in q)
                  //  { 
                 //       Enunturi.Add(z);
                 //       Enunturi[numarEnunturi++].raspunsa=0;
                 //   }                
                }
            }
            butonRaspuns.Click += (s, args) => {
                
                for (int i = 0; i < 4; i++)
                {
                    if (labels[i].Checked)
                    {
                        if (labels[i].Text.ToLower() == Enunturi[lastID].raspuns.ToLower())
                        {
                            corecte++;
                            
                        }
                        labels[i].CheckState = CheckState.Unchecked;
                        numarRaspunse++;
                        Enunturi[lastID].raspunsa = 1;
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
                if (campRaspuns.Text.ToLower() == Enunturi[lastID].raspuns.ToLower())
                {
                    corecte++;
                }
                campRaspuns.Text = "";
                numarRaspunse++;
                Enunturi[lastID].raspunsa = 1;
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
            foreach(var x in Enunturi)
            {
                if(x.id == id)
                {
                    if (x.tip == 1)
                        afiseazaEnunt1(x.enunt, x.raspuns);
                    else if (x.tip == 0)
                        afiseazaEnunt0(x.enunt, x.raspuns, x.varianta1, x.varianta2, x.varianta3, x.varianta4);
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
                labels[i].Hide();
            }
            labelCerinta.Text = enunt;
            tableLayoutPanel1.Controls.Remove(labels[1]);
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
                var query = from x in db.rezultate select x;
                int ID = query.Max(x => x.id);
                double punctaj = 90.0/numarEnunturi;
                double rezultatul = punctaj * numarRaspunse + 10;
                rezultatul = Math.Round(rezultatul, 2);
                db.rezultate.Add(new rezultate { id = ID + 1, user = u, test = test, rezultat=rezultatul.ToString()  });
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
            tableLayoutPanel1.Controls.Add(labels[1], 0, 2);
            labelCerinta.Text = enunt;
            butonRaspuns.Show();
            //Checkbox Variante           
            for (int i = 0; i < 4; i++)
            { 
                labels[i].Show();
            }
            labels[0].Text = v1;
            labels[1].Text = v2;
            labels[2].Text = v3;
            labels[3].Text = v4;          
        }
        private int getID()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int n=0;
            
            int[] vct = new int[100];
            for(int i=0; i<numarEnunturi;i++)
                if(Enunturi[i].raspunsa==0)
                {
                    vct[n++] = i;
                }
            int idNumber = 0;
            if (n > 1)
                idNumber = rand.Next(0, n - 1);
         
            lastID = vct[idNumber];
            return Enunturi[vct[idNumber]].id;
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
