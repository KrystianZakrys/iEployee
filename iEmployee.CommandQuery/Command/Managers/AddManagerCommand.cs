using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for adding manager <seealso cref="CommandBase{bool}"/><seealso cref="ManagerDTO"/>
    /// </summary>
    public class AddManagerCommand : CommandBase<bool>
    {
        public int RoomNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public List<Guid> Subordinates { get; set; }

        public AddManagerCommand(ManagerDTO manager)
        {
            RoomNumber = manager.RoomNumber;
            EmployeeId = manager.EmployeeId;
            Subordinates = manager.Subordinates;
        }
    }
}
