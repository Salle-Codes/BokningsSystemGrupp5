using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BokningsSystem
{
    internal class Lokal: IBookable
    {
        public string RoomType { get; set; }
        public int RoomNum { get; set; }
        public byte Seats { get; set; }
        public byte Outlets { get; set; }
        public bool Ac { get; set; }
        public DateTime FreeTimeStart { get; set; }
        public TimeSpan FreeTimeStop { get; set; }
        public bool IsBooked { get; set; } = false;
        public Lokal(string roomType, byte seats, byte outlets, bool ac, int roomNum)
        {
            RoomType = roomType;
            Seats = seats;
            Outlets = outlets;
            Ac = ac;
            RoomNum = roomNum;
        }

        public static void List(List<Lokal> premises)
        {
            foreach (Lokal l in premises)
            {
                Console.WriteLine($"{l.RoomType} har \n{l.Outlets}st eluttag och \n{l.Seats}st sittplatser \nBokningar:\n{l.FreeTimeStart} - {l.FreeTimeStop}");
            }
            //Listar upp alla salar/grupprum med * om den är upptagen samt egenskaper på rummen
        }

        public static void New()
        {
            //skapa nya salar/rum
        }

        public static void Delete(List<Lokal> premises)
        {
            //Ta bort lokal
            Console.WriteLine("Vilken lokal vill du ta bort?");
            var lokalen = Console.ReadLine();
            //Leta efter matchande lokal i listan och tilldela den till en ny variabel
            var lokalDelete = premises.FirstOrDefault(lok => lok.RoomType.Equals(lokalen, StringComparison.OrdinalIgnoreCase));

            if (lokalDelete != null)
            {
                // Ta bort lokalen från listan
                premises.Remove(lokalDelete);
                Console.WriteLine($"Lokal '{lokalen}' har tagits bort.");
            }
            else
            {
                Console.WriteLine($"Lokalen {lokalen} hittades inte.");
            }
        }

        public static void Booking()
        {
            Console.WriteLine("Vad vill du boka:\n1: Sal\n2:Grupprum");
            if (int.TryParse(Console.ReadLine(), out int booking))
            {
                switch (booking)
                {
                    case 1:
                        Console.WriteLine("Vilken sal vill du boka? \nAnge rumnummret:");
                        foreach(Lokal Type in Program.premises)
                        {
                            if (Type.RoomType == "Sal" && !Type.IsBooked)
                            {
                                Console.WriteLine($"{Type.RoomType} {Type.RoomNum}");
                            }
                        }
                        if (int.TryParse(Console.ReadLine(), out int choice))
                        {
                            int index = Program.premises.FindIndex(x => x.RoomNum == choice);
                        }
                        Program.Pause();
                        break;
                    case 2:  
                        
                        break;
                    default:
                        Console.WriteLine("Något gick fel, vänligen försök igen");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Något gick fel, vänligen försök igen");
            }
        }

        public void CancelBooking()
        {
            throw new NotImplementedException();
        }
    }
}
