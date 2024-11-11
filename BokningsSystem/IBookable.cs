using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal interface IBookable
    {
        //Bokningsmetod
        public virtual void Booking()
        {

        }
        //Metod för att ta bort bokning
        public virtual void CancelBooking()
        {

        }
    }
}
