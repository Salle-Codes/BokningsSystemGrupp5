using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BokningsSystem
{
    internal class Sal: Lokal
    {
        //Bool som endast finns för salar
        public bool Projector { get; set; }
        //Sparar properties vid skapning
        public Sal(string roomType, byte seats, byte outlets, bool ac, int roomNum, bool projector) : base(roomType, seats, outlets, ac, roomNum)
        {
            Projector = projector;
        }
        //Sparar properties vid skapning
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
            //Ber användaren inmata datum, tid samt hur länge de vill boka
            Console.WriteLine("Vilken tid vill du boka? (yyyy-MM-dd HH:mm)");
            string timeStart = Console.ReadLine();
            Console.WriteLine("Hur länge vill du boka salen? (HH:mm)");
            string timeStop = Console.ReadLine();
            //Konvertering av datum, vid misslyckande visas felmeddelande
            if (DateTime.TryParse(timeStart, out DateTime myDate))
            {
                //Konvertering av tidsspann, vid misslyckande visas felmeddelande
                if (TimeSpan.TryParse(timeStop, out TimeSpan myDateStop))
                {
                    //Letar efter om det finns dubbelbokningar på samma sal, returnerar null om det inte finns
                    var Book = Program.premises.FirstOrDefault(lok => lok.FreeTimeStart.Equals(myDate) && lok.RoomNum == room.RoomNum);

                    //Sparar klonen samt lägger in information för bokning
                    if (Book == null)
                    {
                        //Ger bokningen ett id för lättare hantering vid redigering/borttagning
                        int Id = IdCheck(room);
                        room.FreeTimeStart = myDate;
                        room.FreeTimeStop = myDateStop;
                        room.IsBooked = true;
                        room.BookingId = Id;
                        //Lägger till det klonade rummet med de nya egenskaperna i listan
                        Program.premises.Add(room);
                    }
                    else
                    {
                        Console.WriteLine("Något gick fel, vänligen försök igen");
                        Program.Pause();
                    }
                }
                else
                {
                    Console.WriteLine("Vänligen skriv ett korrekt datum samt tid");
                    Program.Pause();
                }
            }
            else
            {
                Console.WriteLine("Vänligen skriv ett korrekt datum samt tid");
                Program.Pause();
            }
        }
        public static int IdCheck(Lokal room)
        {
            //skapar ny random och ger int id ett värde mellan 1000-9999
            Random rand = new Random();
            int Id = rand.Next(1000, 9999);
            //Kollar om det id som lagts redan finns eller inte
            var Book = Program.premises.FirstOrDefault(lok => lok.BookingId.Equals(Id));
            //Om det id som lagts redan finns startar metoden om
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
        public override void DisplayRoomInfo()
        {
            base.DisplayRoomInfo();
            Console.WriteLine($"Projektor: {Projector}");
        }
    }
}
