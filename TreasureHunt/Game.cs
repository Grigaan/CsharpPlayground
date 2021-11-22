using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TreasureHunt
{
    public class Game
    {
        private Map _map;
        
        //public Game(Map map)
        //{            
        //    Map = map;
        //}
        public Game(Map map) 
        {
            _map = map;
        }


        public bool Simulating = false;
       

        public IEnumerable<string> LaunchSimulation()
        {
           
            Simulating = true;

            while (Simulating)
            {
                var remainingAdventurers = _map.Adventurers.Where(adv => !adv.IsDone).ToList();
                if (!remainingAdventurers.Any())
                {
                    Simulating = false;
                    break;
                }
                foreach (Adventurer adventurer in remainingAdventurers)
                {
                    adventurer.Move();
                }
            }
            
            return _map.GetFormattedMapStringList();
        }
    }
}
