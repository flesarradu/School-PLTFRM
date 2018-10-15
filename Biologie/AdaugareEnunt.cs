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
    public partial class AdaugareEnunt : Form
    {
        Label[] labels = new Label[4];
        TextBox[] textBoxs = new TextBox[4];
        RadioButton[] checkBoxs = new RadioButton[4];
        PictureBox[] pictureBoxes = new PictureBox[4];
        
        Button adaugare = new Button();
        FunctiiPublice functii = new FunctiiPublice();
        public AdaugareEnunt()
        {
            InitializeComponent();
            comboBox1.Items.Add("0");
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            
            label4.Hide();
            for (int i = 0; i < 4; i++)
            {
                labels[i] = new Label();
                textBoxs[i] = new TextBox();
                checkBoxs[i] = new RadioButton();
                pictureBoxes[i] = new PictureBox();
            }
            trackBar1.SetRange(1, 5);
            trackBar1.Hide();
            textBox1.MaxLength = 250;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = 95, y = 560, w = 42, h = 25;
                trackBar1.Show();
                label4.Show();
                if (comboBox1.SelectedItem.ToString() == "0")
                {
                    char subPCT = 'a';
                    for (int i = 0; i < 4; i++)
                    {
                        //Labels
                        labels[i].Location = new Point(x, y += 30);
                        labels[i].Size = new Size(w, h);
                        labels[i].Text = subPCT++ + ")";
                        labels[i].Font = comboBox1.Font; 
                        labels[i].Update();
                        labels[i].Parent = this;
                        labels[i].Anchor = AnchorStyles.Top;
                        labels[i].ForeColor = comboBox1.ForeColor;
                        labels[i].Show();
                        
                        this.Controls.Add(labels[i]);
                        //TextBoxes
                        textBoxs[i].Location = new Point(x + 50, y);
                        textBoxs[i].Size = new Size(290, 33);
                        textBoxs[i].Update();
                        textBoxs[i].Parent = this;
                        textBoxs[i].Font = new Font(comboBox1.Font, FontStyle.Regular);
                        textBoxs[i].Update();
                        textBoxs[i].ForeColor = comboBox1.ForeColor;
                        textBoxs[i].Anchor = AnchorStyles.Top;
                        textBoxs[i].Show();
                        
                        //CheckBoxes
                        checkBoxs[i].Location = new Point(x + 350, y);
                        checkBoxs[i].Size = new Size(137, 29);
                        checkBoxs[i].Parent = this;
                        checkBoxs[i].Text = "Corect";
                        checkBoxs[i].Anchor = AnchorStyles.Top;
                        checkBoxs[i].Font = comboBox1.Font;
                        checkBoxs[i].ForeColor = comboBox1.ForeColor;
                        checkBoxs[i].Update();
                        checkBoxs[i].Show();
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "1")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        labels[i].Hide();
                        textBoxs[i].Hide();
                        checkBoxs[i].Hide();
                        pictureBoxes[i].Hide();
                    }
                    labels[1].Location = new Point(x, y + 30);
                    labels[1].Parent = this;
                    labels[1].Size = new Size(100, h);
                    labels[1].Text = "Rezultat";
                    labels[1].Anchor = AnchorStyles.Top;
                    labels[1].ForeColor = comboBox1.ForeColor;
                    labels[1].Update();
                    labels[1].Show();
                    textBoxs[1].Location = new Point(x + 100, y + 30);
                    textBoxs[1].Size = new Size(290, 33);
                    textBoxs[1].Anchor = AnchorStyles.Top;
                    textBoxs[1].Update();
                    textBoxs[1].ForeColor = comboBox1.ForeColor;
                    textBoxs[1].Parent = this;
                    textBoxs[1].Update();
                    textBoxs[1].Show();
                }
                else if (comboBox1.SelectedItem.ToString() == "2")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        labels[i].Hide();
                        textBoxs[i].Hide();
                        checkBoxs[i].Hide();
                        pictureBoxes[i].Hide();
                        pictureBoxes[i].Location = new Point(x+=200, y-100);
                        pictureBoxes[i].Size = new Size(150,150);
                        pictureBoxes[i].Parent = this;
                        pictureBoxes[i].Anchor = AnchorStyles.Top;
                        pictureBoxes[i].ImageLocation = "https://scontent-otp1-1.xx.fbcdn.net/v/t1.0-9/22853109_1533778786658799_6439743616560860887_n.jpg?_nc_cat=0&oh=19a69e80155b7eb833231e1d2e2383b7&oe=5C38D7DB";
                        pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxes[i].Update();
                        pictureBoxes[i].Show();
                        checkBoxs[i].Location = new Point(x+30, y + 50);
                        checkBoxs[i].Parent = this;
                        checkBoxs[i].Text = "Corect";
                        checkBoxs[i].Anchor = AnchorStyles.Top;
                        checkBoxs[i].Font = comboBox1.Font;
                        checkBoxs[i].ForeColor = comboBox1.ForeColor;
                        checkBoxs[i].Update();
                        checkBoxs[i].Show();
                    }
                   foreach(var xy in pictureBoxes)
                    {
                        xy.Click += (s, args) =>
                        {
                            var AdaugareImagine = new AdaugareImagine(xy.ImageLocation);
                            AdaugareImagine.Show();
                            Hide();
                            AdaugareImagine.Closed += (s1, args1) =>
                            {
                                Show(); xy.ImageLocation = AdaugareImagine.ImageString;
                            };
                        };
                    }

                }
                Button adaugaEnunt = new Button();
                adaugaEnunt.Location = new Point(this.Width - 200,this.Height - 100);
                adaugaEnunt.Size = new Size(174, 63);
                adaugaEnunt.Parent = this;
                adaugaEnunt.Text = "Adauga Enunt";
                adaugaEnunt.ForeColor = comboBox1.ForeColor;
                adaugaEnunt.Font = comboBox1.Font;
                adaugaEnunt.Anchor = AnchorStyles.Top;
                adaugaEnunt.Update();
                adaugaEnunt.Show();
                adaugaEnunt.Click += (s, args) =>
                {
                    if (textBox1.Text != "")
                    {
                        if (comboBox1.SelectedItem.ToString() == "1")
                        {
                            functii.adaugaEnunt(int.Parse(trackBar1.Value.ToString()), textBox1.Text, int.Parse(comboBox1.SelectedItem.ToString()), textBoxs[1].Text.ToString(), null, null, null, null);
                        }
                        else if (comboBox1.SelectedItem.ToString() == "0")
                        {
                            string rezultat = "0";
                            for (int i = 0; i < 4; i++)
                            {
                                if (checkBoxs[i].Checked)
                                    rezultat = textBoxs[i].Text;
                            }
                            functii.adaugaEnunt(int.Parse(trackBar1.Value.ToString()), textBox1.Text, int.Parse(comboBox1.SelectedItem.ToString()), rezultat, textBoxs[0].Text.ToString(), textBoxs[1].Text.ToString(), textBoxs[2].Text.ToString(), textBoxs[3].Text.ToString());
                        }
                        else if (comboBox1.SelectedItem.ToString() == "2")
                        {
                            string rezultat = "";
                            for (int i = 0; i < 4; i++)
                            {
                                if (checkBoxs[i].Checked)
                                    rezultat = i.ToString();
                            }
                            string img1, img2, img3, img4;
                            img1 = pictureBoxes[0].ImageLocation;
                            img2 = pictureBoxes[1].ImageLocation;
                            img3 = pictureBoxes[2].ImageLocation;
                            img4 = pictureBoxes[3].ImageLocation;
                            functii.adaugaEnunt(int.Parse(trackBar1.Value.ToString()), textBox1.Text, int.Parse(comboBox1.SelectedItem.ToString()), rezultat, img1, img2, img3, img4);
                        }
                        textBox1.Text = "";
                        for (int i = 0; i < 4; i++)
                            textBoxs[i].Text = "";
                    }
                    else
                        MessageBox.Show("Campul 'Enunt' este necompletat");
                };
            }
            catch
            {
                MessageBox.Show("Eroare la baza de date");
            }
        }

        private void AdaugareEnunt_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            label4.Text = "Dificultate" + "[" + trackBar1.Value.ToString() + "] "; 
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
