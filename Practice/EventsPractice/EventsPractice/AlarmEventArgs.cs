using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPractice
{
    class AlarmEventArgs : EventArgs
    {
        public Alarm Alarm { get; set; }
        public int TestInt { get; set; }
    }
}
