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
        CheckBox[] checkBoxs = new CheckBox[4];
        Button adaugare = new Button();
        FunctiiPublice functii = new FunctiiPublice();
        public AdaugareEnunt()
        {
            InitializeComponent();
            comboBox1.Items.Add("0");
            comboBox1.Items.Add("1");
            label4.Hide();
            for (int i = 0; i < 4; i++)
            {
                labels[i] = new Label();
                textBoxs[i] = new TextBox();
                checkBoxs[i] = new CheckBox();
            }
            trackBar1.SetRange(1, 5);
            trackBar1.Hide();
            textBox1.MaxLength = 250;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = 15, y = 360, w = 42, h = 25;
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
                        labels[i].Update();
                        labels[i].Parent = this;
                        labels[i].Show();
                        this.Controls.Add(labels[i]);
                        //TextBoxes
                        textBoxs[i].Location = new Point(x + 50, y);
                        textBoxs[i].Size = new Size(290, 33);
                        textBoxs[i].Update();
                        textBoxs[i].Parent = this;
                        textBoxs[i].Update();
                        textBoxs[i].Show();
                        //CheckBoxes
                        checkBoxs[i].Location = new Point(x + 350, y);
                        checkBoxs[i].Size = new Size(137, 29);
                        checkBoxs[i].Parent = this;
                        checkBoxs[i].Text = "Corect";
                        checkBoxs[i].Update();
                        checkBoxs[i].Show();
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        labels[i].Hide();
                        textBoxs[i].Hide();
                        checkBoxs[i].Hide();
                    }
                    labels[1].Location = new Point(x, y + 30);
                    labels[1].Parent = this;
                    labels[1].Size = new Size(100, h);
                    labels[1].Text = "Rezultat";
                    labels[1].Update();
                    labels[1].Show();
                    textBoxs[1].Location = new Point(x + 100, y + 30);
                    textBoxs[1].Size = new Size(290, 33);
                    textBoxs[1].Update();
                    textBoxs[1].Parent = this;
                    textBoxs[1].Update();
                    textBoxs[1].Show();
                }
                Button adaugaEnunt = new Button();
                adaugaEnunt.Location = new Point(836, 627);
                adaugaEnunt.Size = new Size(174, 63);
                adaugaEnunt.Parent = this;
                adaugaEnunt.Text = "Adauga Enunt";
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
                        else
                        {
                            string rezultat = "0";
                            for (int i = 0; i < 4; i++)
                            {
                                if (checkBoxs[i].Checked)
                                    rezultat = textBoxs[i].Text;
                            }
                            functii.adaugaEnunt(int.Parse(trackBar1.Value.ToString()), textBox1.Text, int.Parse(comboBox1.SelectedItem.ToString()), rezultat, textBoxs[0].Text.ToString(), textBoxs[1].Text.ToString(), textBoxs[2].Text.ToString(), textBoxs[3].Text.ToString());
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }
    }
}
