using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IRoomManager
    {
        String CreateRoom(Room model);

        String GetAvailableRoom(Booking model);

        List<Room> GetRooms(Temp model);
    }
}
