using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts.Criteria
{ 
    public class EmployeeCriteria
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? MinBirthDate { get; set; }
        public DateTime? MaxBirthDate { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? PositionId { get; set; }
    }
}
