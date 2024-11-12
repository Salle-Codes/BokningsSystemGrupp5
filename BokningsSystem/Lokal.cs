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
        public string RoomType { get; set; } //Rumstypen i form av string
        public int RoomNum { get; set; } //Rumsnummret i form av int
        public byte Seats { get; set; } //Antal säten 
        public byte Outlets { get; set; } //Antal eluttag
        public bool Ac { get; set; } //Om rummet har Ac
        public DateTime FreeTimeStart { get; set; } //Används vid bokning och är starttiden
        public TimeSpan FreeTimeStop { get; set; } //Används vid bokning och är tidsspannet
        public bool IsBooked { get; set; } //Bool för om rummet är bokat eller inte
        public int BookingId { get; set; } //BokningsId
        //Sparar properties vid skapning
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
            //Läser in användarens input och presenterar menyval
            switch (choice)
            {
                case "1":
                    Console.WriteLine("1: Lista lokalerna med egenskaper\n2: Lista lokaler utan egenskaper");
                    var choice2 = (Console.ReadLine());
                    switch (choice2)
                    {
                        case "1":
                            //Listar upp alla lokaler som inte är bokade med alla lokalens egenskaper
                            foreach (Lokal room in premises)
                            {
                                if (room.IsBooked != true)
                                {
                                    Console.WriteLine($"{room.RoomType} {room.RoomNum} har \n{room.Outlets}st eluttag och \n{room.Seats}st sittplatser \nBokningar: Lokalen har inga aktiva bokningar");
                                }
                            }
                            break;
                        case "2":
                            //Listar upp alla lokaler som inte är bokade fast utan egenskaper
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
                            //Listar upp alla bokade lokaler med deras egenskaper och info om bokningar
                            foreach (Lokal room in premises)
                            {
                                if (room.IsBooked == true)
                                {
                                    Console.WriteLine($"{room.RoomType} {room.RoomNum} {room.IsBooked} har \n{room.Outlets}st eluttag och \n{room.Seats}st sittplatser \nBokningar:\n{room.FreeTimeStart} - {room.FreeTimeStart.Add(room.FreeTimeStop)}");
                                }
                            }
                            break;
                        case "2":
                            //Listar upp alla bokade lokaler utan egenskaper men med info om bokningar
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
                    //Läser in användarens input om vilket år de vill lista bokningar ifrån
                    if (int.TryParse(yearChoice, out int year))
                    {
                        //Letar reda på bokningar som som startar på året som matchar användarens input
                        var lokalAmountYear = premises.Where(room => room.FreeTimeStart.Year == year).ToList();
                        if (lokalAmountYear.Count > 0)
                        {
                            //Skriver ut alla lokaler och deras aktiva bokningar under det året
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
            //Tar in alla inputs med felhantering i åtanke
            if (int.TryParse(Console.ReadLine(), out int val))
            {
                Console.WriteLine("Ange rumnummer:");
                if (int.TryParse(Console.ReadLine(), out int roomNum))
                {
                    Console.WriteLine("Ange antal sittplatser:");
                    if (byte.TryParse(Console.ReadLine(), out byte seats))
                    {
                        Console.WriteLine("Ange antal eluttag:");
                        if (byte.TryParse(Console.ReadLine(), out byte outlets))
                        {
                            Console.WriteLine("Finns det AC? (ja/nej):");
                            if (bool.TryParse(Console.ReadLine().ToLower(), out bool ac))
                            {
                                // Skapa ett nytt rum baserat på användarens val
                                switch (val)
                                {
                                    case 1:
                                        Console.WriteLine("Ange antal fönster:");
                                        int windows = Convert.ToInt32(Console.ReadLine());
                                        // Skapa ett nytt grupprum
                                        var newGrupprum = new Grupprum("Grupprum", seats, outlets, ac, roomNum, windows);
                                        Program.premises.Add(newGrupprum);
                                        Console.WriteLine($"Grupprum {roomNum} har lagts till.");
                                        break;
                                    case 2:
                                        Console.WriteLine("Finns det projektor? (ja/nej):");
                                        bool projector = Console.ReadLine()?.ToLower() == "ja";
                                        // Skapa en ny sal
                                        var newSal = new Sal("Sal", seats, outlets, ac, roomNum, projector);
                                        Program.premises.Add(newSal);
                                        Console.WriteLine($"Sal {roomNum} har lagts till.");
                                        break;
                                    default:
                                        Console.WriteLine("Ogiltigt val, försök igen");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val. Försök igen.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
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
            Console.WriteLine("Glöm inte att ta bort alla aktiva bokningar på den lokalen");
            foreach (Lokal room in premises)
            {
                if (room.IsBooked != true)
                {
                    Console.WriteLine($"{room.RoomType} {room.RoomNum}");
                }
            }
            if (int.TryParse(Console.ReadLine(), out int lokalen))
            {
                //Leta efter matchande lokal i listan och tilldela den till en ny variabel
                var lokalDelete = premises.FirstOrDefault(lok => lok.RoomNum.Equals(lokalen) && lok.IsBooked == false);
                var tempCheck = premises.FirstOrDefault(lok => lok.IsBooked.Equals(true) && lok.RoomNum == lokalDelete.RoomNum);

                if (lokalDelete != null && tempCheck == null)
                {
                    // Ta bort lokalen från listan
                    premises.Remove(lokalDelete);
                    Console.WriteLine($"Lokalen {lokalen} har tagits bort.");
                }
                else
                {
                    Console.WriteLine($"Lokalen {lokalen} hittades inte eller så finns det kvar bokningar på den");
                }
            }
            else
            {
               Console.WriteLine("Ogiltig inmatning");
            }
            Program.Pause();
        }
        public static void Booking()
        {
            //Frågar användaren om de vill boka grupprum eller sal
            Console.WriteLine("Vad vill du boka:\n1: Sal\n2: Grupprum");
            //If-sats för felhantering av inmatning
            if (int.TryParse(Console.ReadLine(), out int booking))
            {
                switch (booking)
                {
                    case 1:
                        Console.WriteLine("Vilken sal vill du boka? \nAnge rumnummret:");
                        //Skriver ut alla salar som inte är bokade
                        foreach (Lokal Type in Program.premises)
                        {
                            if (Type.RoomType == "Sal" && !Type.IsBooked)
                            {
                                Console.WriteLine($"{Type.RoomType} {Type.RoomNum}");
                            }
                        }
                        //Tar in inmatning och försöker konvertera
                        if (int.TryParse(Console.ReadLine(), out int choice))
                        {
                            //Söker efter angedda rum och klonar denna
                            Lokal index = (Lokal)Program.premises.FirstOrDefault(x => x.RoomNum == choice).MemberwiseClone();
                            if (index != null)
                            {
                                //skickar in det klonade rummet till bokningsmetoden
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
                        //Skriver ut alla grupprum som inte är bokade
                        foreach (Lokal Type in Program.premises)
                        {
                            if (Type.RoomType == "Grupprum" && !Type.IsBooked)
                            {
                                Console.WriteLine($"{Type.RoomType} {Type.RoomNum}");
                            }
                        }
                        //Tar in inmatning och försöker konvertera
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            //Söker efter angedda rum och klonar denna
                            Lokal index = (Lokal)Program.premises.FirstOrDefault(x => x.RoomNum == choice).MemberwiseClone();
                            if (index != null)
                            {
                                //skickar in det klonade rummet till bokningsmetoden
                                Grupprum.BokningGrupprum(index);
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
                Console.WriteLine("Ange ett korrekt val");
                Program.Pause();
            }
        }

        public static void CancelBooking(List<Lokal> premises)
        {
            Console.WriteLine("Vad är ditt boknings-ID?");
            //int avbokningsId = Convert.ToInt32(Console.ReadLine());
            if (int.TryParse(Console.ReadLine(), out int avbokningsId))
            {
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
            else
            {
                Console.WriteLine("Ogiltligt Id");
                Program.Pause();
            }

        }
        public void ChangeBooking()
        {
                    Console.WriteLine("Vill du : \n1. Ändra tid \n2. Ändra datum");
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
                                    this.FreeTimeStop = newFreeTimeStop;
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
                                    this.FreeTimeStart = newFreeTimeStart;
                                    this.FreeTimeStop = newFreeTimeStop2;
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
        public virtual void DisplayRoomInfo(List<Lokal> premises)
        {
            Console.WriteLine($"Rumstyp: {RoomType}, Rumnummer: {RoomNum}, Sittplatser: {Seats}, Eluttag: {Outlets}, AC: {Ac}");
        }
    }
}


