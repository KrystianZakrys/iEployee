using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts
{
    public class AddressSaveModel
    {
        public String Country { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
        public String Street { get; set; }
    }
}
