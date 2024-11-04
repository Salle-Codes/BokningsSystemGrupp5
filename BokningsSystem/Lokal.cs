using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal class Lokal
    {
        public string Name { get; set; }

        public byte Seats { get; set; }
        public byte Outlets { get; set; }
        public bool Ac {  get; set; }
        public Lokal()
        {
            
        }

            //Patrik gör List, New och Delete-metoderna
        public static void List()
        {
            //Listar upp alla salar/grupprum med * om den är upptagen samt egenskaper på rummen
        }

        public static void New ()
        {
            //skapa nya salar/rum
        }

        public static void Delete()
        {
            //Ta bort sal/rum
        }
    }
}
