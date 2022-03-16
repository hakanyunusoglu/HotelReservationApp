using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationNew.Models.Data
{
    public class Contact : BaseEntity
    {
       
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}