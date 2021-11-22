using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    enum MapIdentifier
    {
        Mountain,Treasure,Adventurer
    }
    public class Map : IMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Tile[,] Tiles;
        public List<Adventurer> Adventurers { get; set; }

        private const string MOUNTAIN_ID = "M";
        private const string TREASURE_ID = "T";
        private const string ADVENTURER_ID = "A";
        private const string MAP_SETTINGS_ID = "C";

        public Map(IEnumerable<string> lines)
        {
            var firstLine = lines.ElementAt(0).Split("-", StringSplitOptions.RemoveEmptyEntries);

            // TODO Check int value
            Width = int.Parse(firstLine[1]);
            Height = int.Parse(firstLine[2]);

            Tiles = new Tile[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Tiles[i, j] = new Tile(i, j);
                }
            }

            Adventurers = new();

            foreach (string line in lines.Skip(1))
            {
                var currentLine = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                currentLine = Utils.RemoveWhiteSpaceInStrArray(currentLine);

                switch (currentLine[0])
                {
                    case MOUNTAIN_ID:
                        Console.WriteLine("MOUNTAIN");
                        Tiles[int.Parse(currentLine[1]), int.Parse(currentLine[2])].Type = TileType.MOUNTAIN;
                        break;
                    case TREASURE_ID:
                        Console.WriteLine("TREASURE");
                        var tile = Tiles[int.Parse(currentLine[1]), int.Parse(currentLine[2])];
                        tile.Type = TileType.TREASURE;
                        tile.TreasureCount = int.Parse(currentLine[3]);
                        break;
                    case ADVENTURER_ID:
                        Adventurer adventurer = new(currentLine[1], currentLine[2], currentLine[3], Utils.GetOrientationFromString(currentLine[4]), currentLine[5], this);
                        Adventurers.Add(adventurer);
                        break;
                    default:
                        break;
                }



            }

        }



        public string GetFormattedMapDimensions()
        {
            return string.Format("C - {0} - {1}", Width, Height);
        }

        public Tile GetTile(int x, int y)
        {
            return Tiles[x, y];
        }

        public IEnumerable<string> GetFormattedMapStringList()
        {
            List<string> resultList = new();
            resultList.Add(GetFormattedMapDimensions());
            Tile[] tiles = Tiles.Cast<Tile>().ToArray();

            var mountainTiles = tiles.Where(item => item.Type == TileType.MOUNTAIN).ToList();
            foreach (Tile t in mountainTiles)
            {
                resultList.Add(string.Format("{0} - {1} - {2}", MOUNTAIN_ID, t.X, t.Y));
            }

            var treasureTiles = tiles.Where(item => item.TreasureCount > 0).ToList();
            foreach (Tile t in treasureTiles)
            {
                resultList.Add(string.Format("{0} - {1} - {2} - {3}", TREASURE_ID, t.X, t.Y, t.TreasureCount));
            }

            foreach (Adventurer av in Adventurers)
            {
                resultList.Add(string.Format("{0} - {1} - {2} - {3} - {4} - {5}", ADVENTURER_ID, av.Name, av.PosX, av.PosY, Utils.GetStringFromOrientation(av.Orientation), av.TreasureCount));
            }

            return resultList;

        }


        public bool IsValidMoveLocation(int x, int y)
        {
            if (IsOutofBounds(x, y))
            {
                var tile = Tiles[x, y];
                if (tile.IsPassable)
                    return true;
            }
            return false;
        }

        public bool IsOutofBounds(int x, int y)
        {
            return x >= 0 && x <= Width - 1 && y >= 0 && y <= Height - 1;
        }





    }
}
