using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IRoomRepository
    {
        String CreateRoom(Room model);

        String GetAvailableRoom(Booking model);

        List<Room> GetRooms(Temp model);
    }
}
