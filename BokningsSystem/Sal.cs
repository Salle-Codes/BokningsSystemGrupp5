using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Sal: Lokal, IBookable
    {
        public bool Projector { get; set; }
        public Sal(string roomType, byte seats, byte outlets, bool ac, int roomNum, bool projector) : base(roomType, seats, outlets, ac, roomNum)
        {
            Projector = projector;
        }
        public static void BokningSal(Lokal room, string time)
        {
            DateTime myDate = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);
            Program.premises.Add(new Sal (room.RoomType, room.Seats, room.Outlets, room.Ac, room.RoomNum, true));
            room.IsBooked = true;
            room.FreeTimeStart = myDate;

        }
    }
}
