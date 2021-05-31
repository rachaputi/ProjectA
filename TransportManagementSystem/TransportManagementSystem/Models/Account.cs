using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Account
    {
        [Display(Name="UserName")]
        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }
}
