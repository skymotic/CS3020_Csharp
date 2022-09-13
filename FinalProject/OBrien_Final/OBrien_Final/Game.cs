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

        //Event objects
        public event EventHandler<CharacterEventArgs> ListCharacters;
        public event EventHandler<CharacterEventArgs> HeroWasCreated;
        public event EventHandler<CharacterEventArgs> VilWasCreated;
        public event EventHandler<CharacterEventArgs> Updated;


        public Game() { }

        /// <summary>
        /// Starts all the Game logic and output
        /// </summary>
        public void StartGame()
        {

            CreateHeros();
            CreateVillians();
            SubEvents();
            //ListCharactersTXT();

            Turns();
        }

        /// <summary>
        /// Creates all the heros for the game and adds them to a list
        /// </summary>
        private void CreateHeros()
        {
            Hero warrior = new Hero("warrior", 2, 2, 8, 5, 3);
            heroList.Add(warrior);

            Hero cleric = new Hero("cleric", 5, 4, 3, 3, 6);
            heroList.Add(cleric);

            Hero mage = new Hero("mage", 10, 8, 3, 2, 8);
            heroList.Add(mage);
        }

        /// <summary>
        /// Subscribes Hero and Villan objects to all events and other handlers
        /// </summary>
        private void SubEvents()
        {
            var header = new Form1();

            foreach(Hero x in heroList)
            {
                HeroCreated(x);
                x.DeathOfCharacter += header.OnCharacterDeath;
                x.ThrownMessage += header.OnMessageThrown;
            }

            foreach(Villian y in villianList)
            {
                VilCreated(y);
                y.DeathOfCharacter += header.OnCharacterDeath;
                y.ThrownMessage += header.OnMessageThrown;
            }

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
        /// Calculates who goes first then loops the turns until
        /// an entire team is dead
        /// </summary>
        private void Turns()
        {
            List<Hero> tempHero = heroList.ToList<Hero>();
            List<Villian> tempVil = villianList.ToList<Villian>();
            List<String> turnOrder = new List<string>();

            while(tempHero.Count > 0 || tempVil.Count > 0)
            {
                if(tempHero.Count > 0 && tempVil.Count > 0)
                {
                    if (tempHero.ElementAt(0).Speed > tempVil.ElementAt(0).Speed)
                    {
                        turnOrder.Add(tempHero.ElementAt(0).CharacterType);
                        removeHero(tempHero.ElementAt(0).CharacterType, tempHero);
                    }
                    else
                    {
                        turnOrder.Add(tempVil.ElementAt(0).CharacterType);
                        removeVil(tempVil.ElementAt(0).CharacterType, tempVil);
                    }
                }
                else if (tempHero.Count > 0)
                {
                    turnOrder.Add(tempHero.ElementAt(0).CharacterType);
                    removeHero(tempHero.ElementAt(0).CharacterType, tempHero);
                }
                else
                {
                    turnOrder.Add(tempVil.ElementAt(0).CharacterType);
                    removeVil(tempVil.ElementAt(0).CharacterType, tempVil);
                }
            }

            //Game While loops goes here
        }

        /// <summary>
        /// Removes specified Hero from List
        /// </summary>
        /// <param name="str"></param>
        private void removeHero(string str, List<Hero> list)
        {
            foreach(Hero x in list)
            {
                if (x.CharacterType.Equals(str))
                {
                    list.Remove(x);
                    break;
                }
            }
        }

        /// <summary>
        /// Removes specified Villian from list
        /// </summary>
        /// <param name="str"></param>
        private void removeVil(string str, List<Villian> list)
        {
            foreach (Villian x in list)
            {
                if (x.CharacterType.Equals(str))
                {
                    list.Remove(x);
                    break;
                }
            }
        }

        // ---------- ---------- ---------- Event Activators

        /// <summary>
        /// Event Activator that triggers a hero creation event
        /// </summary>
        /// <param name="obj"></param>
        private void HeroCreated(Hero obj)
        {
            if(HeroWasCreated != null)
            {
                HeroWasCreated(this, new CharacterEventArgs() { HeroObject = obj });
            }
        }

        /// <summary>
        /// Event Activator that triggers a villion creation event
        /// </summary>
        /// <param name="obj"></param>
        private void VilCreated(Villian obj)
        {
            if(VilWasCreated != null)
            {
                VilWasCreated(this, new CharacterEventArgs() { VilObject = obj });
            }
        }

        /// <summary>
        /// Event Activator that triggers an update Hero event
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateHero(Hero obj)
        {
            if(Updated != null)
            {
                Updated(this, new CharacterEventArgs() { HeroObject = obj });
            }
        }

        /// <summary>
        /// Event Activator that triggers an update Villian event
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateVil(Villian obj)
        {
            if(Updated != null)
            {
                Updated(this, new CharacterEventArgs() { VilObject = obj });
            }
        }

        /// <summary>
        /// Creates a string that lists all characters and their HP values
        /// then triggers an event with the information.
        /// </summary>
        private void ListCharactersTXT()
        {
            string characterList = "";
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
                        characterList += $"{heros[temp].ToString(), 25}{x.ToString()}\r\n";
                    else
                        characterList += $"{"",-25}{x.ToString()}\r\n";
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
                        characterList += $"{x.ToString(), -25}{vils[temp].ToString()}\r\n";
                    else
                        characterList += $"{x.ToString()}\r\n";
                    temp--;
                }
            }

            if(ListCharacters != null)
            {
                ListCharacters(this, new CharacterEventArgs() { ListOfCharacters = characterList });
            }
        }
    }
}
