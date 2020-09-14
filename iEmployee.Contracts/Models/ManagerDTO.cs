using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts.Models
{
    /// <summary>
    /// Manager entity data transfer object
    /// </summary>
    public class ManagerDTO
    {
        public Guid ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public Guid EmployeeId { get; set; }

        public List<Guid> Subordinates { get; set; }
    }
}
