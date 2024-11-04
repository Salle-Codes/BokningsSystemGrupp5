using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Grupprum: Lokal
    {
        public int Windows { get; set; }
        public Grupprum(string roomType, byte seats, byte outlets, bool ac, int roomNum, int windows) : base(roomType, seats, outlets, ac, roomNum)
        {
            Windows = windows;
        }

    }
}
