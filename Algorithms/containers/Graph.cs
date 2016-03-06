using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Graph : IGraph
    {
        public IDictionary<Vertex, IList<Edge> > Vertexes { get; }
        public int EdgesCount => Vertexes.Sum(list => list.Value.Count);
        public int VertexCount => Vertexes.Count;

        public Graph(int n)
        {
            Vertexes = new Dictionary<Vertex, IList<Edge>>();
            for (int i = 0; i < n; i++)
            {
                Vertexes.Add(new KeyValuePair<Vertex, IList<Edge>>(new Vertex(i),new List<Edge>()));
            }    
        }

        public void AddEdge(int w = 0, int b = 0, int e = 0)
        {
            Vertexes[new Vertex(b)].Add(new Edge(w, b, e));
        }

        public void RemoveEdge(Edge e)
        {
            Vertexes[new Vertex(e.Begin.Id)].Remove(e);
        }
    }
}
