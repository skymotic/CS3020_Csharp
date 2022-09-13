using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPractice
{
    class Alarm
    {
        private string alarmMessage;

        public Alarm(string message)
        {
            alarmMessage = message;
        }
        public Alarm()
        {
            alarmMessage = "This is a test of systems, please do not be alarmed";
        }

        public string getAlarm()
        {
            return alarmMessage;
        }
    }
}
