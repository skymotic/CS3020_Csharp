using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name:        Luke O'Brien
 * Assignment:  1
 * Class:       CS3020
 * Due Date:    9/15/2021, 3:05pm
 */

namespace BattleShipOBrien
{
    class Game
    {
        private int width = 0;
        private int height = 0;
        Gameboard board;

        /// <summary>
        /// Starts the Game Instructions for Battle Ship
        /// </summary>
        public void Start()
        {
            GetSizeBoard();

            board = new Gameboard(width, height, WantHacks());
            board.EmptyFill();
            board.PlaceAllShips();

            board.Display();

            //While there are still ships left
            while (!board.AllShipsSunk())
            {
                Fire();
                board.Display();
                board.DidShipSink();
            }

            //end Message
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\t\tCongrats, You have eliminated all the Ships\n\t\t\t\tGAME OVER!");
        }

        /// <summary>
        /// Asks user for the desired size of Gameboard; Then sets it.
        /// </summary>
        public void GetSizeBoard()
        {
            Console.WriteLine("Please Specify the size of the gameboard:");

            Console.Write("Width:\t");
            width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Height:\t");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        /// <summary>
        /// Asks user if they want to use hacks in game
        /// </summary>
        /// <returns></returns>
        private bool WantHacks()
        {
            string temp;
            Console.WriteLine("\nWould you like to have Hacks on? ( Yes | No )");
            temp = Console.ReadLine().ToLower();
            if (temp == "yes")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Asks user where to fire; Parses data and sends to Gameboard
        /// </summary>
        private void Fire()
        {
            string UserResponse;
            char Letter;
            int Number;
            Console.WriteLine("\n---------------------\nWhere Would you Like to fire? (Letter First, Number seccond | EX. A9 )");
            UserResponse = Console.ReadLine();
            Console.WriteLine(UserResponse);

            Letter = UserResponse.ToUpper().ToCharArray()[0];
            Number = Convert.ToInt32(UserResponse.Substring(1));
            board.Fire((int)Letter - (int)'A', Number-1);
        }
    }
}
