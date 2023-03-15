using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{

    // PLEASE NOTE: I thought a 'charter' was the name of someone who uses maps, I was wrong. Apologies for the poor naming!
    //                      
    //
    // SOLID: Single Responsibility class for all coordinate mapping methods
    // 
    // OOP: Abstraction: Abstracts all of the functions required in the Game class, to reduce the complexity in the Play() method.

    public class Charter
    {


        // Places XY values of a coordinate into key pair values for easy retrieval
        public static Dictionary<string, int> DeserializeXY(string xy)
        {
            Dictionary<string, int> axisKeyValPair = new Dictionary<string, int>();
            string[] splitXY = xy.Split(':');

            axisKeyValPair.Add("X", Int32.Parse(splitXY[0]));
            axisKeyValPair.Add("Y", Int32.Parse(splitXY[1]));

            return axisKeyValPair;
        }

        /*
         *  This method retrieves all of the coordinates of a ship so that they can be cross checked with the guesses.
         *  
         *  This also accounts for the edge cases of ships facing a different direction e.g. '3:7,3:5'
         * 
         */
        public static List<string> getAllShipCoordinates(string shipStartToEnd)
        {
            List<string> allShipCoordinates = shipStartToEnd.Split(',').ToList();
            Dictionary<string, int> shipBow = DeserializeXY(allShipCoordinates[0]);
            Dictionary<string, int> shipStern = DeserializeXY(allShipCoordinates[1]);
            StringBuilder sb = new StringBuilder();
            int diff =1 ;
            bool moreThanTwoCoord = false;
            bool isShipBackwards = false;


            #region Insert missing coordinates into list
            while (diff != 0)
            {
                if (shipBow["X"] == shipStern["X"])
                {
                    int x = shipBow["X"];
                    diff = shipStern["Y"] - shipBow["Y"];

                    if (diff < 0)
                    {
                        isShipBackwards = true;
                        diff *= -1;
                    }

                    if (diff != 0)
                    {
                        diff -= 1;
                    }

                    if (!isShipBackwards)
                    {
                        int position = 0;
                        sb.Append(allShipCoordinates[0]);
                        while (diff > 0)
                        {
                            moreThanTwoCoord = true;
                            sb.AppendLine("," + x.ToString() + ":" + (shipBow["Y"] + position + 1).ToString());
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
                            sb.AppendLine("," + x.ToString() + ":" + (shipStern["Y"] + position + 1).ToString());
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

                    if (diff < 0)
                    {
                        isShipBackwards = true;
                        diff *= -1;
                    }

                    if (diff != 0)
                    {
                        diff -= 1;
                    }

                    if (!isShipBackwards)
                    {
                        int position = 0;
                        sb.Append(allShipCoordinates[0]);
                        while (diff > 0)
                        {
                            moreThanTwoCoord = true;
                            
                            sb.Append("," + (shipBow["X"] + position + 1).ToString() + ":" + y.ToString());
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
                            sb.Append("," + (shipStern["X"] + position + 1).ToString() + ":" + y.ToString());
                            position++;
                            diff -= 1;
                        }
                        sb.Append("," + allShipCoordinates[0]);
                    }
                }
            }
            #endregion Insert missing coordinates into list

            if (moreThanTwoCoord)
            {
                string allCoords = sb.ToString();
                string[] newAllCoords = allCoords.Split(',');

                // Small introduction to a Linq function, thanks for asking the Linq question during 1st stage!
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
