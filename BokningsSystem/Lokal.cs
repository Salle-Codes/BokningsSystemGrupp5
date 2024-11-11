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
            Console.WriteLine("1: Lista alla lediga lokaler\n2: Lista alla bokade lokaler\n3: Lista alla lokaler från ett specifikt år");
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
                case "3":
                    Console.WriteLine("Ange vilket år du vill lista alla bokningar ifrån:");
                    var yearChoice = Console.ReadLine();
                    if (int.TryParse(yearChoice, out int year))
                    {
                        var lokalAmountYear = premises.Where(room => room.FreeTimeStart.Year == year).ToList();
                        if (lokalAmountYear.Count > 0)
                        {
                            foreach (Lokal room in lokalAmountYear)
                            {
                                Console.WriteLine($"{room.RoomType} {room.RoomNum} \nBokningar:\n{room.FreeTimeStart} - {room.FreeTimeStart.Add(room.FreeTimeStop)}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Inga bokningar hittade för {year}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltligt år");
                    }
                    break;
                default:
                    Console.WriteLine("Ogiltig input");
                    break;
            }
        }

        public static void New()
        {
            //skapa nya salar/rum
            Console.WriteLine("Vad vill du skapa?");
            Console.WriteLine("1: Grupprum");
            Console.WriteLine("2: Sal");
            string? roomTypeChoice = Console.ReadLine();
            if (roomTypeChoice == "1" || roomTypeChoice == "2")
            {
                Console.WriteLine("Ange rumnummer:");
                int roomNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ange antal sittplatser:");
                byte seats = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Ange antal eluttag:");
                byte outlets = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Finns det AC? (ja/nej):");
                bool ac = Console.ReadLine()?.ToLower() == "ja";
                // Skapa ett nytt rum baserat på användarens val
                if (roomTypeChoice == "1")
                {
                    Console.WriteLine("Ange antal fönster:");
                    int windows = Convert.ToInt32(Console.ReadLine());
                    // Skapa ett nytt grupprum
                    var newRoom = new Grupprum("Grupprum", seats, outlets, ac, roomNum, windows);
                    Program.premises.Add(newRoom);
                    Console.WriteLine($"Grupprum {roomNum} har lagts till.");
                }
                else if (roomTypeChoice == "2")
                {
                    Console.WriteLine("Finns det projektor? (ja/nej):");
                    bool projector = Console.ReadLine()?.ToLower() == "ja";
                    // Skapa en ny sal
                    var newRoom = new Sal("Sal", seats, outlets, ac, roomNum, projector);
                    Program.premises.Add(newRoom);
                    Console.WriteLine($"Sal {roomNum} har lagts till.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
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
                Program.Pause();
            }
        }

        public static void CancelBooking(List<Lokal> premises)
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
        public static void ChangeBooking()
        {
            Console.WriteLine("Ange ditt ID för att ändra boknigen");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Lokal bookedRum = Program.premises.FirstOrDefault(x => x.BookingId == bookingId && x.IsBooked);
            if (bookedRum != null)
            {
                Console.WriteLine("Vill du : \n 1. Ändra tid \n 2. Ändra datum");
                if (int.TryParse(Console.ReadLine(), out int changingChoise))
                {
                    switch (changingChoise)
                    {
                        case 1:

                            // Ändra endast antal timmar
                            Console.WriteLine("Ange ny varaktighet för bokningen i timmar (HH:mm):");
                            string newTempAmount = Console.ReadLine();

                            if (TimeSpan.TryParse(newTempAmount, out TimeSpan newFreeTimeStop))
                            {
                                bookedRum.FreeTimeStop = newFreeTimeStop;
                                Console.WriteLine($"Bokningen har uppdaterats. Din bokning har {newFreeTimeStop} Timmar nu.");
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt tidformat. Vänligen ange tid i HH:mm-format.");
                            }
                            break;
                        case 2:

                            Console.WriteLine("Ange ny starttid för bokningen (yyyy-MM-dd HH:mm):");
                            string newStartTime = Console.ReadLine();
                            Console.WriteLine("Ange ny varaktighet i timmar (HH:mm):");
                            string newTempAmount2 = Console.ReadLine();

                            if (DateTime.TryParse(newStartTime, out DateTime newFreeTimeStart) && TimeSpan.TryParse(newTempAmount2, out TimeSpan newFreeTimeStop2))
                            {
                                bookedRum.FreeTimeStart = newFreeTimeStart;
                                bookedRum.FreeTimeStop = newFreeTimeStop2;
                                Console.WriteLine($"Bokningen har uppdaterats till starttid {newFreeTimeStart} i {newFreeTimeStop2} timmar.");
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt datum eller tidformat. Vänligen försök igen.");
                            }
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val. Vänligen välj ett korrekt alternativ.");
                            break;
                    }
                }

            }
        }
    }
}


