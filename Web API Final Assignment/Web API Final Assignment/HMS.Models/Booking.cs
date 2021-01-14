using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }

    }
}
