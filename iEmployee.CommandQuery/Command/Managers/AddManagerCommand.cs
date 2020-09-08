using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class AddManagerCommand : CommandBase<bool>
    {
        public int RoomNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public List<Guid> Subordinates { get; set; }

        public AddManagerCommand(int roomNumber, Guid employeeGuid, List<Guid> subordinates)
        {
            this.RoomNumber = roomNumber;
            this.EmployeeId = employeeGuid;
            this.Subordinates = subordinates;
        }
        public AddManagerCommand(ManagerSaveModel manager)
        {
            this.RoomNumber = manager.RoomNumber;
            this.EmployeeId = manager.EmployeeId;
            this.Subordinates = manager.Suboridnates;
        }
    }
}
