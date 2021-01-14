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
    public class BookingController : ApiController
    {

        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        // GET: api/Booking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        [BasicAuthentication]
        public IHttpActionResult Post([FromBody]Booking model)
        {
            return Ok(_bookingManager.CreateBooking(model));
        }

        // PUT: api/Booking/putDate/5
        [BasicAuthentication]
        [HttpPut]
        [ActionName("putDate")]
        public IHttpActionResult Put(int id, [FromBody]Booking model)
        {
            model.ID = id;
            return Ok(_bookingManager.UpdateBookingDate(model));
        }

        // PUT: api/Booking/putStatus/5
        [BasicAuthentication]
        [HttpPut]
        [ActionName("putStatus")]
        public IHttpActionResult PutStatus(int id, [FromBody] Booking model)
        {
            model.ID = id;
            return Ok(_bookingManager.UpdateBookingStatus(model));
        }

        // DELETE: api/Booking/5
        [BasicAuthentication]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_bookingManager.DeleteBooking(id));
        }
    }
}
