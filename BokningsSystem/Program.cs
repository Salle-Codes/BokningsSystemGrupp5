namespace BokningsSystem
{
    internal class Program
    {
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
        static void Main(string[] args)
        {
            List <string> Booking = new List<string>();
            List <Lokal> lokaler = new List<Lokal>();
            Console.WriteLine("Välkommen till Plushögskolans bokninssystem för salar och grupprum!");
            Console.WriteLine("1: Visa bokningar \n2: Boka sal/grupprum\n3: Redigera bokning \n4: Avboka \n5: Lägg till sal/grupprum \n6: Avsluta");
            string? choice = Console.ReadLine();
            choice = Nullable(choice);
            switch (choice)
            {
                case "1":
                    Lokal.List();
                    return;
                case "2":
                    return;
                case "3":
                    return;
                case "4":
                    return;
                case "5":
                    return;
                case "6":
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
