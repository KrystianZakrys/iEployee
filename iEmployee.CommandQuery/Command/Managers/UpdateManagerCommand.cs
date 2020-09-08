using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class UpdateManagerCommand : CommandBase<bool>
    {
        public Guid ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public List<Guid> Suboridnates { get; set; }

        public UpdateManagerCommand(Guid id, ManagerSaveModel manager)
        {
            this.ManagerId = id;
            this.RoomNumber = manager.RoomNumber;
            this.EmployeeId = manager.EmployeeId;
            this.Suboridnates = manager.Suboridnates;
        }
    }
}
