using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for adding employee <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class UpdateManagerCommand : CommandBase<bool>
    {
        public Guid ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public List<Guid> Suboridnates { get; set; }
        /// <summary>
        /// Creates instance of class <see cref="UpdateManagerCommand"/>
        /// </summary>
        /// <seealso cref="ManagerDTO"/>
        /// <param name="id">manager identifier</param>
        /// <param name="manager">manager data transfer object</param>
        public UpdateManagerCommand(Guid id, ManagerDTO manager)
        {
            this.ManagerId = id;
            this.RoomNumber = manager.RoomNumber;
            this.EmployeeId = manager.EmployeeId;
            this.Suboridnates = manager.Suboridnates;
        }
    }
}
