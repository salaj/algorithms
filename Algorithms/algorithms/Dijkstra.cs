using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else
            {
                return 1;
            }
        }
    }

    public class Dijkstra : AlgorithmBase
    {

        private IGraph graph;
        private SortedSet<Node> priorityQueue;
        private IList<int> lengthsFromBeginning;
        private IDictionary<Vertex, Vertex> previousVertex;
        private int startVertexIndex;
        private int endVertexIndex;

        protected override void solveProblem()
        {
            priorityQueue.Add(new Node { LengthFromBeginning = 0, Vertex = new Vertex(startVertexIndex) });
            while (priorityQueue.Count > 0)
            {
                Vertex peak = priorityQueue.Min.Vertex;
                priorityQueue.Remove(priorityQueue.Min);
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
                graph.Vertexes[peak].Clear();
                if (peak.Id == endVertexIndex)
                    break;
            }
        }

        protected override void initializeProblem()
        {
            int graphSize = 6;
            createGraph(graphSize);
            startVertexIndex = 0;
            endVertexIndex = 3;

            previousVertex = new Dictionary<Vertex, Vertex>(graphSize);
            lengthsFromBeginning = new List<int>();
            for (int i = 0; i < graphSize; i++)
            {
                lengthsFromBeginning.Add(int.MaxValue);
                previousVertex[new Vertex(i)] = new Vertex(-1);
            }

            lengthsFromBeginning[startVertexIndex] = 0;
            priorityQueue = new SortedSet<Node>();
        }

        protected override void outputResult()
        {
            int e = endVertexIndex;
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

        void createGraph(int graphSize)
        {
            graph = new Graph(graphSize);
            graph.AddEdge(3, 0, 1);
            graph.AddEdge(1, 1, 2);
            graph.AddEdge(3, 3, 1);
            graph.AddEdge(3, 2, 3);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 5, 3);
            graph.AddEdge(6, 5, 0);
            graph.AddEdge(2, 4, 5);
            graph.AddEdge(3, 0, 4);
        }
    }
}
