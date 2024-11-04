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

        public void List()
        {
            //Listar upp alla salar/grupprum med * om den är upptagen samt egenskaper på rummen
        }

        public void New ()
        {
            //skapa nya salar/rum
        }

        public void Delete()
        {
            //Ta bort sal/rum
        }
    }
}
