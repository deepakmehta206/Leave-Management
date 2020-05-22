using System;
using System.Collections.Generic;
using System.Text;
using Leave_Management.EntityConfiguration;
using Leave_Management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Leave_Management.ViewModels;

namespace Leave_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LeaveTypeCofiguration());
            builder.ApplyConfiguration(new LeaveHistoryConfiguration());
            builder.ApplyConfiguration(new LeaveAllocationConfiguration());

        }
        public DbSet<Leave_Management.ViewModels.LeaveTypeVM> DetailsLeaveTypeVM { get; set; }
    }
}
