using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public struct Vertex
    {
        public char Label  => (char)(Id + 'a');
        public Vertex(int v = 0)
        {
            Id = v;
        }
        public int Id { get; set; }
    }
}
