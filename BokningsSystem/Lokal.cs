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
        public bool Ac {  get; set; }
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
                Console.WriteLine($"{l.Name} är bokad {l.FreeTimeStart} - {l.FreeTimeStop}");
            }
            //Listar upp alla salar/grupprum med * om den är upptagen samt egenskaper på rummen
        }

        public static void New ()
        {
            //skapa nya salar/rum
        }

        public static void Delete()
        {
            //Ta bort sal/rum
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
