using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public struct Edge
    {
        public Edge(int weight = Int32.MaxValue, int begin = 0, int end = 0)
        {
            Begin = new Vertex(begin);
            End = new Vertex(end);
            Weight = weight;
        }

        public Edge Reverse => new Edge(Weight, End.Id, Begin.Id);
        public Vertex Begin { get; set; }
        public Vertex End { get; set; }
        public int Weight { get; }
    }
}
