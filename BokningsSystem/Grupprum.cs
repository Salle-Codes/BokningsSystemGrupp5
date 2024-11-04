using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Grupprum: Lokal
    {
        public Grupprum(string roomType, byte seats, byte outlets, bool ac, int roomNum) : base(roomType, seats, outlets, ac, roomNum)
        {
        }

        public int Size { get; set; }

    }
}
