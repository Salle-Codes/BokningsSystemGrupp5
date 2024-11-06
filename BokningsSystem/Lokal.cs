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
        public bool IsBooked { get; set; }
        public Lokal(string roomType, byte seats, byte outlets, bool ac, int roomNum)
        {
            RoomType = roomType;
            Seats = seats;
            Outlets = outlets;
            Ac = ac;
            RoomNum = roomNum;
            IsBooked = false;
        }
        public Lokal()
        {
            
        }

        public static void List(List<Lokal> premises)
        {
            foreach (Lokal room in premises)
            {
                //if (room.IsBooked == true)
                {
                    Console.WriteLine($"{room.RoomType} {room.RoomNum} {room.IsBooked} har \n{room.Outlets}st eluttag och \n{room.Seats}st sittplatser \nBokningar:\n{room.FreeTimeStart} - {room.FreeTimeStart.Add(room.FreeTimeStop)}");
                }
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
            Console.WriteLine("Vilken lokal vill du ta bort? Ange nummer:");
            foreach (Lokal room in premises)
            {
                Console.WriteLine($"{room.RoomType} {room.RoomNum}");
            }
            int lokalen = Convert.ToInt32(Console.ReadLine());
            //Leta efter matchande lokal i listan och tilldela den till en ny variabel
            var lokalDelete = premises.FirstOrDefault(lok => lok.RoomNum.Equals(lokalen));

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
            Console.WriteLine("Vad vill du boka:\n1: Sal\n2: Grupprum");
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
                            Lokal index = Program.premises.FirstOrDefault(x => x.RoomNum == choice);
                            if (index != null)
                            {
                                Console.WriteLine("Vilken tid vill du boka? (yyyy-MM-dd HH:mm)");
                                string tempString = Console.ReadLine();
                                Console.WriteLine("Hur länge vill du boka salen? (HH:mm)");
                                string tempAmount = Console.ReadLine();
                                Sal.BokningSal(index, tempString, tempAmount);
                            }
                            else
                            {
                                Console.WriteLine("Ingen sal hittades");
                            }
                        }
                        Program.Pause();
                        break;
                    case 2:
                        Console.WriteLine("Vilken sal vill du boka? \nAnge rumnummret:");
                        foreach (Lokal Type in Program.premises)
                        {
                            if (Type.RoomType == "Sal" && !Type.IsBooked)
                            {
                                Console.WriteLine($"{Type.RoomType} {Type.RoomNum}");
                            }
                        }
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            Lokal index = Program.premises.FirstOrDefault(x => x.RoomNum == choice);
                            if (index != null)
                            {
                                Console.WriteLine("Vilken tid vill du boka? (yyyy-MM-dd HH:mm)");
                                string tempString = Console.ReadLine();
                                Console.WriteLine("Hur länge vill du boka salen? (HH:mm)");
                                string tempAmount = Console.ReadLine();
                                Sal.BokningSal(index, tempString, tempAmount);
                            }
                            else
                            {
                                Console.WriteLine("Ingen sal hittades");
                            }
                        }
                        Program.Pause();
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
