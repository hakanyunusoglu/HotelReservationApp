using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.DTO.User
{
    public class UserRegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
         
         
    }
}