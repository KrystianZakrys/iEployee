using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts.Criteria
{ 
  /// <summary>
  /// Criteria for filtering employees list.
  /// </summary>
    public class EmployeeCriteria
    {
        /// <summary>
        /// First name of employee.
        /// </summary>
        public String FirstName { get; set; }
        /// <summary>
        /// Last name of employee.
        /// </summary>
        public String LastName { get; set; }
        /// <summary>
        /// Minimal birth date.
        /// </summary>
        public DateTime? MinBirthDate { get; set; }
        /// <summary>
        /// Maximal birth date.
        /// </summary>
        public DateTime? MaxBirthDate { get; set; }
        /// <summary>
        /// Identifier of project that employee is assigned to.
        /// </summary>
        public Guid? ProjectId { get; set; }
        /// <summary>
        /// Identifier of employees actual position.
        /// </summary>
        public Guid? PositionId { get; set; }
    }
}
