﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Domain;
using iEmployee.Domain.Employees;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace iEmployee.CommandQuery
{
    public class iEmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=EmployeeDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Address);
            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Manager>().HasMany(x => x.Suboridnates).WithOne(x => x.Manager);
        }
    }
}