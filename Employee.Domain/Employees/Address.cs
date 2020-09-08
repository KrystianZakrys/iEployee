using iEmployee.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Domain
{
    public class Address
    {
        public String Country { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
        public String Street { get; set; }

        public static Address Create(string country, string city, string zipCode, string street) 
        {
            return new Address()
            {
                City = city,
                Country = country,
                Street = street,
                ZipCode = zipCode
            };
        }

        public static Address CreateFromModel(AddressSaveModel model)
        {
            return new Address()
            {
                City = model.City,
                Country = model.Country,
                Street = model.Street,
                ZipCode = model.ZipCode
            };
        }
    }
}
