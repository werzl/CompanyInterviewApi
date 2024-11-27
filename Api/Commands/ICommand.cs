namespace Api.Commands;

public interface ICommand<in TRequest>
{
    CommandResult Execute(TRequest request);
}

public class CommandResult
{
    private readonly IEnumerable<string> _errors;

    private CommandResult(params string[] errors)
    {
        _errors = errors;
    }

    public bool IsSuccessful { get; private set; }
    public IEnumerable<string> Errors => _errors;

    public static CommandResult Succeed()
    {
        IsSuccessful = true;
        return new CommandResult();
    }

    public static CommandResult Fail(params string[] errors)
    {
        IsSuccessful = false;
        return new CommandResult(errors);
    }
}
