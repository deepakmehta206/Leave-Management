using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_Management.Models;
namespace Leave_Management.EntityConfiguration
{
    public class LeaveHistoryConfiguration:IEntityTypeConfiguration<LeaveHistory>
    {
        public void Configure(EntityTypeBuilder<LeaveHistory> builder)
        {
            builder.ToTable("tbl_Leave_History");

            builder.HasKey(k => k.Id);

            builder.HasOne(o => o.RequestingEmployee)
                .WithMany(p => p.leaveHistories)
                .HasForeignKey(f => f.RequestingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.LeaveType)
                .WithMany(m => m.leaveHistories)
                .HasForeignKey(f => f.LeaveTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(o => o.ApprovedBy)
            //    .WithMany(m => m.leaveHistories)
            //    .HasForeignKey(f => f.ApprovedById);
        }
    }
}
