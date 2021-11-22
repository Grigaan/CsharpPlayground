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
            var map = parser.Parse(args[0]);
            var game = new Game(map);
            var map_result = game.LaunchSimulation();
            File.WriteAllLines(Path.Combine(args[1], outputFileName), map_result);

        }
    }
}
