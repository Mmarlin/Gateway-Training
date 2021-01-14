using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.WebAPI.Controllers
{
    public class HotelController : ApiController
    {

        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/Hotel
        [BasicAuthentication]
        public List<Hotel> Get()
        {
            var hotel = _hotelManager.GetAllHotel();

            return hotel; 
        }

        // GET: api/Hotel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hotel
        [BasicAuthentication]
        public IHttpActionResult Post([FromBody]Hotel model)
        {
            return Ok(_hotelManager.CreateHotel(model));
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
