using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Domain;
namespace iEmployee.Domain.Employees
{
    public class EmployeeSaveModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressSaveModel Address { get; set; }
    }
}
