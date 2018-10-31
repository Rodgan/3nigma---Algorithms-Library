using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma.Cellular_Automata.Game_of_Life
{
    public struct Cell
    {
        public Cell(int x, int y, int generation = 0) { X = x;  Y = y; Generation = generation; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Generation { get; set; }
    }
}
