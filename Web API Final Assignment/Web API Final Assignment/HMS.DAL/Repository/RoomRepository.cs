using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {

        private readonly Database.SampleMVCEntities _dbContext;

        public RoomRepository()
        {
            _dbContext = new Database.SampleMVCEntities();
        }

        public string CreateRoom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Database.Room entity = new Database.Room();

                    entity.HotelID = model.HotelID;
                    entity.RoomName = model.RoomName;
                    entity.RoomCategory = model.RoomCategory;
                    entity.RoomPrice = model.RoomPrice;
                    entity.IsActive = model.IsActive;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = model.CreatedBy;

                    _dbContext.Rooms.Add(entity);
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

        public string GetAvailableRoom(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var entity = _dbContext.Bookings.Where(e => e.RoomID == model.RoomID && e.BookingDate == model.BookingDate && e.Status != "Deleted" && e.Status != "Cancelled").ToList();

                    if(entity.Count != 0)
                    {
                        return "False";
                    }
                    else
                    {
                        return "True";
                    }
                }
                return "Data is Null;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Room> GetRooms(Temp model)
        {
            if(model != null)
            {
                var HotelID = _dbContext.Hotels.Where(e => (model.City != null ? e.City == model.City : true)  && (model.Pincode != null ? e.Pincode == model.Pincode : true)).Select(e => e.ID).ToList();

                var entities = _dbContext.Rooms.Where(e => (HotelID.Contains((int)e.HotelID) ? true : false) && (model.Category != null ? e.RoomCategory == model.Category : true) && (model.Price != null ? (e.RoomPrice <= model.Price) : true)).OrderBy(e => e.RoomPrice).ToList();
                List<Room> list = new List<Room>();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        Room room = new Room();

                        room.ID = item.ID;
                        room.HotelID = (int)item.HotelID;
                        room.IsActive = item.IsActive;
                        room.RoomCategory = item.RoomCategory;
                        room.RoomName = item.RoomName;
                        room.RoomPrice = (int)item.RoomPrice;
                        room.UpdateBy = item.UpdateBy;
                        room.UpdateDate = item.UpdateDate;
                        room.CreatedBy = item.CreatedBy;
                        room.CreatedDate = item.CreatedDate;
                        list.Add(room);
                    }
                }
                return list;
            }
            return new List<Room>();
        }
    }
}
