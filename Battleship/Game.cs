

using System.Diagnostics;

namespace Battleship
{
    //   Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.

    
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses

        string[] ships = new string[] { "3:2,3:5" };
        string[] guesses = new string[] { "7:0", "3:3" };
        int shipLength;



        /* 
         *   This method gets all of the coordinates of each ship, then checks the coordinates of the ship against the
         *   guessed coordinates. If a hit is made on each coordinate of a ship, it records each sunk ship.
         *   Once complete it returns an integer of how many ships were sunk.
         *
         *   All tests written in the test class have passed on this method, edge cases were accounted for.
         *
         */ 
        public static int Play(string[] ships, string[] guesses)
        {    
            int numOfSunkShips = 0;

            foreach(string ship in ships)
            {
                int numOfHits = 0;
                List<string> fullShip = Charter.getAllShipCoordinates(ship);

                foreach (string guess in guesses)
                {
                    Dictionary<string, int> guessXY = Charter.DeserializeXY(guess);

                    foreach(string shipCoordinate in fullShip)
                    {
                        Dictionary<string, int> shipCoordXY = Charter.DeserializeXY(shipCoordinate);

                        if((guessXY["X"] == shipCoordXY["X"]) && (guessXY["Y"] == shipCoordXY["Y"]))
                        {
                            numOfHits++;
                            if(numOfHits == fullShip.Count)
                            {
                                numOfSunkShips++;
                            }
                        }
                    }
                }
            }
            return numOfSunkShips;
        }
    }
}
