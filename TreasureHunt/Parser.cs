using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace TreasureHunt
{
    class Parser
    {
        private readonly Regex basicFileStructureRX = new (@"^[CMTA](\s\-\s\d){2,3}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public Map Parse(string configFilePath)
        {
            string[] fileContent = File.ReadAllLines(configFilePath);

            //MatchCollection matches = basicFileStructureRX.Matches(fileContent);

            //Console.WriteLine("{0} matches found in:\n   {1}",
            //                  matches.Count,
            //                  fileContent);

            //if (matches.Count != File.ReadLines(configFilePath).Count())
            //{
            //    throw new Exception();
            //}
            //Map.Instance.CreateMap(matches.Select(m => m.Value).ToList());
            //return new Map(matches.Select(m => m.Value).ToList());
            //Map.Instance.CreateMap(fileContent);
            return new Map(fileContent);
        }

        

        
        
    }
}
