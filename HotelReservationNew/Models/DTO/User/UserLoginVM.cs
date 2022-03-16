using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.DTO.User
{
    public class UserLoginVM
    {
        [Required(ErrorMessage ="Mail adresini yanlış girdiniz!")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Yanlış şifre girdiniz!")]
        public string Password { get; set; }


    }
}