using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public abstract class AlgorithmBase : IAlgorithm
    {
        protected InitializeProblemHandler initializeProblemHandler;
        protected bool isAlgorithmTriggered = false;

        public virtual void Initialize(InitializeProblemHandler initializeProblemHandler)
        {
            
        }

        public virtual void Run()
        {
            isAlgorithmTriggered = true;
            initializeProblem();
            solveProblem();
            outputResult();
        }

        protected abstract void initializeProblem();
        protected abstract void solveProblem();
        protected abstract void outputResult();
    }
}
