using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class User : BaseEntity
    {
        [Required]

        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
 
        public DateTime? LastLogin { get; set; }

        public string PhoneNumber { get; set; }

        public string Adres { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public int PostalCode { get; set; }

        public bool? isAdmin { get; set; }


    }
}