using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Grupprum: Lokal, IBookable
    {
        public Grupprum(string name, byte seats, byte outlets, bool ac) : base(name, seats, outlets, ac)
        {
        }

        public int Size { get; set; }

    }
}
