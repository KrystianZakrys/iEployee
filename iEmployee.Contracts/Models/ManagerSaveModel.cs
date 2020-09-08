using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts.Models
{
    public class ManagerSaveModel
    {
        public Guid ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public Guid EmployeeId { get; set; }

        public List<Guid> Suboridnates { get; set; }
    }
}
