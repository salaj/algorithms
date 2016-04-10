using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Graph : IGraph
    {
        public IDictionary<Vertex, IList<Edge>> Vertexes { get; }

        private bool isDirected;

        public bool IsDirected => isDirected;

        public int EdgesCount => Vertexes.Sum(list => list.Value.Count);

        public int VertexCount => Vertexes.Count;

        public Graph(int n, bool isDirected = true)
        {
            this.isDirected = isDirected;
            Vertexes = new Dictionary<Vertex, IList<Edge>>();
            for (int i = 0; i < n; i++)
            {
                Vertexes.Add(new KeyValuePair<Vertex, IList<Edge>>(new Vertex(i), new List<Edge>()));
            }
        }

        public void AddEdge(int w = 0, int b = 0, int e = 0)
        {
            Vertexes[new Vertex(b)].Add(new Edge(w, b, e));
            if (!isDirected)
                Vertexes[new Vertex(e)].Add(new Edge(w, e, b));
        }

        public void AddEdges(IList<Edge> edges)
        {
            foreach (var edge in edges)
            {
                Vertexes[edge.Begin].Add(edge);
                if (!isDirected)
                {
                    Vertexes[edge.End].Add(edge.Reverse);
                }
            }
        }

        public void RemoveEdge(Edge e)
        {
            Vertexes[new Vertex(e.Begin.Id)].Remove(e);
            bool a = true;
        }
    }
}
