using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts
{
    public class ProjectSaveModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<EmployeeSaveModel> Employees { get; set; }
    }
}
