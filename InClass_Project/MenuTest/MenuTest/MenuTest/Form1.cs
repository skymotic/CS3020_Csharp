using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuTest
{
    public partial class Form1 : Form
    {
        int runtime = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += OnTimer_Tick;
            timer1.Start();
        }

        public void OnTimer_Tick(object sender, EventArgs e)
        {
            runtime++;
            timerLBL.Text = $"Timer: {runtime}";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter wtr = new StreamWriter("SaveData.txt", true);
            try
            {
                wtr.WriteLine("THIS HAS BEEN WRITEN!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                wtr.Close();
            }
        }
    }
}
