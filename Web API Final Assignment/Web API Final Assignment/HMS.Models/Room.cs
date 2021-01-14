using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string RoomName { get; set; }
        public string RoomCategory { get; set; }
        public int RoomPrice { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
