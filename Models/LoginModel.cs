using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeMarket.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập Password")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}