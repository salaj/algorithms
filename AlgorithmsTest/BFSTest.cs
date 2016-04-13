using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using Algorithms.algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTest
{
    [TestClass]
    public class BFSTest
    {
        [TestMethod]
        public void CoherentGraph()
        {
            BFS algorithm = new BFS(0, true, () =>
            {
                int graphSize = 5;
                return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
                {
                    new Edge('a', 'b'),
                    new Edge('b', 'e'),
                    new Edge('b', 'd'),
                    new Edge('e', 'd'),
                    new Edge('a', 'c'),
                    new Edge('b', 'c')
                }, false);
            });
            algorithm.Run();
            Assert.AreEqual(true, algorithm.IsGraphCoherent());
        }

        [TestMethod]
        public void IncoherentGraph()
        {
            BFS algorithm = new BFS(0, true, () =>
            {
                int graphSize = 5;
                return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
                {
                    new Edge('a', 'b'),
                    new Edge('b', 'e'),
                    new Edge('a', 'c'),
                    new Edge('b', 'c')
                }, false);
            });
            algorithm.Run();
            Assert.AreEqual(false, algorithm.IsGraphCoherent());
        }
    }
}
