﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ReservationDtos
{
    public class CreateReservationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int CarId { get; set; }
        public int Age { get; set; }
        public int DrivingLicenceYear { get; set; }
        public string Description { get; set; }
    }
}
