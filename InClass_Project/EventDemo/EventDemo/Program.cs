using System;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Classroom TheClass = new Classroom();
            TheClass.TestAnounce();
            TheClass.DropClass(TheClass.joey);
            TheClass.TestAnounce();
        }
    }
}
