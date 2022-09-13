using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrien_Final
{
    class Game
    {
        //A place to store all active characters
        List<Hero> heroList = new List<Hero>();
        List<Villian> villianList = new List<Villian>();

        /// <summary>
        /// Starts all the Game logic and output
        /// </summary>
        public void StartGame()
        {
            CreateHeros();
            CreateVillians();
            ListCharactersCL();
        }

        /// <summary>
        /// Creates all the heros for the game and adds them to a list
        /// </summary>
        private void CreateHeros()
        {
            Hero warrior = new Hero("warrior", 2, 2, 8, 5, 3);
            heroList.Add(warrior);
            Hero mage = new Hero("mage", 10, 8, 3, 2, 8);
            heroList.Add(mage);
            Hero cleric = new Hero("cleric", 5, 4, 3, 3, 6);
            heroList.Add(cleric);
        }

        /// <summary>
        /// Creates all the villans for the game and adds them to a list
        /// </summary>
        private void CreateVillians()
        {
            Villian bandit = new Villian("bandit", 2, 3, 2, 3, 5);
            villianList.Add(bandit);
            Villian ogre = new Villian("ogre", 5, 1, 6, 3, 2);
            villianList.Add(ogre);
            Villian dragon = new Villian("dragon", 8, 8, 8, 8, 1);
            villianList.Add(dragon);
        }

        /// <summary>
        /// Lists Characters name, type and HP in Command line
        /// Used if game is running in headless mode and is
        /// displaying all output in the console.
        /// </summary>
        private void ListCharactersCL()
        {
            if (heroList.Count < villianList.Count)
            {
                int temp = 0;
                Hero[] heros = new Hero[heroList.Count];
                foreach (Hero y in heroList)
                {
                    heros[temp] = y;
                    temp++;
                }
                temp--;

                foreach (Villian x in villianList)
                {
                    if (temp > 0)
                        Console.WriteLine($"{heros[temp].ToString(), 25}{x.ToString()}");
                    else
                        Console.WriteLine($"{"",25}{x.ToString()}");
                    temp--;
                }
            }
            else
            {
                int temp = 0;
                Villian[] vils = new Villian[villianList.Count];
                foreach (Villian y in villianList)
                {
                    vils[temp] = y;
                    temp++;
                }
                temp--;

                foreach (Hero x in heroList)
                {
                    if (temp > 0)
                        Console.WriteLine($"{x.ToString(), 25}{vils[temp].ToString()}");
                    else
                        Console.WriteLine($"{x.ToString()}");
                    temp--;
                }
            }
        }
    }
}
