using Bogus;
using Core;
using Core.Storage;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class StoreTests
    {
        private readonly List<CompanyModel> _companies;
        private readonly Store _classUnderTest;

        public StoreTests()
        {
            _companies = new List<CompanyModel>
            {
                CreateRandomCompany(),
                CreateRandomCompany(),
                CreateRandomCompany()
            };

            _classUnderTest = new Store(_companies);
        }

        [Fact]
        public void GetAll()
        {
            // TODO
        }

        [Fact]
        public void GetById()
        {
            // TODO
        }

        private static CompanyModel CreateRandomCompany()
        {
            return new Faker<CompanyModel>()
                .RuleFor(c => c.Id, f => f.Random.String(5))
                .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
                .RuleFor(c => c.ContactName, f => f.Name.FullName())
                .RuleFor(c => c.ContactTitle, f => f.Name.JobTitle())
                .RuleFor(c => c.Address, f => f.Address.StreetAddress())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.Fax, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .Generate();
        }
    }
}
