using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetPanel1Color();
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            SetPanel1Color();    
        }

        private void SetPanel1Color()
        {
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001B')
                Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
