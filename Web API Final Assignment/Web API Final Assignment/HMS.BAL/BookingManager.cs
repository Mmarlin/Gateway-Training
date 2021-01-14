using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class BookingManager : IBookingManager
    {

        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public string CreateBooking(Booking model)
        {
            return _bookingRepository.CreateBooking(model);
        }

        public string DeleteBooking(int ID)
        {
            return _bookingRepository.DeleteBooking(ID);
        }

        public string UpdateBookingDate(Booking model)
        {
            return _bookingRepository.UpdateBookingDate(model);
        }

        public string UpdateBookingStatus(Booking model)
        {
            return _bookingRepository.UpdateBookingStatus(model);
        }
    }
}
