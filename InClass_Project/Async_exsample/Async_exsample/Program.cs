using System;
using System.Threading.Tasks;

namespace Async_exsample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<long> aTask = Task.Run(() => CountToABill());
            Console.WriteLine("This might take a while....\nsorry...\nbut not sorry");
            await aTask;
            Console.WriteLine(aTask.Result);
        }

        public static long CountToABill()
        {
            long result = 0;
            for(long x=0; x < 10000000000; x++)
            {
                result += x;
            }

            return result;
        }
    }
}
