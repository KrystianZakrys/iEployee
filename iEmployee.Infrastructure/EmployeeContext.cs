﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Domain;
using iEmployee.Domain.Employees;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;

namespace iEmployee.CommandQuery
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public EmployeeContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Address);
            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Manager>().HasMany(x => x.Subordinates).WithOne(x => x.Manager);

            modelBuilder.Entity<EmployeeProject>().HasKey(x => new {x.EmployeeId, x.ProjectId });
            modelBuilder.Entity<EmployeeProject>().HasOne(x => x.Project).WithMany(p => p.Employees).HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<EmployeeProject>().HasOne(x => x.Employee).WithMany(e => e.Projects).HasForeignKey(x => x.EmployeeId);


            modelBuilder.Entity<JobHistory>().HasKey(x => new { x.Id, x.EmployeeId, x.PositionId });
            modelBuilder.Entity<JobHistory>().HasOne(x => x.Position).WithMany(p => p.JobHistories).HasForeignKey(x => x.PositionId);
            modelBuilder.Entity<JobHistory>().HasOne(x => x.Employee).WithMany(e => e.JobHistories).HasForeignKey(x => x.EmployeeId);

            //Fill database with sample data
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                Position.Create("Developer","D"),
                Position.Create("Fullstack","F"),
                Position.Create("Patron","P"),
                Position.Create("Inspector","I"),
                Position.Create("Architect","A"),
                Position.Create("Tester","T"),
            });

            modelBuilder.Entity<Project>().HasData(new Project[]
            {
                Project.Create(".NET CRUD"),
                Project.Create("Java Mastering Classes"),
                Project.Create("DRINKING COFFER"),
                Project.Create("Mobile app"),
            });
        }
    }
}
