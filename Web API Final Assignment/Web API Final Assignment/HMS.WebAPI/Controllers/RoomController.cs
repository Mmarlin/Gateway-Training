using System;
using HMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMS.BAL.Interface;

namespace HMS.WebAPI.Controllers
{
    public class RoomController : ApiController
    {

        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [BasicAuthentication]
        [HttpGet]
        [Route("api/room/GetRoom")]
        public IHttpActionResult GetFilteredRoom([FromBody] Temp model)
        {
            return Ok(_roomManager.GetRooms(model));
        }

        // GET: api/Room/5
        [BasicAuthentication]
        [HttpGet]
        [ActionName("GetAvailable")]
        public IHttpActionResult GetAvailableRoom(int id,[FromBody]Booking model)
        {
            model.RoomID = id;
            return Ok(_roomManager.GetAvailableRoom(model));
        }

        // POST: api/Room
        [BasicAuthentication]
        public IHttpActionResult Post([FromBody]Room model)
        {
            return Ok(_roomManager.CreateRoom(model));
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
