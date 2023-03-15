/* Max Harris. Start time: 3pm

    helpful note:
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };


    Solution implementation time: 1hour 14mins

    Debugging time to get the project build: 32 minutes, break time started at 4:56pm


*/

using System.Diagnostics;
using System.Linq;
using System.Text;

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
            int numOfSunkShips = 0;

            foreach(string ship in ships)
            {
                int numOfHits = 0;

                foreach (string guess in guesses)
                {
                    List<string> fullShip = getAllShipCoordinates(ship);
                    Dictionary<string, int> guessXY = DeserializeXY(guess);

                    foreach(string shipCoordinate in fullShip)
                    {
                        Dictionary<string, int> shipCoordXY = DeserializeXY(shipCoordinate);

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

        public static Dictionary<string, int> DeserializeXY(string xy)
        {
            Dictionary<string, int> axisKeyValPair = new Dictionary <string, int>();
            string[] splitXY = xy.Split(':');

            axisKeyValPair.Add("X", Int32.Parse(splitXY[0]));
            axisKeyValPair.Add("Y", Int32.Parse(splitXY[1]));

            return axisKeyValPair;
        }

        public static List<string> getAllShipCoordinates(string shipStartToEnd)
        {
            List<string> allShipCoordinates = shipStartToEnd.Split(',').ToList();

            Dictionary<string, int> shipBow = DeserializeXY(allShipCoordinates[0]);
            Dictionary<string, int> shipStern = DeserializeXY(allShipCoordinates[1]);
            StringBuilder sb = new StringBuilder();
            int diff;
            bool moreThanTwoCoord = false;
            bool isShipBackwards = false;


            #region Insert missing coordinates into list
            if (shipBow["X"] == shipStern["X"])
            {
                int x = shipBow["X"];
                diff = shipStern["Y"] - shipBow["Y"];
                if (diff != 0)
                {
                    diff -= 1;
                }

                if (diff < 0)
                {
                    isShipBackwards = true;
                    diff *= -1;
                }

                if (!isShipBackwards)
                {
                    int position = 0;
                    sb.Append(allShipCoordinates[0]);
                    while (diff > 0)
                    {
                        moreThanTwoCoord = true;
                        sb.AppendLine("," + x.ToString() + ":" + (shipBow["Y"]+position+1).ToString());
                        position++;
                        diff -= 1;
                    }
                    sb.AppendLine("," + allShipCoordinates[1]);
                }
                else
                {
                    int position = 0;
                    sb.Append(allShipCoordinates[1]);
                    while (diff > 0)
                    {
                        moreThanTwoCoord = true;
                        sb.AppendLine("," + x.ToString() + ":" + (shipBow["Y"] + position + 1).ToString());
                        position++;
                        diff -= 1;
                    }
                    sb.AppendLine("," + allShipCoordinates[0]);
                }
            }
            else if (shipBow["Y"] == shipStern["Y"])
            {
                int y = shipBow["Y"];
                diff = shipStern["X"] - shipBow["X"];

                if (diff != 0)
                {
                    diff -= 1;
                }

                if (diff < 0)
                {   
                    isShipBackwards = true;
                    diff *= -1;
                }

                if (!isShipBackwards)
                {
                    int position = 0;
                    sb.Append(allShipCoordinates[0]);
                    while (diff > 0)
                    {
                        moreThanTwoCoord = true;
                        sb.Append("," + y.ToString() + ":" + (shipBow["X"] + position + 1).ToString());
                        position++;
                        diff -= 1;
                    }
                    sb.Append("," + allShipCoordinates[1]);
                }
                else
                {
                    int position = 0;
                    sb.Append(allShipCoordinates[1]);
                    while (diff > 0)
                    {
                        moreThanTwoCoord = true;
                        sb.Append("," + y.ToString() + ":" + (shipBow["X"] + position + 1).ToString());
                        position++;
                        diff -= 1;
                    }
                    sb.Append("," + allShipCoordinates[0]);
                }
            }
            else
            {
                // Do nothing.
            }

            #endregion Insert missing coordinates into list

            if (moreThanTwoCoord)
            {
                string allCoords = sb.ToString();
                Console.WriteLine(allCoords);
                string[] newAllCoords = allCoords.Split(',');
                List<string> finalAllCoords = newAllCoords.ToList();
                return finalAllCoords;
            }
            else
            {
                return allShipCoordinates;
            }      
        }
    }
}
