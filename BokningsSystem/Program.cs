namespace BokningsSystem
{
    internal class Program
    {
        public static List <string> Booking = new List<string>();
        public static List <Lokal> premises = new List<Lokal>();
        public static void Pause()
        {
            Console.WriteLine("Tryck Enter för att gå vidare");
            Console.Read();
            Console.Clear();
        }
        public static string Nullable(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text;
            }
            return "Null";
        }
        public static string? choice;
        static void Main(string[] args)
        {
            int Position;
            
            //Testlokaler
            premises.Add(new Lokal("Grupprum 1", 8, 4, true));
            premises.Add(new Lokal("Grupprum 2", 80, 40, true));
            premises.Add(new Lokal("Grupprum 3", 1, 254, true));
            Console.WriteLine("Välkommen till Plushögskolans bokninssystem för salar och grupprum!");
            Console.WriteLine("1: Visa bokningar \n2: Boka sal/grupprum\n3: Redigera bokning \n4: Avboka \n5: Lägg till sal/grupprum \n6: Ta bort sal/grupprum\n7: Avsluta");
            choice = Nullable(Console.ReadLine());
            switch (choice)
            {
                case "1":
                    Lokal.List(premises);
                    return;
                case "2":
                    
                    return;
                case "3":
                    return;
                case "4":
                    return;
                case "5":
                    Lokal.New();
                    return;
                case "6":
                    Lokal.Delete(premises);
                    return;
                case "Null":
                    Console.WriteLine("Något gick fel, vänligen försök igen");
                    Pause();
                    return;
                default:
                    return;
            }
        }
    }
}
