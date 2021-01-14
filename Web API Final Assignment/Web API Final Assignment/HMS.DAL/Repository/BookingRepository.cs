using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly Database.SampleMVCEntities _dbContext;

        public BookingRepository()
        {
            _dbContext = new Database.SampleMVCEntities();
        }

        public string CreateBooking(Booking model)
        {
            try
            {
                if (model != null)
                {
                    Database.Booking entity = new Database.Booking();

                    entity.RoomID = model.RoomID;
                    entity.BookingDate = model.BookingDate;
                    entity.Status = model.Status;

                    _dbContext.Bookings.Add(entity);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Data is Null;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int ID)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(ID);
                if (entity != null)
                {

                    entity.Status = "Deleted";

                    _dbContext.SaveChanges();

                    return "Successfully Deleted";
                }
                return "Booking not Found;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBookingDate(Booking model)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(model.ID);
                if (entity != null)
                {

                    entity.BookingDate = model.BookingDate;

                    _dbContext.SaveChanges();

                    return "Successfully Updated";
                }
                return "ID not Found;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBookingStatus(Booking model)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(model.ID);
                if (entity != null)
                {

                    entity.Status = model.Status;

                    _dbContext.SaveChanges();

                    return "Successfully Updated";
                }
                return "ID not Found;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
