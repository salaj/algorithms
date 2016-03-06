using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public abstract class AlgorithmBase : IAlgorithm
    {
        public void Run()
        {
            initializeProblem();
            solveProblem();
            outputResult();
        }

        protected abstract void initializeProblem();
        protected abstract void solveProblem();
        protected abstract void outputResult();
    }
}
