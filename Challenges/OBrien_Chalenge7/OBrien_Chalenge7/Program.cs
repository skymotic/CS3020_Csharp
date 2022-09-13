using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OBrien_Chalenge7
{
    class Program
    {
        static int timeRange = 100;
        static Task<Gravy> makeGracy;
        static async Task Main(string[] args)
        {
            Task<Turkey> TurTast = PrepreAndCookTurkey();
            Task<MashedPotatos> potatTask = CookAndMsh();

            List<Task> TGTasks = new List<Task> { TurTast, potatTask };

            while(TGTasks.Count > 0)
            {
                Task finsihedTask = await Task.WhenAny(TGTasks);
                if (finsihedTask == TurTast)
                {
                    Console.WriteLine("Turkey is cooling");
                    makeGracy = MakeTheGray();
                    TGTasks.Add(makeGracy);
                }
                else if(finsihedTask == potatTask)
                {
                    Console.WriteLine("Poptatos lookd elisious (Cant Spell)");
                }
                TGTasks.Remove(finsihedTask);
            }
        }

        static async Task<Turkey> PrepreAndCookTurkey()
        {
            //prepair
            Console.WriteLine("preparing the Turkey");
            await Task.Delay(20 * timeRange);
            Console.WriteLine("Turkey prepaire");

            //cook
            Console.WriteLine("Cooking the turkey");
            await Task.Delay(60 * timeRange);
            Console.WriteLine("Turkey is Done!");

            return new Turkey();
        }

        static async Task<MashedPotatos> CookAndMsh()
        {
            //Cut
            Console.WriteLine("Slice Slice bitch");
            await Task.Delay(20 * timeRange);

            //Boil
            Console.WriteLine("Boiling");
            await Task.Delay(10 * timeRange);

            //mashing
            Console.WriteLine("Mashing!!!!!!!!!!!!!!!!!!!!!!");
            await Task.Delay(10 * timeRange);
            Console.WriteLine("Mashed");

            return new MashedPotatos();
        }

        static async Task<Gravy> MakeTheGray()
        {
            Console.WriteLine("Making the Gravy; Form the drippins");
            await Task.Delay(15 * timeRange);
            Console.WriteLine("Gravy Ready");

            return new Gravy();
        }
    }
}
