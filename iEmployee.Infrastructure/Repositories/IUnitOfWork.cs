using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IEmployeesRepository EmployeesRepository { get; }
        IProjectsRepository ProjectsRepository { get; }
        IJobHistoryRepository JobHistoryRepository { get; }
        IManagersRepository ManagersRepository { get; }
        IPositionsRepository PositionsRepository { get; }

        void Commit();
        void Rollback();
    }
}
