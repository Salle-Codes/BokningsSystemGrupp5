using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Lokal: IBookable
    {
        public string Name { get; set; }

        public byte Seats { get; set; }
        public byte Outlets { get; set; }
        public bool Ac { get; set; }
        public DateTime FreeTimeStart { get; set; }
        public DateTime FreeTimeStop { get; set; }
        public Lokal(string name, byte seats, byte outlets, bool ac)
        {
            Name = name;
            Seats = seats;
            Outlets = outlets;
            Ac = ac;
        }

        public static void List(List<Lokal> premises)
        {
            foreach (Lokal l in premises)
            {
                Console.WriteLine($"{l.Name} har \n{l.Outlets}st eluttag och \n{l.Seats}st sittplatser \nBokningar:\n{l.FreeTimeStart} - {l.FreeTimeStop}");
            }
            //Listar upp alla salar/grupprum med * om den är upptagen samt egenskaper på rummen
        }

        public static void New()
        {
            //skapa nya salar/rum
        }

        public static void Delete(List<Lokal> lokaler)
        {
            //Ta bort lokal
            Console.WriteLine("Vilken lokal vill du ta bort?");
            var lokalen = Console.ReadLine();
            //Leta efter matchande lokal i listan och tilldela den till en ny variabel
            var lokalDelete = lokaler.FirstOrDefault(lok => lok.Name.Equals(lokalen, StringComparison.OrdinalIgnoreCase));

            if (lokalDelete != null)
            {
                // Ta bort lokalen från listan
                lokaler.Remove(lokalDelete);
                Console.WriteLine($"Lokal '{lokalen}' har tagits bort.");
            }
            else
            {
                Console.WriteLine($"Lokalen {lokalen} hittades inte.");
            }
        }

        public void Booking(DateTime freeTimeStart, DateTime freeTimeStop)
        {
            FreeTimeStart = freeTimeStart;
            FreeTimeStop = freeTimeStop;
            throw new NotImplementedException();
        }

        public void CancelBooking()
        {
            throw new NotImplementedException();
        }
    }
}
