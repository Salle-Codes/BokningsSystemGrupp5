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
        public Sal(string roomType, byte seats, byte outlets, bool ac, int roomNum, bool projector, DateTime freeTimeStart, TimeSpan freeTimeStop)
        {
            RoomType = roomType;
            Seats = seats;
            Outlets = outlets;
            Ac = ac;
            RoomNum = roomNum;
            IsBooked = true;
            FreeTimeStart = freeTimeStart;
            FreeTimeStop = freeTimeStop;
            Projector = projector;
        }
        public static void BokningSal(Lokal room, string timeStart, string timeStop)
        {
            DateTime myDate = DateTime.ParseExact(timeStart, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan myDateStop = TimeSpan.Parse(timeStop);
            Program.premises.Add(new Sal (room.RoomType, room.Seats, room.Outlets, room.Ac, room.RoomNum, true, myDate, myDateStop));
        }
    }
}
