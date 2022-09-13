using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard_Project_LaO
{
    /// <summary>
    /// Act as a continer for a gameboard consisting of chars
    /// </summary>
    class Board
    {
        char[,] gameboard = new char[10, 10];


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

        public void Reset()
        {
            FillBoard(' ');
        }

        public void Display()
        {
            DrawSideLine();
            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    Console.Write($" {gameboard[row, col]} |");
                }
                DrawSideLine();
            }
        }

        /// <summary>
        /// Draws a line at the specified length of array length.
        /// </summary>
        private void DrawSideLine()
        {
            Console.WriteLine();
            Console.Write("-");
            for (int test = 0; test < gameboard.GetLength(1); test++)
            {
                Console.Write("----");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Asks user to enter a character, then uses fillboard method to add the 
        /// </summary>
        public void FillBoardWith() //Exercise #1
        {
            Console.WriteLine("Please enter the character you'd like to fill the board with");
            char temp = Console.ReadKey().KeyChar;
            FillBoard(temp);
        }

        /// <summary>
        /// Program gets 2 letter from the user and then alternates them using modular logic, alternates them
        /// </summary>
        public void CheckerFill() //Exercise #2{
        {
            Console.WriteLine("Please Enter 2 characters\n\nFirst Character:");
            char charTemp1 = Console.ReadKey().KeyChar;

            Console.WriteLine("\nSecond Character:");
            char charTemp2 = Console.ReadKey().KeyChar;

            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    if( (row + col) % 2 == 0)
                    {
                        gameboard[row, col] = charTemp1;
                    }
                    else
                    {
                        gameboard[row, col] = charTemp2;
                    }
                }
            }
        }

        /// <summary>
        /// Uses a random number geneorator to find the decimal number of a char, then
        /// casts to char and adds to board
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

        public void SearchReplace()
        {
            Console.WriteLine("Please enter the character you'd like to replace");
            char searchParm = Console.ReadKey().KeyChar;
            Console.WriteLine("What do you want to replace it with?");
            char replaceParm = Console.ReadKey().KeyChar;
            bool replaced = false;

            for (int row = 0; row < gameboard.GetLength(0); row++)
            {
                for (int col = 0; col < gameboard.GetLength(1); col++)
                {
                    if(gameboard[row,col] == searchParm)
                    {
                        gameboard[row, col] = replaceParm;
                        replaced = true;
                    }
                }
            }
            if(replaced == false)
            {
                Console.WriteLine("This was not found in the gameboard");
            }
        }
    }
}
