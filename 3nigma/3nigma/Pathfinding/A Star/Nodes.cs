using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma.Pathfinding.A_Star
{
    public class Node
    {

        /* ### Properties ### */
        public string Name { get; set; }
        public bool Open { get; set; } = true;

        /* ### Coordinates ### */
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string Coordinates
        {
            get
            {
                var coordinate = X + ";" + Y;

                if (Z > 0)
                    coordinate += ";" + Z;

                return coordinate;
            }
        }

        /* ### Constructor ### */
        public Node(string name, Node destination = null) { Name = name; DestinationNode = destination; }
        public Node(string name, double x, double y, Node destination = null) { Name = name; X = x; Y = y; DestinationNode = destination; }
        public Node(string name, double x, double y, double z, Node destination = null) { Name = name; X = x; Y = y; Z = z; DestinationNode = destination; }

        /* ### Linked Nodes ### */
        public Node DestinationNode
        {
            get { return _DestinationNode; }
            set
            {
                _DestinationNode = value;

                if (value != null)
                    value.SetAsDestination();
            }
        }
        private Node _DestinationNode = null;

        public List<Node> LinkedNodes
        {
            get { return _LinkedNodes ?? (_LinkedNodes = new List<Node>()); }
            set { _LinkedNodes = value; }
        }
        private List<Node> _LinkedNodes;
        
        public Node ParentNode
        {
            get { return _ParentNode; }
            set { _ParentNode = value; }
        }
        private Node _ParentNode = null;

        public void LinkTo(Node node)
        {
            if (node != null && node != this)
            {
                Open = true;
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
        public void LinkTo(params Node[] nodes)
        {
            foreach (var node in nodes)
            {
                LinkTo(node);
            }
        }
        public void SetAsDestination()
        {
            _DestinationNode = this;
        }
        public void SetDestination(Node destination)
        {
            if (destination != this)
                DestinationNode = destination;
            else
                SetAsDestination();
        }

        /* ### Distance ### */
        public double DistanceTraveled
        {
            get
            {
                if (_DistanceTraveled == -1)
                {
                    if (ParentNode == null)
                        _DistanceTraveled = 0;
                    else
                        _DistanceTraveled = ParentNode.DistanceTraveled + DistanceFromParent;
                }

                return _DistanceTraveled;
            }
        }
        private double _DistanceTraveled = -1;
        public double DistanceFromParent
        {
            get
            {
                return ParentNode == null ? 0 : CalculateDistance(this, ParentNode);
            }
        }
        public double DistanceFromDestination
        {
            get
            {
                if (DestinationNode == null)
                    throw new Exception("Error - Destination not set");

                return CalculateDistance(this, DestinationNode);
            }
        }
        public double HeuristicDistance
        {
            get
            {
                return DistanceFromDestination + DistanceTraveled;
            }
        }

        public void ExpandNodes()
        {
            LinkedNodes.ForEach(x => x.ParentNode = this);
            Open = false;
        }
        public double CalculateDistance(Node source, Node destination)
        {
            return Math.Sqrt(
                Math.Pow(destination.X - source.X, 2) +
                Math.Pow(destination.Y - source.Y, 2) +
                Math.Pow(destination.Z - source.Z, 2));
        }

    }

}
