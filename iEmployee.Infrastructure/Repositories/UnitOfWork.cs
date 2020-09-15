using iEmployee.CommandQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext employeeContext;

        private IEmployeesRepository employeesRepository;

        private IProjectsRepository projectsRepository;

        private IJobHistoryRepository jobHistoryRepository;

        private IManagersRepository managersRepository;

        private IPositionsRepository positionsRepository;


        public UnitOfWork(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public IEmployeesRepository EmployeesRepository
        { 
            get { return employeesRepository ?? new EmployeesRepository(employeeContext); }
        }

        public IProjectsRepository ProjectsRepository
        { 
            get { return projectsRepository ?? new ProjectsRepository(employeeContext); } 
        }

        public IJobHistoryRepository JobHistoryRepository 
        {
            get { return jobHistoryRepository ?? new JobHistoryRepository(employeeContext); }
        }

        public IManagersRepository ManagersRepository
        {
            get { return managersRepository ?? new ManagersRepository(employeeContext); } 
        }

        public IPositionsRepository PositionsRepository 
        {
            get { return positionsRepository ?? new PositionsRepository(employeeContext); } 
        }

        public void Commit()
        {
            employeeContext.SaveChanges();
        }
                

        public void Rollback()
        {
            employeeContext.Dispose();
        }
    }
}
