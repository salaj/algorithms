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
                    new Edge(0, 1, 3),
                    new Edge(1, 2, 1),
                    new Edge(3, 1, 3),
                    new Edge(2, 3, 3),
                    new Edge(2, 5, 1),
                    new Edge(5, 3, 1),
                    new Edge(5, 0, 6),
                    new Edge(4, 5, 2),
                    new Edge(0, 4, 3)
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
                    new Edge(0, 1, 7),
                    new Edge(1, 3, 15),
                    new Edge(3, 4, 6),
                    new Edge(4, 5, 9),
                    new Edge(5, 0, 14),
                    new Edge(0, 2, 9),
                    new Edge(1, 2, 10),
                    new Edge(2, 3, 11),
                    new Edge(2, 5, 2)
                }, false);
            });
            dijkstra.Run();
            Assert.AreEqual(20, dijkstra.OptimalResult);
        }
    }
}
