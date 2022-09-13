using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlienChal
{
    public partial class CannonGUI : Form
    {

        public CannonGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public bool IsAuthValid(object sender, EventArgs e)
        {
            return auth_text.Text.Equals("Password1") ? true : false;
        }

        public bool IsLatValid(object sender, EventArgs e)
        {

        }
        public bool IsLongValid(object sender, EventArgs e)
        {

        }
    }
}
