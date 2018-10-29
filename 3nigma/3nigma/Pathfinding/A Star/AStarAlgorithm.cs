using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma.Pathfinding.A_Star
{
    public class AStarAlgorithm
    {
        public AStarAlgorithm() { }

        Node CurrentNode = null;
        List<Node> OpenNodes = new List<Node>();
        List<Node> ClosedNodes = new List<Node>();
        List<Node> Path = new List<Node>();
        bool Break = false;

        public void CalculateShortestPath(Node source, bool resume = false)
        {
            if (!(resume && Break))
                CurrentNode = source;

            Break = false;
            while (true)
            {
                CurrentNode.ExpandNodes();

                foreach (var linkedNode in CurrentNode.LinkedNodes)
                {
                    if (!OpenNodes.Any(x => x == linkedNode))
                        OpenNodes.Add(linkedNode);
                }

                OpenNodes.Remove(CurrentNode);
                ClosedNodes.Add(CurrentNode);

                if (OpenNodes.Count == 0)
                    throw new Exception("Cannot reach destination");

                CurrentNode = OpenNodes.Where(x => x.Open).OrderBy(x => x.HeuristicDistance).FirstOrDefault();

                if (CurrentNode.DestinationNode == CurrentNode)
                {
                    OpenNodes.Remove(CurrentNode);
                    break;
                }

                if (Break)
                    break;
            }

            while (true)
            {
                Path.Add(CurrentNode);

                if (CurrentNode.ParentNode == null)
                    break;
                else
                    CurrentNode = CurrentNode.ParentNode;
            }

            Path.Reverse();
        }

        public void Pause()
        {
            Break = true;
        }
        public void Resume()
        {
            CalculateShortestPath(null, true);
        }

        public string ShortestPathAsString(string separator)
        {
            return string.Join(separator, Path.Select(x => x.Name));
        }
        public string ShortestPathAsCoordinates(string separator)
        {
            return string.Join(separator, Path.Select(x => x.Coordinates));
        }
        public double ShortestPathLength()
        {
            return Path.Last().HeuristicDistance;
        }

    }
}
