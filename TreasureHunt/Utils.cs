using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    public class Utils
    {
        private const string SOUTH_ORIENTATION_IDENTIFIER = "S";
        private const string NORTH_ORIENTATION_IDENTIFIER = "N";
        private const string EAST_ORIENTATION_IDENTIFIER = "E";
        private const string WEST_ORIENTATION_IDENTIFIER = "W";

        public static Orientation GetOrientationFromString(string value)
        {
            return value switch
            {
                SOUTH_ORIENTATION_IDENTIFIER => Orientation.SOUTH,
                NORTH_ORIENTATION_IDENTIFIER => Orientation.NORTH,
                EAST_ORIENTATION_IDENTIFIER => Orientation.EAST,
                WEST_ORIENTATION_IDENTIFIER => Orientation.WEST,
                _ => 0,
            };
        }

        public static string GetStringFromOrientation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.NORTH:
                    return "N";                    
                case Orientation.EAST:
                    return "E";                    
                case Orientation.SOUTH:
                    return "S";                    
                case Orientation.WEST:
                    return "W";                    
                default:
                    break;
            }

            return null;
        }

        public static string RemoveWhitespace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public static string[] RemoveWhiteSpaceInStrArray(string[] str)
        {
            string[] cleanArray = new string[str.Length];
            for(int i = 0; i < str.Length; i++)
            {
                cleanArray[i] = str[i].Replace(" ", "");
            }

            return cleanArray;
        }

       
    }
}
