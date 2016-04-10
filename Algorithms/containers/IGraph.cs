using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IGraph
    {
        IDictionary<Vertex, IList<Edge>> Vertexes { get; }
        bool IsDirected { get; }
        int EdgesCount { get; }
        int VertexCount { get; }
        void AddEdge(int w = 0, int b = 0, int e = 0);
        void AddEdges(IList<Edge> edges);
        void RemoveEdge(Edge e);
    }
}
