using Api.Controllers;

namespace Api.Commands;

public class BuyoutCommand : ICommand<BuyoutRequest>
{
    private readonly IStore _store;
    private readonly ILogger<BuyoutCommand> _logger;

    public BuyoutCommand(IStore store, ILogger<BuyoutCommand> logger)
    {
        _store = store;
        _logger = logger;
    }

    public CommandResult Execute(BuyoutRequest request)
    {
        if (request is null)
        {
            return CommandResult.Fail("request cannot be null");
        }

        var parentCompany = _store.Get(request.ParentCompanyId);
        var childCompany = _store.Get(request.ChildCompanyId);

        childCompany.ParentId = parentCompany.Id;
        childCompany.CompanyName += " Now Owned By " + parentCompany.CompanyName;
        childCompany.Phone += ", " + parentCompany.Phone;

        _logger.LogInformation("Buyout Succeeded Parent: {parent}, Child: {child}", parentCompany.Id, childCompany.Id);
        return CommandResult.Succeed();
    }
}
