using System.Collections.Generic;

namespace TreasureHunt
{
    public interface IMap
    {
        List<Adventurer> Adventurers { get; set; }
        int Height { get; set; }
        int Width { get; set; }

        string GetFormattedMapDimensions();
        IEnumerable<string> GetFormattedMapStringList();
        Tile GetTile(int x, int y);
        bool IsOutofBounds(int x, int y);
        bool IsValidMoveLocation(int x, int y);
    }
}