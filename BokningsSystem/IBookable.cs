using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal interface IBookable
    {
        public static virtual void Booking()
        {
            Console.WriteLine("");
        }
        public virtual void CancelBooking()
        {

        }
    }
}
