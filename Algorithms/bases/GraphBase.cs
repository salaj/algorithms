using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.bases
{
    public abstract class GraphBase : AlgorithmBase
    {
        protected IGraph graph;
        public override void Initialize(InitializeProblemHandler initializeProblemHandler)
        {
            graph = initializeProblemHandler();
            base.Initialize(initializeProblemHandler);
        }
    }
}
