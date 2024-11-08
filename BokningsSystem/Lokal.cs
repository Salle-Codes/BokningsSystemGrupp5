using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BokningsSystem
{
    internal class Lokal : IBookable
    {
        public string RoomType { get; set; }
        public int RoomNum { get; set; }
        public byte Seats { get; set; }
        public byte Outlets { get; set; }
        public bool Ac { get; set; }
        public DateTime FreeTimeStart { get; set; }
        public TimeSpan FreeTimeStop { get; set; }
        public bool IsBooked { get; set; }
        public int BookingId { get; set; }
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
            Console.WriteLine("1: Lista alla lediga lokaler\n2: Lista alla bokade lokaler\n");
            var choice = (Console.ReadLine());

            switch (choice)
            {
                case "1":
                    Console.WriteLine("1: Lista lokalerna med egenskaper\n2: Lista lokaler utan egenskaper");
                    var choice2 = (Console.ReadLine());
                    switch (choice2)
                    {
                        case "1":
                            foreach (Lokal room in premises)
                            {
                                if (room.IsBooked != true)
                                {
                                    Console.WriteLine($"{room.RoomType} {room.RoomNum} har \n{room.Outlets}st eluttag och \n{room.Seats}st sittplatser \nBokningar: Lokalen har inga aktiva bokningar");
                                }
                            }
                            break;
                        case "2":
                            foreach (Lokal room in premises)
                            {
                                if (room.IsBooked != true)
                                {
                                    Console.WriteLine($"{room.RoomType} {room.RoomNum} Har inga aktiva bokningar");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Ogiltig input");
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("1: Lista alla lokaler med egenskaper\n2: Lista alla lokaler utan egenskaper");
                    var choice3 = Console.ReadLine();
                    switch (choice3)
                    {
                        case "1":
                            foreach (Lokal room in premises)
                            {
                                if (room.IsBooked == true)
                                {
                                    Console.WriteLine($"{room.RoomType} {room.RoomNum} {room.IsBooked} har \n{room.Outlets}st eluttag och \n{room.Seats}st sittplatser \nBokningar:\n{room.FreeTimeStart} - {room.FreeTimeStart.Add(room.FreeTimeStop)}");
                                }
                            }
                            break;
                        case "2":
                            foreach (Lokal room in premises)
                            {
                                if (room.IsBooked == true)
                                {
                                    Console.WriteLine($"{room.RoomType} {room.RoomNum} \nBokningar:\n{room.FreeTimeStart} - {room.FreeTimeStart.Add(room.FreeTimeStop)}");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Ogiltig input");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Ogiltig input");
                    break;
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
                        foreach (Lokal Type in Program.premises)
                        {
                            if (Type.RoomType == "Sal" && !Type.IsBooked)
                            {
                                Console.WriteLine($"{Type.RoomType} {Type.RoomNum}");
                            }
                        }
                        if (int.TryParse(Console.ReadLine(), out int choice))
                        {
                            Lokal index = (Lokal)Program.premises.FirstOrDefault(x => x.RoomNum == choice).MemberwiseClone();
                            if (index != null)
                            {
                                
                                Sal.BokningSal(index);
                            }
                            else
                            {
                                Console.WriteLine("Ingen sal hittades");
                            }
                        }
                        Program.Pause();
                        break;
                    case 2:
                        Console.WriteLine("Vilket grupprum vill du boka? \nAnge rumnummret:");
                        foreach (Lokal Type in Program.premises)
                        {
                            if (Type.RoomType == "Grupprum" && !Type.IsBooked)
                            {
                                Console.WriteLine($"{Type.RoomType} {Type.RoomNum}");
                            }
                        }
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            Lokal index = (Lokal)Program.premises.FirstOrDefault(x => x.RoomNum == choice).MemberwiseClone();
                            if (index != null)
                            {
                                Grupprum.BokningGrupprum(index); //Hej test2
                            }
                            else
                            {
                                Console.WriteLine("Inget grupprum hittades");
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

        public void CancelBooking(List<Lokal>premises)
        {
            Console.WriteLine("Vad är ditt boknings-ID?");
            int avbokningsId = Convert.ToInt32(Console.ReadLine());
            //Leta efter matchande bokning i listan och tilldela den till en ny variabel
            var bokningDelete = premises.FirstOrDefault(a => a.BookingId.Equals(avbokningsId));

            if (bokningDelete != null)
            {
                //Ta bort bokningen från listan
                premises.Remove(bokningDelete);
                Console.WriteLine($"Bokningen med ID: {avbokningsId} har tagits bort.");
            }
            else
            {
                Console.WriteLine($"En bokning med ID: {avbokningsId} hittades inte.");
            }
        }
    }
}
