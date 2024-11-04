using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Sal: Lokal, IBookable
    {
        public Sal(string name, byte seats, byte outlets, bool ac) : base(name, seats, outlets, ac)
        {
        }

        public bool Projector { get; set; }
    }
}
