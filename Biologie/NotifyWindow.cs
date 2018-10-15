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
    public partial class NotyfyWindow : Form
    {
        public NotyfyWindow(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
