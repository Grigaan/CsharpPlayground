using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TreasureHunt
{
    class Game
    {
        private Map Map;
        
        //public Game(Map map)
        //{            
        //    Map = map;
        //}
        private Game() { }
        private static Game instance = null;

        public bool Simulating = false;
        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return instance;
            }
        }

        public IEnumerable<string> LaunchSimulation(Map map)
        {
            Map = map;
            Simulating = true;

            while (Simulating)
            {
                var remainingAdventurers = Map.Adventurers.Where(adv => !adv.IsDone).ToList();
                if (remainingAdventurers == null || remainingAdventurers.Count == 0)
                {
                    Simulating = false;
                    break;
                }
                foreach (Adventurer adventurer in remainingAdventurers)
                {
                    adventurer.Move();
                }
            }
            
            return Map.Instance.GetFormattedMapStringList();
        }
    }
}
