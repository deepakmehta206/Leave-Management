using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<LeaveHistory> leaveHistories { get; set; }
        public ICollection<LeaveAllocation> LeaveAllocation { get; set; }
    }
}
