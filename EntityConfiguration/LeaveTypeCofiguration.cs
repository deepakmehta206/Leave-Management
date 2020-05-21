using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_Management.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leave_Management.EntityConfiguration
{
    public class LeaveTypeCofiguration:IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.ToTable("tbl_Leave_Type");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250);
            
        }
    }
}
