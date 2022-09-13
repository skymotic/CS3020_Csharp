using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Student
    {

        public event EventHandler SleepsIn; //Testing

        string name;
        string major;
        float grade;
        bool hangery;
        int energy;
        int sid;
        int sad;

        /*
         * Events:
         * Test
         * SnowDay
         * Homework due
         * Snackies
         * Attendance
         * Tech Difficulties
         * Got Dumped?
         */

        public Student(string name, string major, float grade, bool hangery, int energy, int sid, int sad)
        {
            this.Name = name;
            this.Major = major;
            this.Grade = grade;
            this.Hangery = hangery;
            this.Energy = energy;
            this.Sid = sid;
            this.Sad = sad;
            SleepIn();
        }

        public void OnTest(object sender, EventArgs e)
        {
            Console.WriteLine($"{name.ToUpper().Split(' ')[0]} PANICS! TEAR DOWN THE WALLS");
        }

        public void SleepIn(object sender, EventArgs e)
        {
            SleepsIn.Invoke(this, EventArgs.Empty);
        }

        public void OnSleepIn(object sender, EventArgs e)
        {
            Console.WriteLine($"{name.Split(' ')[0]} Has Slept in");
        }

        public string Name { get => name; set => name = value; }
        public string Major { get => major; set => major = value; }
        public float Grade { get => grade; set => grade = value; }
        public bool Hangery { get => hangery; set => hangery = value; }
        public int Energy { get => energy; set => energy = value; }
        public int Sid { get => sid; set => sid = value; }
        public int Sad { get => sad; set => sad = value; }
    }
}
