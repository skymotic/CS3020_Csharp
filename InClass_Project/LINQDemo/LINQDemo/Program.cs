using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        //static string[] names = new string[10];

        static Dictionary<string, int> maleNames = new Dictionary<string, int>();
        static Dictionary<string, int> femaleNames = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            ReadInNames();

            /*var result =
                from name in femaleNames
                where name.Value > 1000 && name.Value < 1100
                select name.Key;*/

            Console.WriteLine(GetPopularNames(femaleNames).Keys);

            Console.WriteLine($"There are {femaleNames.Count} Females names");
            Console.WriteLine($"There are {maleNames.Count} Male names");
        }

        static void ReadInNames()
        {
            try
            {
                for(int year = 1880; year <= 2016; year++)
                {
                    StreamReader reader = new StreamReader($"names\\yob{year}.txt");
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] data = line.Split(',');
                        if (data[1].CompareTo("F") == 0)
                        {
                            if (femaleNames.ContainsKey(data[0]))
                            {
                                femaleNames[data[0]] += int.Parse(data[2]);
                            }
                            else
                            {
                                femaleNames.Add(data[0], int.Parse(data[2]));
                            }
                        }
                        else if(data[1].CompareTo("M") == 0)
                        {
                            if (maleNames.ContainsKey(data[0]))
                            {
                                maleNames[data[0]] += int.Parse(data[2]);
                            }
                            else
                            {
                                maleNames.Add(data[0], int.Parse(data[2]));
                            }
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        #region Simple Queues
        static Dictionary<string, int> GetPopularNames(Dictionary<string, int> TheNames)
        {
            var result =
                from name in TheNames
                orderby name.Value //descending
                select name;

            return result.ToDictionary(result => result.Key, result => result.Value);
        }

        /*static Dictionary<string, int> GetNamesByLength(Dictionary<string, int> TheNames)
        {
            var result =
                from name in TheNames
                where name.ToUpper().StartsWith('B')
                orderby name
                select name;

            return result.ToList<string>();
        }*/
        #endregion
    }
}
