namespace BokningsSystem
{
    internal class Program
    {
        public static List <string> Booking = new List<string>();
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
        public static string? choice;
        static void Main(string[] args)
        {
            int Position;
            
            //Testlokaler
            premises.Add(new Lokal("Grupprum", 8, 4, true, 1));
            premises.Add(new Lokal("Grupprum", 80, 40, true, 2));
            premises.Add(new Lokal("Grupprum", 1, 254, true, 3));
            premises.Add(new Lokal("Sal", 8, 4, true, 4));
            premises.Add(new Lokal("Sal", 80, 4, true, 5));
            premises.Add(new Lokal("Sal", 1, 25, true, 6));
            
            while (true)
            {
                Console.WriteLine("Välkommen till Plushögskolans bokninssystem för salar och grupprum!");
                Console.WriteLine("1: Visa bokningar \n2: Boka sal/grupprum\n3: Redigera bokning \n4: Avboka \n5: Lägg till sal/grupprum \n6: Ta bort sal/grupprum\n7: Avsluta");
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
                    default:
                        Pause();
                        break;
                }
            }
        }
    }
}
