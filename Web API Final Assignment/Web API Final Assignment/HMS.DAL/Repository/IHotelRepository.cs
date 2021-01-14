using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMS.DAL.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotel();

        List<Hotel> GetAllHotels();

        String CreateHotel(Hotel model);
    }
}
