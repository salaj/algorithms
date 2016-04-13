using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.algorithms;

namespace Algorithms
{
    public class Graph : IGraph
    {
        public IDictionary<Vertex, IList<Edge>> EdgesOut { get; }
        public IDictionary<Vertex, IList<Edge>> EdgesIn { get; }

        private bool isDirected;

        public bool IsDirected => isDirected;

        public bool IsCoherent => new DFS(0, true, () =>
        {
            return this;
        }).IsGraphCoherent();

        public int EdgesCount => EdgesOut.Sum(list => list.Value.Count);

        public int VertexCount => EdgesOut.Count;

        public Graph(int n, bool isDirected = true)
        {
            this.isDirected = isDirected;
            EdgesOut = new Dictionary<Vertex, IList<Edge>>();
            EdgesIn = new Dictionary<Vertex, IList<Edge>>();
            for (int i = 0; i < n; i++)
            {
                EdgesOut.Add(new KeyValuePair<Vertex, IList<Edge>>(new Vertex(i), new List<Edge>()));
                EdgesIn.Add(new KeyValuePair<Vertex, IList<Edge>>(new Vertex(i), new List<Edge>()));
            }
        }

        public void AddEdge(int w = 0, int b = 0, int e = 0)
        {
            EdgesOut[new Vertex(b)].Add(new Edge(b, e, w));
            EdgesIn[new Vertex(e)].Add(new Edge(b, e, w));
            if (!isDirected)
            {
                EdgesOut[new Vertex(e)].Add(new Edge(e, b, w));
                EdgesIn[new Vertex(b)].Add(new Edge(e, b, w));
            }
        }

        public void AddEdges(IList<Edge> edges)
        {
            foreach (var edge in edges)
            {
                EdgesOut[edge.Begin].Add(edge);
                EdgesIn[edge.End].Add(edge);
                if (!isDirected)
                {
                    EdgesOut[edge.End].Add(edge.Reverse);
                    EdgesIn[edge.Begin].Add(edge.Reverse);
                }
            }
        }

        public void RemoveEdge(Edge e)
        {
            EdgesOut[new Vertex(e.Begin.Id)].Remove(e);
            EdgesIn[new Vertex(e.End.Id)].Remove(e);
            if (!isDirected)
            {
                var edgeReverse = e.Reverse;
                EdgesOut[new Vertex(edgeReverse.Begin.Id)].Remove(edgeReverse);
                EdgesIn[new Vertex(edgeReverse.End.Id)].Remove(edgeReverse);
            }
        }
    }
}
