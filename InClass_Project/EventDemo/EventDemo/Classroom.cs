using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Classroom
    {
        public event EventHandler Test;

        public Student bobert = new Student("Bobert T GoldLewis", "Chemistry", 2.5f, true, 1, 1234567890, 10);
        public Student joey = new Student("Joey Jilly", "CS", 3.5f, false, 10, 1987654321, 2);

        public Classroom()
        {
            Test += bobert.OnTest;
            Test += joey.OnTest;
        }

        public void TestAnounce()
        {
            Test.Invoke(this, EventArgs.Empty);
        }
        public void DropClass(Student student)
        {
            Test += student.OnTest;
        }

        protected virtual void OnTest(object sender, EventArgs e)
        {
            if(Test != null)
            {
                Test.Invoke(sender, e);
            }
        }
    }
}
