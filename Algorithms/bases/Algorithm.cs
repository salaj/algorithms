using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public delegate dynamic InitializeProblemHandler();
    public interface IAlgorithm
    {
        void Run();
        void Initialize(InitializeProblemHandler initializeProblemHandler);
    }
}
