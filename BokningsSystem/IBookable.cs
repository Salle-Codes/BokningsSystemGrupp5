using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystem
{
    internal interface IBookable
    {
        public void Booking(DateTime freeTimeStart, DateTime freeTimeStop);
        public void CancelBooking();


    }
}
