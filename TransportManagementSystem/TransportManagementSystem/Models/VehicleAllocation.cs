using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TransportManagementSystem.Models
{
    public partial class VehicleAllocation
    {
        public int AllocationId { get; set; }
        [Required(ErrorMessage = "Please Select Employee Id ")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please Select Route Number")]
        public int RouteNumber { get; set; }
       
        public string Location { get; set; }
        [Required(ErrorMessage = "Please Select the Vehicle Number")]
        public string VehicleNumber { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Route RouteNumberNavigation { get; set; }
        public virtual Vehicle VehicleNumberNavigation { get; set; }
    }
}
