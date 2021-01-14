using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IBookingManager
    {
        String CreateBooking(Booking model);

        String UpdateBookingDate(Booking model);

        String UpdateBookingStatus(Booking model);

        String DeleteBooking(int ID);

    }
}
