/* Max Harris. Start time: 3pm

    helpful note:
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };


    Solution implementation time: 1hour 14mins

    Debugging time to get the project build: 32 minutes, break time started at 4:56pm


*/

using System.Diagnostics;

namespace Battleship
{
    // Imagine a game of battleships.
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

        public static int Play(string[] ships, string[] guesses)
        {
            int numOfHits = 0;
            int numOfSunkShips = 0;

            foreach(string ship in ships)
            {
                string[] fullShip = getAllShipCoordinates(ship);
                //int extraLength = getShipLength(fullShip);

                foreach (string guess in guesses)
                {
                    Dictionary<string, int> guessXY = DeserializeXY(guess);

                    foreach(string shipCoordinate in fullShip)
                    {
                        Dictionary<string, int> shipCoordXY = DeserializeXY(shipCoordinate);

                        if((guessXY["X"] == shipCoordXY["X"]) && (guessXY["Y"] == shipCoordXY["Y"]))
                        {
                            numOfHits++;
                            if(numOfHits == fullShip.Length)
                            {
                                numOfSunkShips++;
                            }
                            //if (numOfHits == (fullShip.Length + extraLength))
                            //{
                            //    numOfSunkShips++;
                            //}
                        }
                    }
                }
            }
            Console.WriteLine(numOfSunkShips);
            return numOfSunkShips;
        }

        public static Dictionary<string, int> DeserializeXY(string xy)
        {
            Dictionary<string, int> axisKeyValPair = new Dictionary <string, int>();
            string[] splitXY = xy.Split(':');

            axisKeyValPair.Add("X", Int32.Parse(splitXY[0]));
            axisKeyValPair.Add("Y", Int32.Parse(splitXY[1]));

            return axisKeyValPair;
        }

        public static string[] getAllShipCoordinates(string shipStartToEnd)
        {
            string[] allShipCoordinates = shipStartToEnd.Split(',');

            Dictionary<string, int> shipBow = DeserializeXY(allShipCoordinates[0]);
            Dictionary<string, int> shipStern = DeserializeXY(allShipCoordinates[1]);

            int diff;

            //bool sharedX = false;
            //bool sharedY = false;


            if (shipBow["X"] == shipStern["X"])
            {
                diff = shipBow["Y"] - shipStern["Y"];
                if (diff != 0)
                {
                    diff += 1;
                }
                if (diff < 0)
                {
                    diff *= -1;
                }

                string[] newAllShip
            }
            else
            {
                diff = shipBow["X"] - shipStern["X"];
                if (diff != 0)
                {
                    diff += 1;
                }
                if (diff < 0)
                {
                    diff *= -1;
                }

            }

            return allShipCoordinates;
        }























        //public static int getShipLength(string[] fullShip)
        //{

        //    Dictionary<string, int> shipBow = DeserializeXY(fullShip[0]);
        //    Dictionary<string, int> shipStern = DeserializeXY(fullShip[1]);

        //    if (shipBow["X"] == shipStern["X"])
        //    {
        //        int yDiff = shipBow["Y"] - shipStern["Y"];
        //        if (yDiff != 0)
        //        {
        //            yDiff += 1;
        //        }
        //        if (yDiff < 0)
        //        {
        //            yDiff*=-1;
        //        }
        //        return yDiff;
        //    }
        //    else
        //    {
        //        int xDiff = shipBow["X"] - shipStern["X"];
        //        if(xDiff != 0)
        //        {
        //            xDiff += 1;
        //        }
        //        if (xDiff < 0)
        //        {
        //            xDiff *= -1;
        //        }
        //        return xDiff;
        //    }
        //}

        //public static string[] getAllShipCoordinates(string shipStartToEnd)
        //{
        //    string[] allShipCoordinates = shipStartToEnd.Split(',');
        //    return allShipCoordinates;
        //}
    }
}
