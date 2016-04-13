using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public struct Edge
    {
        public Edge(int begin = 0, int end = 0, int weight = Int32.MaxValue)
        {
            Begin = new Vertex(begin);
            End = new Vertex(end);
            Weight = weight;
        }

        public Edge(char begin = 'a', char end = 'a', int weight = Int32.MaxValue)
        {
            Begin = new Vertex(begin - 'a');
            End = new Vertex(end - 'a');
            Weight = weight;
        }

        public char From => (char) (Begin.Id + 'a');
        public char To => (char)(End.Id + 'a');

        public Edge Reverse => new Edge(End.Id, Begin.Id, Weight);
        public Vertex Begin { get; set; }
        public Vertex End { get; set; }
        public int Weight { get; }
    }
}
