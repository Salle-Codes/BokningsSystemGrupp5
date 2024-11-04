using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Sal: Lokal, IBookable
    {
        public Sal(string roomType, byte seats, byte outlets, bool ac, int roomNum) : base(roomType, seats, outlets, ac, roomNum)
        {
        }

        public bool Projector { get; set; }
    }
}
