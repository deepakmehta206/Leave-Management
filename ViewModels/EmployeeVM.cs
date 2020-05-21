using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.ViewModels
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoined { get; set; }
        public DateTime? DateOfCreation { get; set; }
    }
}
