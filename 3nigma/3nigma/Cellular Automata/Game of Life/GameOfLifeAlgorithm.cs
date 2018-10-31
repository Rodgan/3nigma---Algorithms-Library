using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma.Cellular_Automata.Game_of_Life
{
    public class GameOfLifeAlgorithm
    {
        public List<Cell> Generations
        {
            get { return _Generations ?? (_Generations = new List<Cell>()); }
            set { _Generations = value; }
        }
        private List<Cell> _Generations;

        public void Run()
        {
            int generation = 0;

            while (true)
            {
                var currentGeneration = Generations.Where(x => x.Generation == generation).ToList();

                if (currentGeneration.Count == 0)
                    break;

                var world = new World(
                        currentGeneration.Min(x => x.X) - 1,
                        currentGeneration.Min(x => x.Y) - 1,
                        currentGeneration.Max(x => x.X) + 1,
                        currentGeneration.Max(x => x.Y) + 1);

                for (var x = world.StartX; x <= world.EndX; x++)
                {
                    for (var y = world.StartY; y <= world.EndY; y++)
                    {
                        var neighborhood = currentGeneration.Count(
                                i =>
                                    (i.X >= x -1 && i.X <= x + 1) &&
                                    (i.Y >= y -1 && i.Y <= y + 1) &&
                                    !(i.X == x && i.Y == y)
                            );

                        if (currentGeneration.Any(i => i.X == x && i.Y == y))
                        {
                            if (neighborhood == 2 || neighborhood == 3)
                                Generations.Add(new Cell(x, y, generation + 1));
                        }
                        else
                        {
                            if (neighborhood == 3)
                                Generations.Add(new Cell(x, y, generation + 1));

                        }
                    }
                }
                generation++;    
            }
        }

        public void AddCell(params Cell[] cells)
        {
            foreach (var cell in cells)
            {
                if (!Generations.Any(x => x.Generation == cell.Generation && x.X == cell.X && x.Y == cell.Y))
                    Generations.Add(cell);
            }
        }

    }
}
