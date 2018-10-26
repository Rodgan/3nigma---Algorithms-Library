using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma.Pathfinding.A_Star
{
    class Node
    {

        /* ### Properties ### */
        public string Name { get; set; }

        /* ### Coordinates ### */
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        /* ### Constructor ### */
        public Node(string name, Node destination = null) { Name = name; DestinationNode = destination; }
        public Node(string name, double x, double y, Node destination = null) { Name = name; X = x; Y = y; DestinationNode = destination; }
        public Node(string name, double x, double y, double z, Node destination = null) { Name = name; X = x; Y = y; Z = z; DestinationNode = destination; }

        /* ### Linked Nodes ### */
        public Node DestinationNode { get; set; } = null;

        public List<Node> LinkedNodes
        {
            get { return _LinkedNodes ?? (_LinkedNodes = new List<Node>()); }
            set { _LinkedNodes = value; }
        }
        private List<Node> _LinkedNodes;

        /// <summary>
        /// Parent nodes can be added only from parents themselves
        /// </summary>
        public List<Node> ParentNodes
        {
            get { return _ParentNodes ?? (_ParentNodes = new List<Node>()); }
            set { _ParentNodes = value; }
        }
        private List<Node> _ParentNodes;

        public void LinkTo(Node node)
        {
            if (node != null && node != this)
            {
                if (!node.ParentNodes.Any(x => x == this))
                    node.ParentNodes.Add(this);

                if (!LinkedNodes.Any(x => x == node))
                    LinkedNodes.Add(node);
            }
        }
        public void LinkTo(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                LinkTo(node);
            }
        }

        public void UnlinkFrom(Node node)
        {
            if (node != null && node != this)
            {
                if (LinkedNodes.Any(x => x == node))
                    LinkedNodes.Remove(node);

                if (node.ParentNodes.Any(x => x == this))
                    node.ParentNodes.Remove(this);
            }
        }
        public void UnlinkFrom(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                UnlinkFrom(node);
            }
        }

        /* ### Distance ### */
        public double DistanceTraveled { get; set; }
        public double DistanceFromDestination
        {
            get
            {
                if (DestinationNode == null)
                    throw new Exception("Error - Destination not set");

                return CalculateDistance(this, DestinationNode);
            }
        }
        public double CalculateDistance(Node source, Node destination)
        {
            return Math.Sqrt(
                Math.Pow(destination.X - source.X, 2) +
                Math.Pow(destination.Y - source.Y, 2) +
                Math.Pow(destination.Z - source.Z, 2));
        }

    }

    class Path
    {
        public Node SourceNode { get; set; }
        public Node DestinationNode { get; set; }
    }
}
