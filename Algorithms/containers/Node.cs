using System;

namespace Algorithms
{
    public class Node : IComparable
    {
        public int LengthFromBeginning { get; set; }
        public Vertex Vertex;
        public int CompareTo(object obj)
        {
            var node = obj as Node;
            if (LengthFromBeginning < node.LengthFromBeginning)
                return -1;
            else if (LengthFromBeginning == node.LengthFromBeginning)
                return 0;
            else
            {
                return 1;
            }
        }
    }
}