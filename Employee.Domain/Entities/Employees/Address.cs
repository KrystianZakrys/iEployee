using iEmployee.Contracts;
using iEmployee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Domain
{
    public class Address : ValueObject
    {
        public String Country { get; private set; }
        public String City { get; private set; }
        public String ZipCode { get; private set; }
        public String Street { get; private set; }

        public static Address CreateFromModel(AddressDTO model)
        {
            return new Address()
            {
                City = model.City,
                Country = model.Country,
                Street = model.Street,
                ZipCode = model.ZipCode
            };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Country;
            yield return Street;
            yield return ZipCode;
        }
    }
}
