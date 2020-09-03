using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Domain
{
    public class Address
    {
        public String Country { get; protected set; }
        public String City { get; protected set; }
        public String ZipCode { get; protected set; }
        public String Street { get; protected set; }
    }
}
