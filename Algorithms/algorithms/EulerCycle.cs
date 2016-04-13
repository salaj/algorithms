using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.bases;

namespace Algorithms.algorithms
{
    public class EulerCycle : GraphBase
    {
        public bool cycleExist;
        private Stack<Vertex> stack;
        private IList<Vertex> cycle; 
        private int StartVertexIndex;

        private InitializeProblemHandler defaultInitializeProblemHandler => () =>
        {
            int graphSize = 5;
            return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
            {
                new Edge('a', 'b'),
                new Edge('b', 'c'),
                new Edge('b', 'e'),
                new Edge('b', 'd'),
                new Edge('e', 'd'),
                new Edge('a', 'c'),
            }, false);
        };

        public EulerCycle(int StartVertexIndex, InitializeProblemHandler initializeProblemHandler = null)
        {
            this.StartVertexIndex = StartVertexIndex;
            stack = new Stack<Vertex>();
            cycle = new List<Vertex>();
            if (initializeProblemHandler == null)
                base.Initialize(defaultInitializeProblemHandler);
            else
                base.Initialize(initializeProblemHandler);
        }


        protected override void initializeProblem()
        {
            if (!graph.IsCoherent)
                cycleExist = false;
            else
            {
                if (!graph.IsDirected)
                {
                    cycleExist = graph.EdgesOut.Values.All(edges => edges.Count%2 == 0);
                }
                else
                {
                    for (int i = 0; i < graph.VertexCount; i++)
                    {
                        Vertex v = new Vertex(i);
                        if (graph.EdgesIn[v].Count != graph.EdgesOut[v].Count)
                        {
                            cycleExist = false;
                            break;
                        }
                    }
                }
            }
        }

        protected override void solveProblem()
        {
            if (!cycleExist)
                return;
            var StartVertex = new Vertex(StartVertexIndex);
            stack.Push(StartVertex);
            traverseGraph(StartVertex);
        }

        private void traverseGraph(Vertex vertex)
        {
            IList<Edge> edges = graph.EdgesOut[vertex];
            while(edges.Count > 0)
            {
                var edge = edges[0];
                stack.Push(edge.End);
                graph.RemoveEdge(edge);
                traverseGraph(edge.End);
                edges = graph.EdgesOut[vertex];
            }
            while (stack.Count > 0)
            {
                Vertex v = stack.Peek();
                if (graph.EdgesOut[v].Count > 0)
                    return;
                cycle.Add(stack.Pop());
            }
        }

        protected override void outputResult()
        {
            if (!cycleExist)
                Console.WriteLine("Cycle does not exist");
            else
            {
                int i = 0;
                foreach (var vertex in cycle)
                {
                    Console.WriteLine("{0} vertex in cycle is {1}", i++, vertex.Label);
                }
            }
        }
    }
}
