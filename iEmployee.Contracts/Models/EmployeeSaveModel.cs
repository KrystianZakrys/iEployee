using System;
using System.Collections.Generic;
using System.Text;
namespace iEmployee.Contracts
{
    public class EmployeeSaveModel
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressSaveModel Address { get; set; }
    }
}
