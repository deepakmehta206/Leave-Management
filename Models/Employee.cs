using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoined { get; set; }
        public DateTime? DateOfCreation { get; set; }       
        public ICollection<LeaveHistory> leaveHistories { get; set; }
        public ICollection<LeaveAllocation> LeaveAllocation { get; set; }
    }
}
