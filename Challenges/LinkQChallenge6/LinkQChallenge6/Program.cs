using System;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LinkQChallenge6
{
    class Program
    {
        private static List<Band> bands;
        static void Main(string[] args)
        {
            bands = new List<Band>();

            TextFieldParser parser = new TextFieldParser("metal_bands_2017.csv");
            parser.Delimiters = new string[] { "," };
            while (true)
            {
                string[] parts = parser.ReadFields();
                if (parts == null)
                {
                    break;
                }
                bands.Add(new Band(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]));
            }

            foreach(Band cc in FindFinishBands())
            {
                Console.WriteLine("--------");
                Console.WriteLine(cc.ToString());
            }
        }

        public static List<Band> FindFinishBands()
        {
            var result =
                from band in bands
                where band.Orgin.ToLower().CompareTo("finland") == 0
                select band;

            return result.ToList();
        }
    }
}
