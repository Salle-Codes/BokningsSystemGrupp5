using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Sal: Lokal
    {
        public Sal(string name, byte seats, byte outlets, bool ac, DateTime freetimeStart, DateTime freetimeStop) : base(name, seats, outlets, ac, freetimeStart, freetimeStop)
        {

        }

        public bool Projector { get; set; }
    }
}
