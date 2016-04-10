using System;
using System.Collections.Generic;
using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTest
{
    [TestClass]
    public class DijkstraTest
    {
        [TestInitialize()]
        public void Initialize()
        {
           
        }

        [TestMethod]
        public void CorrectnessTest1()
        {
            Dijkstra dijkstra = new Dijkstra(0, 3);
            dijkstra.Run();
            dijkstra = new Dijkstra(0, 3, () =>
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
            });
            dijkstra.Run();
            Assert.AreEqual(dijkstra.OptimalResult, 6);
        }

        [TestMethod]
        public void CorrectnessTest2()
        {
            Dijkstra dijkstra = new Dijkstra(0, 4, () =>
            {
                int graphSize = 6;
                return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
                {
                    new Edge(7, 0, 1),
                    new Edge(15, 1, 3),
                    new Edge(6, 3, 4),
                    new Edge(9, 4, 5),
                    new Edge(14, 5, 0),
                    new Edge(9, 0, 2),
                    new Edge(10, 1, 2),
                    new Edge(11, 2, 3),
                    new Edge(2, 2, 5)
                }, false);
            });
            dijkstra.Run();
            Assert.AreEqual(20, dijkstra.OptimalResult);
        }
    }
}
