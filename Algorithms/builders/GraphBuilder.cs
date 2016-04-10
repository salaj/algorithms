using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class GraphBuilder : Builder
    {
        private static GraphBuilder instance;

        public static GraphBuilder Instance
        {
            get
            {
                if (instance == null)
                    instance = new GraphBuilder();
                return instance;
            }
        }

        private GraphBuilder() { }
        public override dynamic Build(dynamic p1, dynamic p2, dynamic p3)
        {
            int n = (int)p1;
            IList<Edge> edges = (IList<Edge>) p2;
            bool isDirected = (bool) p3;
            IGraph toRet = new Graph(n,isDirected);
            toRet.AddEdges(edges);
            return toRet;
        }
    }
}
