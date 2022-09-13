/*
 * Name: Luke O'Brien
 * Class: 3020:001
 * Due Date: 10/8/21 ->(moved to) 10/11/21
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrienLA2
{
    class Cerial : IComparable<Cerial>
    {
        public string name { get; }
        public double calories { get; }
        public double protein { get; }
        public double fat { get; }
        public double sodium { get; }
        public double fiber { get; }
        public double carbohydrates { get; }
        public double sugars { get; }
        public double potassium { get; }
        public double vitamins { get; }
        public double rating { get; }

        public Cerial() {}

        public Cerial(string[] line)
        {
            this.name = line[0];
            this.calories = double.Parse(line[3]);
            this.protein = double.Parse(line[4]);
            this.fat = double.Parse(line[5]);
            this.sodium = double.Parse(line[6]);
            this.fiber = double.Parse(line[7]);
            this.carbohydrates = double.Parse(line[8]);
            this.sugars = double.Parse(line[9]);
            this.potassium = double.Parse(line[10]);
            this.vitamins = double.Parse(line[11]);
            this.rating = double.Parse(line[line.Length-1]);
        }

        /// <summary>
        /// Returns the Nutrient basied off index value
        /// </summary>
        /// <param name="nutriIndex"></param>
        /// <returns></returns>
        public double GetNutrient(int nutriIndex)
        {
            switch (nutriIndex)
            {
                case 1:
                    return protein; break;
                case 2:
                    return fat; break;
                case 3:
                    return sodium; break;
                case 4:
                    return fiber; break;
                case 5:
                    return carbohydrates; break;
                case 6:
                    return sugars; break;
                case 7:
                    return potassium; break;
                case 8:
                    return vitamins; break;
                default:
                    return calories; break;
            }
        }

        /// <summary>
        /// **FOR TESTING** Converts all stored cereral Data into a string
        /// calories,protein,fat,sodium,fiber,carbo,sugars,potass,vitamins
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string temp = "";
            temp += (name + ",");

            temp += (calories + ",");
            temp += (protein + ",");
            temp += (fat + ",");
            temp += (sodium + ",");
            temp += (fiber + ",");
            temp += (carbohydrates + ",");
            temp += (sugars + ",");
            temp += (potassium + ",");
            temp += (vitamins + ",");
            
            temp += rating.ToString();
            return temp;
        }

        /// <summary>
        /// Compaires to other Cerial objects by name
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Cerial other)
        {
            return name.CompareTo(other.name);
        }
    }
}
