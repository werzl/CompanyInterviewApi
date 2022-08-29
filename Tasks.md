## Api
- Add a Company Name Filter to the Get All endpoint
- 404 handler - Currently the Get Single Company crashes when given a company id that doesnt exist. This should return a 404
- Create Company - Add a new route to add a new company to the in memory store


## Buyout 
The buyout command allows a company to purchase another. This is done by updating multiple fields on the child company.

> In this system commands should not exception for business errors. Errors should be returned in the command response.

- The Buyout command is not currently updating the Fax number of the child company. Write a failing test to prove this and then make the test pass by fixing the issue.

- The buyout command has some failure cases (company not found. company trying to buy itself). 
Write failing tests to prove these cases are not covered and then make them pass by fixing the code.

## Reference
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
- https://github.com/bchavez/Bogus
- https://xunit.net/docs/getting-started/netcore/visual-studio