using System;

namespace GameBoard_Project_LaO
{
    /// <summary>
    /// Program for our first day of coding in CS3020
    /// Author: Luke O'Brien
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Reset();
            board.Display();
            board.RandomizeBoard();
            board.Display();
            board.SearchReplace();
            board.Display();
        }
    }
}