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
        public Grupprum(string roomType, byte seats, byte outlets, bool ac, int roomNum, int windows, DateTime freeTimeStart, TimeSpan freeTimeStop, int id) : base(roomType, seats, outlets, ac, roomNum)
        {
            RoomType = roomType;
            Seats = seats;
            Outlets = outlets;
            Ac = ac;
            RoomNum = roomNum;
            Windows = windows;
            FreeTimeStart = freeTimeStart;
            FreeTimeStop = freeTimeStop;
            BookingId = id;
            IsBooked = true;
        }
        public static void BokningGrupprum(Lokal room, string timeStart, string timeStop)
        {
            Random rand = new Random();
            int Id = rand.Next(1000, 9999);
            DateTime myDate = DateTime.ParseExact(timeStart, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan myDateStop = TimeSpan.Parse(timeStop);
            room.FreeTimeStart = myDate;
            room.FreeTimeStop = myDateStop;
            room.IsBooked = true;
            room.BookingId = Id;
            Program.premises.Add(room);
            //Program.premises.Add(new Grupprum(room.RoomType, room.Seats, room.Outlets, room.Ac, room.RoomNum, 2, myDate, myDateStop, Id));
        }
    }
}
