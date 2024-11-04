using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal interface IBookable
    {
        public static virtual void Booking(Lokal lokal)
        {

        }
        public virtual void CancelBooking()
        {

        }
    }
}
