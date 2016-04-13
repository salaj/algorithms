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
    public class EulerCycleTest
    {
        [TestMethod]
        public void EulerCycleExist()
        {
            EulerCycle algorithm = new EulerCycle(0, () =>
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
            Assert.AreEqual(true, algorithm.cycleExist);
        }

        [TestMethod]
        public void EulerCycleDontExist()
        {
            EulerCycle algorithm = new EulerCycle(0, () =>
            {
                int graphSize = 5;
                return GraphBuilder.Instance.Build(graphSize, new List<Edge>()
                {
                    new Edge(0, 1),
                    new Edge(0, 2),
                    new Edge(0, 3),
                    new Edge(1, 2),
                    new Edge(2, 4),
                    new Edge(3, 4)
                }, false);
            });
            algorithm.Run();
            Assert.AreEqual(false, algorithm.cycleExist);
        }
    }
}
