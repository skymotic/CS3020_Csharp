using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBrien_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string temp;
            Random rand = new Random();
            InitializeComponent();

            textBox1.AppendText("This is my mockup!\r\nBleeBloopBlee\r\n");

            for(int x=0; x<3; x++)
            {
                temp = "";
                for (int y = 0; y < 25; y++)
                {
                    temp += (char) rand.Next(32, 122);
                }
                textBox1.AppendText(temp + "\r\n");
            }
            textBox1.AppendText("Done!");
        }
    }
}
