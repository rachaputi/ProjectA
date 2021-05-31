using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TransportManagementSystem.Models
{
    public partial class Employee
    {
        public Employee()
        {
            VehicleAllocation = new HashSet<VehicleAllocation>();
        }

        
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
       // [RegularExpression("[a-zA-Z]",ErrorMessage="Name contains only alpahbets")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter Last Name")]
        //[RegularExpression("[a-zA-Z]", ErrorMessage = "Name contains only alpahbets")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Please enter Date of Birth")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Please enter Age ")]
        [Range(0,120, ErrorMessage = "Age must be in between 0 to 120 Years")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Please enter Address ")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please enter Location ")]
        public string Location { get; set; }


        [Required(ErrorMessage = "Please enter Phone Number ")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Phone number should not contain characters")]
        public string Phone { get; set; }

        public virtual ICollection<VehicleAllocation> VehicleAllocation { get; set; }
    }
}
