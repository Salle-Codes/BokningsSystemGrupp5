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
        public static List <Lokal> premises = new List<Lokal>();
        public static void Pause()
        {
            Console.WriteLine("Tryck Enter för att gå vidare");
            Console.ReadLine();
            Console.Clear();
            choice = "";
        }
        public static string Nullable(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text;
            }
            return null;
        }
        public static void WriteList(List<Lokal> list)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText("Bokningar.Json", jsonString);
        }
        public static string? choice;
        static void Main(string[] args)
        {            
            premises = JsonSerializer.Deserialize<List<Lokal>>(File.ReadAllText("Bokningar.Json"));
            while (true)
            {
                Console.WriteLine("Välkommen till Plushögskolans bokninssystem för salar och grupprum!");
                Console.WriteLine("1: Visa bokningar \n2: Boka sal/grupprum\n3: Redigera bokning \n4: Avboka\n5: Lägg till sal/grupprum \n6: Ta bort sal/grupprum\n7: Avsluta");
                choice = Nullable(Console.ReadLine());

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
                        break;
                    case "4":
                        break;
                    case "5":
                        Lokal.New();
                        break;
                    case "6":
                        Lokal.Delete(premises);
                        Pause();
                        break;
                    case null:
                        Console.WriteLine("Något gick fel, vänligen försök igen");
                        Pause();
                        break;
                    case "7":
                        Console.WriteLine("Tack för att du använde vårt bokningssystem!");
                        Pause();
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
