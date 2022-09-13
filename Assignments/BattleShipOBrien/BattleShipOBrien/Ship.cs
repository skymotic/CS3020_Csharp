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
    class Ship
    {
        private int length;
        private int[] Bow;
        private char Direction;
        private bool sunkStatus;
        public Ship(int length)
        {
            this.length = length;
            Bow = new int[2];
            sunkStatus = false;
        }

        /// <summary>
        /// Wrapper for CheckIsSunk that prints if a ship was sunk
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool Sunk(char[,] board)
        {
            if (!sunkStatus)
            {
                if (CheckIsSunk(board))
                {
                    Console.WriteLine(string.Format("You sunk their {0}!", GetShipType()));
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks the boat on board to see if it has sunk
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool CheckIsSunk(char[,] board)
        {
            bool isSunk = true;

            // Uses direction to scan correct location of boat to see if it was sunk
            switch (Direction)
            {
                case 'u':
                    for (int x = Bow[1]; x > Bow[1] - length; x--)
                    {
                        if (board[x, Bow[0]] != 'X')
                        {
                            isSunk = false;
                        }
                    }
                    break;

                case 'd':
                    for (int x = Bow[1]; x < Bow[1] + length; x++)
                    {
                        if (board[x, Bow[0]] != 'X')
                            isSunk = false;
                    }
                    break;

                case 'l':
                    for (int x = Bow[0]; x > Bow[0] - length; x--)
                    {
                        if (board[Bow[1], x] != 'X')
                        {
                            isSunk = false;
                        }
                    }
                    break;

                case 'r':
                    for (int x = Bow[0]; x < Bow[0] + length; x++)
                    {
                        if (board[Bow[1], x] != 'X')
                            isSunk = false;
                    }
                    break;
            }
            sunkStatus = isSunk;
            return isSunk;
        }

        /// <summary>
        /// Returns The Ship Type Name
        /// </summary>
        /// <returns></returns>
        public string GetShipType()
        {
            switch (length)
            {
                case 2:
                    return "Destoryer"; break;
                case 3:
                    return "Submarine"; break;
                case 4:
                    return "Battleship"; break;
                default:
                    return "Carrier"; break;
            }
        }

        /// <summary>
        /// Find an open slot on the Game Board and inserts the ship
        /// </summary>
        /// <param name="board"></param>
        public void PlaceShip(char[,] board)
        {
            bool placed = false;
            bool tempPlaced = true;
            int randDirec = 1;
            int[] temp = new int[2];
            var rand = new Random();
            while (!placed)
            {
                //Randomly selects a temporary bow location
                temp[0] = rand.Next(board.GetLength(1));
                temp[1] = rand.Next(board.GetLength(0));

                switch (randDirec % 4)
                {
                    //Case 1; Up, looks to see if it can place entire ship verticle
                    //(This is the first check for first ship; always)
                    case 1:
                        tempPlaced = true;
                        try
                        {
                            //Loops checks to see if all spots in a row are avalibe, then if not,
                            //restarts the outter while loop with a new Direction peramitor
                            for (int x = temp[1]; x > temp[1] - length; x--)
                            {
                                if (board[x, temp[0]] != ' ')
                                {
                                    tempPlaced = false;
                                    randDirec = rand.Next(1, 101);
                                }
                            }

                            //If placed, perminatly sets bow location, direction and fills the board
                            if (tempPlaced)
                            {
                                placed = true;
                                Direction = 'u';
                                Bow[0] = temp[0];
                                Bow[1] = temp[1];
                                for (int x = temp[1]; x > temp[1] - length; x--)
                                {
                                    board[x, temp[0]] = 'e';
                                }
                            }
                        }
                        
                        //If The ship "Hangs off the board" it hits this catch block
                        //and restarts the loop
                        catch(IndexOutOfRangeException e)
                        {
                            randDirec = rand.Next(1, 101);
                        }
                        break;

                    //Same as Catch 1, but Down
                    case 2:
                        tempPlaced = true;
                        try
                        {
                            for (int x = temp[1]; x < temp[1] + length; x++)
                            {
                                if (board[x, temp[0]] != ' ')
                                {
                                    tempPlaced = false;
                                    randDirec = rand.Next(1, 101);
                                }
                            }
                            if (tempPlaced)
                            {
                                placed = true;
                                Direction = 'd';
                                Bow[0] = temp[0];
                                Bow[1] = temp[1];
                                for (int x = temp[1]; x < temp[1] + length; x++)
                                {
                                    board[x, temp[0]] = 'e';
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            randDirec = rand.Next(1, 101);
                        }
                        break;

                    //Same as Catch 1, but Left
                    case 3:
                        tempPlaced = true;
                        try
                        {
                            for (int x = temp[0]; x > temp[0] - length; x--)
                            {
                                randDirec++;
                                if (board[temp[1], x] != ' ')
                                {
                                    tempPlaced = false;
                                    randDirec = rand.Next(1, 101);
                                }
                            }
                            if (tempPlaced)
                            {
                                placed = true;
                                Direction = 'l';
                                Bow[0] = temp[0];
                                Bow[1] = temp[1];
                                for (int x = temp[0]; x > temp[0] - length; x--)
                                {
                                    board[temp[1], x] = 'e';
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            randDirec = rand.Next(1, 101);
                        }
                        break;

                    //Same as Catch 1, buy Right; Additionally if switch statments parm
                    //== Zero, then runs this case
                    default:
                        tempPlaced = true;
                        try
                        {
                            for (int x = temp[0]; x < temp[0] + length; x++)
                            {
                                if (board[temp[1], x] != ' ')
                                {
                                    tempPlaced = false;
                                    randDirec = rand.Next(1, 101);
                                }
                            }
                            if (tempPlaced)
                            {
                                placed = true;
                                Direction = 'r';
                                Bow[0] = temp[0];
                                Bow[1] = temp[1];
                                for (int x = temp[0]; x < temp[0] + length; x++)
                                {
                                    board[temp[1], x] = 'e';
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            randDirec = rand.Next(1, 101);
                        }
                        break;
                }
            }
        }
    }
}
