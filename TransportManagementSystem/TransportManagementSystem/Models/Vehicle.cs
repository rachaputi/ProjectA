using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TransportManagementSystem.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehicleAllocation = new HashSet<VehicleAllocation>();
        }
        [Required(ErrorMessage = "Please enter Vehicle Number")]
        public string VehicleNumber { get; set; }
        [Required(ErrorMessage = "Please enter Vehicle Capacity")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Please enter Available Seats")]
        public int AvailableSeats { get; set; }
        [Required(ErrorMessage = "Please Select Ac Available or Not")]
        public string IsAc { get; set; }
        [Required(ErrorMessage = "Please Select Is Operable or Not")]
        public string IsOperable { get; set; }
        [Required(ErrorMessage = "Please enter Morning Arrival Time of Vehicle")]
        public DateTime MorningArrival { get; set; }
        [Required(ErrorMessage = "Please enter Morning Depature Time of Vehicle")]
        public DateTime MorningDepature { get; set; }
        [Required(ErrorMessage = "Please enter Evening Arrival Time of Vehicle ")]
        public DateTime EveningArrival { get; set; }
        [Required(ErrorMessage = "Please enter Evening Depature Time of Vehicle ")]
        public DateTime EveningDepature { get; set; }
        [Required(ErrorMessage = "Please enter Vehicle Route Number")]
        public int RouteNumber { get; set; }

        public virtual Route RouteNumberNavigation { get; set; }
        public virtual ICollection<VehicleAllocation> VehicleAllocation { get; set; }
    }
}
