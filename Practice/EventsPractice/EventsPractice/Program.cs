using System;

namespace EventsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var raiser = new AlarmRaised();
            var lockDown = new LockDownProtocall();

            raiser.AlarmRaising += lockDown.OnAlarmRaised;

            Console.WriteLine("__What is the Alarm?");
            raiser.RaiseAlarm(Console.ReadLine());
        }
    }
}
