using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.algorithms;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //IAlgorithm dijkstra = new Dijkstra(0, 3);
            //dijkstra.Run();
            //IAlgorithm algorithm = new DFS(0, true);
            //algorithm.Run();
            IAlgorithm algorithm = new EulerCycle(0);
            algorithm.Run();
        }
    }
}
