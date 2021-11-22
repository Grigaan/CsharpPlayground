using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    public enum Orientation
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    class Adventurer
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Orientation Orientation { get; set; }
        public string MoveSequence { get; set; }
        public int TreasureCount { get; set; }
        public Tile CurrentTile { get; set; }
        public int CurrentTurn { get; set; }
        public bool IsDone { get; set; }




        private const string FORWARD_ACTION = "A";
        private const string TURN_LEFT_ACTION = "G";
        private const string TURN_RIGHT_ACTION = "D";

        public Adventurer(string name, string posX, string posY, Orientation orientation, string moveSequence)
        {
            Name = name;
            PosX = int.Parse(posX);
            PosY = int.Parse(posY);
            Orientation = orientation;
            MoveSequence = moveSequence;
            TreasureCount = 0;
            CurrentTurn = 0;
            IsDone = false;
            CurrentTile = Map.Instance.Tiles[PosX, PosY];

            Console.WriteLine("{0} spawns at {1},{2}", Name, PosX, PosY);
        }

        public void Move()
        {
            string action = MoveSequence.ElementAt(CurrentTurn).ToString();
            Console.WriteLine("{0} has the action : {1}", Name, action);
            switch (action)
            {
                case FORWARD_ACTION:
                    ComputeForwardAction();
                    break;
                case TURN_LEFT_ACTION:
                    Orientation = (Orientation != 0) ? Orientation - 1 : Orientation.WEST;
                    Console.WriteLine("{0} turns left. New orientation is {1}.", Name, Orientation.ToString());
                    break;
                case TURN_RIGHT_ACTION:
                    Orientation = (Orientation != Orientation.WEST) ? Orientation + 1 : Orientation.NORTH;
                    Console.WriteLine("{0} turns right. New orientation is {1}.", Name, Orientation.ToString());
                    break;
                default:
                    break;
            }

            if (CurrentTurn != MoveSequence.Length - 1)
            {
                CurrentTurn++;
                Console.WriteLine("{0} new turn number is {1}", Name, CurrentTurn);
            }
               
            else
            {
                IsDone = true;
                Console.WriteLine("{0} is done.", Name);
            }
                
        }

        private void ComputeForwardAction()
        {
            int projectedPosX = PosX;
            int projectedPosY = PosY;
          

            switch (Orientation)
            {
                case Orientation.NORTH:
                    projectedPosY = PosY - 1;
                    break;
                case Orientation.EAST:
                    projectedPosX = PosX + 1;
                    break;
                case Orientation.SOUTH:
                    projectedPosY = PosY + 1;
                    break;
                case Orientation.WEST:
                    projectedPosX = PosX - 1;
                    break;
                default:
                    break;
            }

            if (Map.Instance.IsValidMoveLocation(projectedPosX, projectedPosY))
            {
                CurrentTile.IsPassable = true;
                CurrentTile = Map.Instance.Tiles[projectedPosX, projectedPosY];
                CurrentTile.IsPassable = false;
                PosX = projectedPosX;
                PosY = projectedPosY;

                Console.WriteLine("{0} moves to {1},{2}", Name, PosX, PosY);

                if (CurrentTile.TreasureCount > 0)
                {
                    TreasureCount++;
                    CurrentTile.TreasureCount--;
                    Console.WriteLine("{0} found a treasure at {1},{2}. Current treasures : {3}", Name, PosY, PosY, TreasureCount);
                }
            }
        }
    }
}
