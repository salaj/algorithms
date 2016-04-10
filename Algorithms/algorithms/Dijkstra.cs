using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.bases;

namespace Algorithms
{
    public class Dijkstra : GraphBase
    {
        private SortedSet<Node> priorityQueue;
        private IList<int> lengthsFromBeginning;
        private IDictionary<Vertex, Vertex> previousVertex;
        private int StartVertexIndex;
        private int EndVertexIndex;
        private bool[] visited;
        public float OptimalResult { get; set; }

        private InitializeProblemHandler defaultInitializeProblemHandler => () =>
        {
            int graphSize = 6;
            return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
            {
                new Edge(3, 0, 1),
                new Edge(1, 1, 2),
                new Edge(3, 3, 1),
                new Edge(3, 2, 3),
                new Edge(1, 2, 5),
                new Edge(1, 5, 3),
                new Edge(6, 5, 0),
                new Edge(2, 4, 5),
                new Edge(3, 0, 4)
            }, true);
        };

        public Dijkstra(int StartVertexIndex, int EndVertexIndex, InitializeProblemHandler initializeProblemHandler = null)
        {
            this.StartVertexIndex = StartVertexIndex;
            this.EndVertexIndex = EndVertexIndex;
            if (initializeProblemHandler == null)
                base.Initialize(defaultInitializeProblemHandler);
            else
                base.Initialize(initializeProblemHandler);
        }

        protected override void initializeProblem()
        {
            visited = new bool[graph.VertexCount];
            previousVertex = new Dictionary<Vertex, Vertex>(graph.VertexCount);
            lengthsFromBeginning = new List<int>();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                lengthsFromBeginning.Add(int.MaxValue);
                previousVertex[new Vertex(i)] = new Vertex(-1);
            }

            lengthsFromBeginning[StartVertexIndex] = 0;
            priorityQueue = new SortedSet<Node>();
        }

        protected override void solveProblem()
        {
            priorityQueue.Add(new Node { LengthFromBeginning = 0, Vertex = new Vertex(StartVertexIndex) });
            while (priorityQueue.Count > 0)
            {
                Vertex peak = priorityQueue.Min.Vertex;
                priorityQueue.Remove(priorityQueue.Min);
                if (visited[peak.Id])
                    continue;
                visited[peak.Id] = true;
                foreach (var edge in graph.Vertexes[peak])
                {
                    int s = lengthsFromBeginning[peak.Id];
                    int w = edge.Weight;
                    int t = lengthsFromBeginning[edge.End.Id];
                    if (s + w < t)
                    {
                        lengthsFromBeginning[edge.End.Id] = s + w;
                        priorityQueue.Add(new Node { LengthFromBeginning = lengthsFromBeginning[edge.End.Id], Vertex = edge.End });
                        previousVertex[edge.End] = edge.Begin;
                    }
                }
                if (peak.Id == EndVertexIndex)
                    break;
            }
        }

        protected override void outputResult()
        {
            int e = EndVertexIndex;
            OptimalResult = lengthsFromBeginning[e];
            Console.WriteLine("optymalna droga wynosi {0}", lengthsFromBeginning[e]);
            Console.WriteLine("Kolejne wierzchołki odwiedzane");
            int i = e;
            Stack<int> stack = new Stack<int>();
            while (i != -1)
            {
                stack.Push(i);
                i = previousVertex[new Vertex(i)].Id;
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
