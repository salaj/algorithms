using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.bases;

namespace Algorithms.algorithms
{
    public class BFS :GraphBase
    {
        private Vertex[] order;
        private bool[] visited;
        private Queue<Vertex> queue; 
        private int StartVertexIndex;
        private int vertexId;
        private bool preOrder;

        private InitializeProblemHandler defaultInitializeProblemHandler => () =>
        {
            int graphSize = 5;
            return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
            {
                new Edge('a', 'b'),
                new Edge('b', 'e'),
                new Edge('b', 'd'),
                new Edge('e', 'd'),
                new Edge('a', 'c'),
                new Edge('b', 'c'),
            }, false);
        };

        public BFS(int StartVertexIndex, bool preOrder = true, InitializeProblemHandler initializeProblemHandler = null)
        {
            this.StartVertexIndex = StartVertexIndex;
            this.preOrder = preOrder;
            if (initializeProblemHandler == null)
                base.Initialize(defaultInitializeProblemHandler);
            else
                base.Initialize(initializeProblemHandler);
        }


        protected override void initializeProblem()
        {
            order = new Vertex[graph.VertexCount];
            visited = new bool[graph.VertexCount];
            queue = new Queue<Vertex>();
            vertexId = 0;
            Vertex StartVertex = new Vertex(StartVertexIndex);
            queue.Enqueue(StartVertex);
            visited[StartVertex.Id] = true;
        }

        protected override void solveProblem()
        {
            while (queue.Count > 0)
            {
                Vertex vertex = queue.Dequeue();
                order[vertex.Id].Id = vertexId++;
                foreach (var edge in graph.EdgesOut[vertex])
                {
                    if (!visited[edge.End.Id])
                    {
                        visited[edge.End.Id] = true;
                        queue.Enqueue(edge.End);
                    }
                }
            }
        }

        private void traverseGraph(Vertex vertex)
        {
            foreach (var edge in graph.EdgesOut[vertex])
            {
                if (!visited[edge.End.Id])
                {
                    visited[edge.End.Id] = true;
                    if (preOrder)
                        order[edge.End.Id].Id = vertexId++;
                    traverseGraph(edge.End);
                    if (!preOrder)
                        order[edge.End.Id].Id = vertexId++;
                }
            }
        }

        public bool IsGraphCoherent()
        {
            if (!isAlgorithmTriggered)
                Run();
            return visited.All(v => v);
        }

        protected override void outputResult()
        {
            string add = preOrder ? "pre" : "post";
            Console.WriteLine("Vertex {0} order:", add);
            int i = 0;
            foreach (var vertex in order)
            {
                Console.WriteLine("{0}: vertex number {1}", i++, vertex.Id);
            }
        }
    }
}
