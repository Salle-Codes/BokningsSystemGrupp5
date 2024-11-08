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
            Console.WriteLine(vertical + $"7: Avsluta".PadRight(30) + vertical);

            Console.Write(bottomLeft);
            for (int i = 0; i < 30; i++)
            {
                Console.Write(horizontal);
            }
            Console.WriteLine(bottomRight);
        }
        public static string? choice;
        static void Main(string[] args)
        {
            //Testlokaler
            premises.Add(new Grupprum("Grupprum", 8, 4, true, 1, 2));
            premises.Add(new Grupprum("Grupprum", 80, 40, true, 2, 2));
            premises.Add(new Grupprum("Grupprum", 1, 254, true, 3, 2));
            premises.Add(new Sal("Sal", 8, 4, true, 4, false));
            premises.Add(new Sal("Sal", 80, 4, true, 5, true));
            premises.Add(new Sal("Sal", 1, 25, true, 6, true));
            
            while (true)
            {
                Console.WriteLine("Välkommen till Plushögskolans bokninssystem för salar och grupprum!");
                Console.WriteLine("1: Visa bokningar \n2: Boka sal/grupprum\n3: Redigera bokning \n4: Avboka \n5: Lägg till sal/grupprum \n6: Ta bort sal/grupprum\n7: Avsluta");
                PrintMenu(new string[] { "Visa bokningar", "Boka sal/grupprum", "Redigera bokning", "Avboka", "Lägg till sal/grupprum", "Ta bort sal/grupprum" });
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
