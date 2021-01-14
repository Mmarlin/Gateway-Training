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
    public class RoomManager : IRoomManager
    {

        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public string CreateRoom(Room model)
        {
            return _roomRepository.CreateRoom(model);
        }

        public string GetAvailableRoom(Booking model)
        {
            return _roomRepository.GetAvailableRoom(model);
        }

        public List<Room> GetRooms(Temp model)
        {
            return _roomRepository.GetRooms(model);
        }
    }
}
