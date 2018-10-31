using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma.Cellular_Automata.Game_of_Life
{
    public struct  World
    {
        public World(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
    }
}
