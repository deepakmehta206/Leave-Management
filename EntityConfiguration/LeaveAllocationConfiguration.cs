using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_Management.Models;

namespace Leave_Management.EntityConfiguration
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            builder.ToTable("tbl_Leave_Allocation");
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.Employee)
                .WithMany(o => o.LeaveAllocation)
                .HasForeignKey(f=>f.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.LeaveType)
                .WithMany(m => m.LeaveAllocation)
                .HasForeignKey(f => f.LeaveId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(o => o.LeaveAllocation)
            //    .WithOne(o => o.LeaveType)
            //    .HasForeignKey(f => f.LeaveId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
