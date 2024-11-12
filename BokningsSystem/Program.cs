using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
namespace BokningsSystem
{
    internal class Program
    {
        //Listan med alla rum, både bokade och icke-Bokade
        public static List <Lokal> premises = new List<Lokal>();
        //Paus-metod så användaren hinner läsa allt
        public static void Pause()
        {
            Console.WriteLine("Tryck Enter för att gå vidare");
            Console.ReadLine();
            Console.Clear();
            choice = "";
        }
        //Metod som kollar om det går att konvertera användarinmatning
        public static string Nullable(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text;
            }
            return null;
        }
        public static void PrintMenu(String[] menuItems)
        {
            String topLeft = "╔";
            String topRight = "╗";
            String middleLeft = "╠";
            String middleRight = "╣";
            String bottomLeft = "╚";
            String bottomRight = "╝";
            String horizontal = "═";
            String vertical = "║";

            Console.Clear();
            Console.Write(topLeft);
            for (int i = 0; i < 30; i++)
            {
                Console.Write(horizontal);
            }
            Console.WriteLine(topRight);
            Console.WriteLine(vertical + " ".PadRight(11) + " Meny".PadRight(19) + vertical);
            Console.Write(middleLeft);
            for (int i = 0; i < 30; i++)
            {
                Console.Write(horizontal);
            }
            Console.WriteLine(middleRight);


            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(vertical + $"{i + 1}: {menuItems[i]}".PadRight(30) + vertical);
            }
            Console.WriteLine(vertical + $"8: Avsluta".PadRight(30) + vertical);

            Console.Write(bottomLeft);
            for (int i = 0; i < 30; i++)
            {
                Console.Write(horizontal);
            }
            Console.WriteLine(bottomRight);
        }
        //Metod som skriver in listan på rum i ett dokument
        public static void WriteList(List<Lokal> list)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            //JsonSerialize på listan och options
            string jsonString = JsonSerializer.Serialize(list, options);
            //Skriver in allt i dokument
            File.WriteAllText("Bokningar.Json", jsonString);
        }
        public static string? choice;
        static void Main(string[] args)
        {
            //Läser in dokument och lägger in det i listan varje gång programmet startas
            premises = JsonSerializer.Deserialize<List<Lokal>>(File.ReadAllText("Bokningar.Json"));
            while (true)
            {
                PrintMenu(new string[] { "Visa bokningar", "Boka sal/grupprum", "Redigera bokning", "Avboka", "Lägg till sal/grupprum", "Ta bort sal/grupprum", "Visa info om Lokal" });
                choice = Nullable(Console.ReadLine());
                Lokal lokal = new Lokal();

                switch (choice)
                {
                    case "1":
                        Lokal.List(premises);
                        Pause();
                        break;                        
                    case "2":
                        Lokal.Booking();
                        break;
                    case "3":
                        Console.WriteLine("Ange ditt ID för att ändra boknigen");
                        if (int.TryParse(Console.ReadLine(), out int bookingId))
                        {
                            int index = premises.FindIndex(x => x.BookingId == bookingId && x.IsBooked);
                            if (index != -1)
                            {
                                premises[index].ChangeBooking();
                            }
                            else
                            {
                                Console.WriteLine("Angedda ID hittades ej");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt Id");
                            Program.Pause();
                        }
                        break;
                    case "4":
                        Lokal.CancelBooking(premises);
                        break;
                    case "5":
                        Lokal.New();
                        break;
                    case "6":
                        Lokal.Delete(premises);
                        Pause();
                        break;
                    case null:
                        Console.WriteLine("Vänligen ange ett korrekt val");
                        Pause();
                        break;
                    case "7":
                       lokal.DisplayRoomInfo();
                        foreach (Lokal s in premises.DistinctBy(x=>x.RoomNum).ToList())
                        {
                            s.DisplayRoomInfo();
                        }
                        Pause();
                        break;
                    case "8":
                        Console.WriteLine("Tack för att du använde vårt bokningssystem!");
                        Pause();
                        //Sparar allt i listan varje gång programmet stängs ned
                        WriteList(premises);
                        Environment.Exit(0);
                        break;
                    default:
                        Pause();
                        break;
                }
            }
        }
    }
}
