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
        public Grupprum(string roomType, byte seats, byte outlets, bool ac, int roomNum, int windows, DateTime freeTimeStart, TimeSpan freeTimeStop) : base(roomType, seats, outlets, ac, roomNum)
        {
            Windows = windows;
        }
        public static void BokningGrupprum(Lokal room, string timeStart, string timeStop)
        {
            DateTime myDate = DateTime.ParseExact(timeStart, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan myDateStop = TimeSpan.Parse(timeStop);
            Program.premises.Add(new Sal(room.RoomType, room.Seats, room.Outlets, room.Ac, room.RoomNum, true, myDate, myDateStop));
        }
    }
}
