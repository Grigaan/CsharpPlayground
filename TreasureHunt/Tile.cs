using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    enum TileType {NONE, PLAIN, MOUNTAIN, TREASURE};
    class Tile
    {
        public bool IsPassable { get; set; }
        public TileType Type { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int TreasureCount { get; set; }
        public Tile(int x, int y)
        {
            Type = TileType.PLAIN; 
            IsPassable = true;
            TreasureCount = 0;
            X = x;
            Y = y;
        }
        
    }
}
