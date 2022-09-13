using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsPractice
{
    class AlarmRaised
    {
        public event EventHandler<AlarmEventArgs> AlarmRaising;

        public void RaiseAlarm(string message)
        {
            var alarm = new Alarm(message);

            Console.WriteLine("Rasing alarm!");
            string loadMessage = "Waiting";
            for(int x=0; x<5; x++)
            {
                Console.WriteLine(loadMessage += ".");
                Thread.Sleep(1000);
            }
            OnAlarmRaised(alarm);
            Console.WriteLine("Done");
        }
        
        protected virtual void OnAlarmRaised(Alarm alarm)
        {
            if(AlarmRaising != null)
            {
                AlarmRaising(this, new AlarmEventArgs() { Alarm = alarm });
            }
        }
    }
}
