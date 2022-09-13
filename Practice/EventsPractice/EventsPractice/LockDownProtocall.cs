using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPractice
{
    class LockDownProtocall
    {
        public void Lock()
        {
            Console.WriteLine("All Doors locking");
        }

        public void OnAlarmRaised(object thinf, AlarmEventArgs e)
        {
            Console.WriteLine("Alarm Heard : " + e.Alarm.getAlarm());
            Lock();
        }
    }
}
