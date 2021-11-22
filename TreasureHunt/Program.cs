using System;
using System.IO;


namespace TreasureHunt
{
    class Program
    {
        const string outputFileName = "output.txt";
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Exception ex = new("Usage : [InputFileLocation] [OutputFileLocation]");
                Console.WriteLine(ex.Message);
                throw ex;
            }

            var parser = new Parser();
            parser.Parse(args[0]);
            var map_result = Game.Instance.LaunchSimulation(Map.Instance);
            File.WriteAllLines(Path.Combine(args[1], outputFileName), map_result);

        }
    }
}
