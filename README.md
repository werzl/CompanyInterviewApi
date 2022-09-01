# CompanyInterviewApi
Api for paired programming during interview process

Multiple solutions are available for working in .NET 6, .NET 5 and .NET Core 3.1.
Run `dotnet --version` and open the sln file for the lates matching version

  
# Tasks
## Api
- Add an optional search parameter to the Get All endpoint based on a company's name. Users can pass a string and companies that have names which contain the string should be returned
- 404 handler - Currently the Get Single Company crashes when given a company id that doesnt exist. This should return a 404
- Create Company - Add a new route to add a new company to the in memory store

## Tests
- Implement basic unit tests to assert `GetAll` and `Get(id)` return the correct list of companies.
  - See the TODO comments in `StoreTests.cs`

## Buyout 
The buyout command allows a company to purchase another. This is done by updating multiple fields on the child company.

> In this system commands should not throw exceptions for business errors. Errors should be returned in the command response.

- The buyout command is not currently updating the Fax number of the child company. Write a failing test to prove this and then make the test pass by fixing the issue.

- The buyout command has some failure cases (company not found. company trying to buy itself). 
Write failing tests to prove these cases are not protected against and then make the tests pass by fixing the code.

## Reference
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
- https://github.com/bchavez/Bogus
- https://xunit.net/docs/getting-started/netcore/visual-studio
