using System.Collections.Generic;
using Bogus;
using Core;
using Core.Commands;
using Core.Storage;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Tests
{
    public class BuyoutTests
    {
        private readonly Store _store;
        private readonly BuyoutCommand _classUnderTest;
        private readonly CompanyModel _parentCompany;
        private readonly CompanyModel _childCompany;

        public BuyoutTests()
        {
            _parentCompany = CreateRandomCompany();
            _childCompany = CreateRandomCompany();
            _store = new Store(new List<CompanyModel>
        {
            _parentCompany,
            _childCompany
        });

            _classUnderTest = new BuyoutCommand(_store, new NullLogger<BuyoutCommand>());
        }

        [Fact]
        public void When_Request_Is_Null_Result_Is_Not_Successful()
        {
            var response = _classUnderTest.Execute(null);

            Assert.False(response.IsSuccessful);
        }

        [Fact]
        public void When_Buyout_IsPerformed_Result_Is_Successful()
        {
            var response = _classUnderTest.Execute(new BuyoutRequest
            {
                ChildCompanyId = _childCompany.Id,
                ParentCompanyId = _parentCompany.Id
            });

            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void When_Buyout_IsPerformed_ParentName_Is_Appended()
        {
            _classUnderTest.Execute(new BuyoutRequest
            {
                ChildCompanyId = _childCompany.Id,
                ParentCompanyId = _parentCompany.Id
            });

            Assert.Contains(_parentCompany.CompanyName, _childCompany.CompanyName);
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