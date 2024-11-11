using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BokningsSystem
{
    internal class Sal: Lokal, IBookable
    {
        public bool Projector { get; set; }
        public Sal(string roomType, byte seats, byte outlets, bool ac, int roomNum, bool projector) : base(roomType, seats, outlets, ac, roomNum)
        {
            Projector = projector;
        }
        public Sal(string roomType, byte seats, byte outlets, bool ac, int roomNum, bool projector, DateTime freeTimeStart, TimeSpan freeTimeStop, int bookingId)
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
            BookingId = bookingId;
        }
        public static void BokningSal(Lokal room)
        {
            Console.WriteLine("Vilken tid vill du boka? (yyyy-MM-dd HH:mm)");
            string timeStart = Console.ReadLine();
            Console.WriteLine("Hur länge vill du boka salen? (HH:mm)");
            string timeStop = Console.ReadLine();
            DateTime myDate = DateTime.ParseExact(timeStart, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan myDateStop = TimeSpan.Parse(timeStop);
            var Book = Program.premises.FirstOrDefault(lok => lok.FreeTimeStart.Equals(myDate));
            if (Book == null)
            {
                int Id = IdCheck(room);
                room.FreeTimeStart = myDate;
                room.FreeTimeStop = myDateStop;
                room.IsBooked = true;
                room.BookingId = Id;
                Program.premises.Add(room);
            }
            else
            {
                Console.WriteLine("Något gick fel, vänligen försök igen");
                Program.Pause();
            }
        }
        public static int IdCheck(Lokal room)
        {
            Random rand = new Random();
            int Id = rand.Next(1000, 9999);
            var Book = Program.premises.FirstOrDefault(lok => lok.BookingId.Equals(Id));
            if (Book != null)
            {
                IdCheck(room);
                return 0;
            }
            else
            {
                Console.WriteLine($"Din bokning är nu genomförd, ditt boknings-ID är {Id}. Vänligen skriv ned detta då det behövs vid avbokning och redigering");
                return Id;
            }
        }
    }
}
