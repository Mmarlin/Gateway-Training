﻿using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HMS.BAL
{
    public class HotelManager : IHotelManager
    {

        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string CreateHotel(Hotel model)
        {
            return _hotelRepository.CreateHotel(model);
        }

        public List<Hotel> GetAllHotel()
        {
            var hotel = _hotelRepository.GetAllHotels();

            return hotel;
        }
    }
}