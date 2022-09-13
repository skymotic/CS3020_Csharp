using System;

/*
 * REFLECTION:
 * I think this project took me about 3.5 hours in total. (.5 Pre-production)
 * I had spent a good amount of time thinking about how I wanted to place the ships
 * and decided on a vector baised aproch. Once I had how I was going to do that planned out
 * I began to code.
 * 
 * I had the most issue with getting the placement of the ships worked out. This was because
 * The program was getting stuck in an infinate loop, generating infinate potential random bow 
 * positions and wasn't trying the different rotational directions.
*/

/*
 * Name:        Luke O'Brien
 * Assignment:  1
 * Class:       CS3020
 * Due Date:    9/15/2021, 3:05pm
 */

namespace BattleShipOBrien
{
    class Program
    {
        /// <summary>
        /// OOOO. Fancy! Very complex Method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
