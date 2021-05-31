using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TransportManagementSystem.Models
{
    public partial class Route
    {
        public Route()
        {
            Vehicle = new HashSet<Vehicle>();
            VehicleAllocation = new HashSet<VehicleAllocation>();
        }
        [Required(ErrorMessage = "Please enter RouteNumber ")]

        public int RouteNumber { get; set; }
        [Required(ErrorMessage = "Please enter Stop 1")]
        public string Stop1 { get; set; }
        [Required(ErrorMessage = "Please enter Stop 2")]
        public string Stop2 { get; set; }
        [Required(ErrorMessage = "Please enter Stop 3")]
        public string Stop3 { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<VehicleAllocation> VehicleAllocation { get; set; }
    }
}
