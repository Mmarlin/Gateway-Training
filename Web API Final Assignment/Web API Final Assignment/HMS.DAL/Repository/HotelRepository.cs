using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {

        private readonly Database.SampleMVCEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.SampleMVCEntities();
        }

        public string CreateHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {
                    Database.Hotel entity = new Database.Hotel();

                    entity.HotelName = model.HotelName;
                    entity.City = model.City;
                    entity.Address = model.Address;
                    entity.Contact = model.Contact;
                    entity.ContactPerson = model.ContactPerson;
                    entity.CreatedBy = model.CreatedBy;
                    entity.CreatedDate = DateTime.Now;
                    entity.Facebook = model.Facebook;
                    entity.IsActive = model.IsActive;
                    entity.Pincode = model.Pincode;
                    entity.Twitter = model.Twitter;
                    entity.Website = model.Website;

                    _dbContext.Hotels.Add(entity);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Model is Null;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> GetAllHotels()
        {
            var entities = _dbContext.Hotels.OrderBy(e => e.HotelName).ToList();
            List<Hotel> list = new List<Hotel>();

            if(entities != null)
            {
                foreach (var item in entities)
                {
                    Hotel hotel = new Hotel();

                    hotel.ID = item.ID;
                    hotel.HotelName = item.HotelName;
                    hotel.City = item.City;
                    hotel.Address = item.Address;
                    hotel.Contact = item.Contact;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.CreatedDate = item.CreatedDate;
                    hotel.Facebook = item.Facebook;
                    hotel.IsActive = item.IsActive;
                    hotel.Pincode = item.Pincode;
                    hotel.Twitter = item.Twitter;
                    hotel.UpdateDate = item.UpdateDate;
                    hotel.UpdatedBy = item.UpdatedBy;
                    hotel.Website = item.Website;

                    list.Add(hotel);
                }
            }

            return list;
        }

        public Hotel GetHotel()
        {
            Hotel hotel = new Hotel
            {
                ID = 1,
                HotelName = "Honest",
                City = "Rajkot"
            };

            return hotel;
        }
    }
}
