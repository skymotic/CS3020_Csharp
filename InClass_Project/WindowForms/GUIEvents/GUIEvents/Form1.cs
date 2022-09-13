using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welp. were here now....\nDumb Ass");
        }

        private void No_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Well why the fuck not bitch!?!?");
        }
    }
}
