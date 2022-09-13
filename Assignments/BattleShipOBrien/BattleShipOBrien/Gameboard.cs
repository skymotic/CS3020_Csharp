using System;

/*
 * Name:        Luke O'Brien
 * Assignment:  1
 * Class:       CS3020
 * Due Date:    9/15/2021, 3:05pm
 */

namespace BattleShipOBrien
{
    class Gameboard
    {

        private char[,] gameboard;
        private bool hacks;

        private Ship DestroyerOne;
        private Ship DestroyerTwo;
        private Ship SubOne;
        private Ship SubTwo;
        private Ship BattleShip;
        private Ship Carrier;

        /// <summary>
        /// Class Constuctor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="hacks"></param>
        public Gameboard(int width, int height, bool hacks)
        {
            gameboard = new char[height, width];
            this.hacks = hacks;

            DestroyerOne = new Ship(2);
            DestroyerTwo = new Ship(2);
            SubOne = new Ship(3);
            SubTwo = new Ship(3);
            BattleShip = new Ship(4);
            Carrier = new Ship(5);
        }

        /// <summary>
        /// [FOR TESTING ONLY] Fills the board with Desired Character
        /// </summary>
        /// <param name="newChar"></param>
        public void FillBoard(char newChar)
        {
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    gameboard[row, col] = newChar;
                }
            }
        }

        /// <summary>
        /// Fills the board with spaces
        /// </summary>
        public void EmptyFill()
        {
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    gameboard[row, col] = ' ';
                }
            }
        }

        /// <summary>
        /// Displays the Gameboard in console
        /// </summary>
        public void Display()
        {
            Console.Write("    ");
            PrintIDNumbers();
            DrawSideLine();
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                Console.Write($"{row+1,-3}");
                Console.Write("|");
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    //If hacks are off, wont show where the boats are if they are untouched
                    if (gameboard[row, col] == 'e' && hacks == false)
                    {
                        Console.Write($"   |");
                    }
                    else
                    {
                        Console.Write($" {gameboard[row, col]} |");
                    }
                }
                DrawSideLine();
            }
        }

        /// <summary>
        /// [Compliments Display] Draws a line at the length of Gameboard.
        /// </summary>
        private void DrawSideLine()
        {
            Console.WriteLine();
            Console.Write(String.Format("{0,4}", "-"));
            for (int test = 0; test < gameboard.GetLength(1); test++)
            {
                Console.Write("----");
            }
            Console.WriteLine();
        }

        private void PrintIDNumbers()
        {
            char CharterChar = 'A';
            for (int x = 0; x < gameboard.GetLength(1); x++)
            {
                Console.Write(String.Format("{0,2}{1,-2}", CharterChar, " "));
                CharterChar++;
            }
        }

        /// <summary>
        /// [FOR TESTING ONLY] Generates a compleatly random Gameboard
        /// </summary>
        public void RandomizeBoard() //Exercise #3
        {
            int temp;
            Random rand = new Random();
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    temp = rand.Next(33, 127);
                    gameboard[row, col] = (char)temp;
                }
            }
        }

        /// <summary>
        /// Wrapper Class to place all boats at once
        /// </summary>
        public void PlaceAllShips()
        {
            DestroyerOne.PlaceShip(gameboard);
            DestroyerTwo.PlaceShip(gameboard);
            SubOne.PlaceShip(gameboard);
            SubTwo.PlaceShip(gameboard);
            BattleShip.PlaceShip(gameboard);
            Carrier.PlaceShip(gameboard);
        }

        /// <summary>
        /// Checks where Fire location is and inputs data into Gameboard if applicable
        /// </summary>
        /// <param name="XLocation"></param>
        /// <param name="YLocation"></param>
        public void Fire(int XLocation, int YLocation)
        {
            //Checks to make sure that users input is within the gameboard
            if (XLocation >= 0 && XLocation < gameboard.GetLength(1) && YLocation >= 0 && YLocation < gameboard.GetLength(0))
            {
                switch (gameboard[YLocation, XLocation])
                {
                    case 'e':
                        gameboard[YLocation, XLocation] = 'X'; break;
                    case 'X':
                        Console.WriteLine("You Have Already Fired there, Try again"); break;
                    case 'O':
                        Console.WriteLine("You Have Already Fired there, Try again"); break;
                    default:
                        gameboard[YLocation, XLocation] = 'O'; break;
                }
            }
            //If users input is NOT in the gameboard, it warns the user
            else
            {
                Console.WriteLine("Please Enter a Valid Coordinate");
            }
        }

        /// <summary>
        /// True/False; Checks if all ships are sunk
        /// </summary>
        /// <returns></returns>
        public bool AllShipsSunk()
        {
            if( DestroyerOne.CheckIsSunk(gameboard) &&
                DestroyerTwo.CheckIsSunk(gameboard) &&
                SubOne.CheckIsSunk(gameboard) &&
                SubTwo.CheckIsSunk(gameboard) &&
                BattleShip.CheckIsSunk(gameboard) &&
                Carrier.CheckIsSunk(gameboard) )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Looks to see if single ship sunk
        /// </summary>
        public void DidShipSink()
        {
            DestroyerOne.Sunk(gameboard);
            DestroyerTwo.Sunk(gameboard);
            SubOne.Sunk(gameboard);
            SubTwo.Sunk(gameboard);
            BattleShip.Sunk(gameboard);
            Carrier.Sunk(gameboard);
        }
    }
}
