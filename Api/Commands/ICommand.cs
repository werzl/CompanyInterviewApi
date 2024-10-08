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

    public bool IsSuccessful => !_errors.Any();
    public IEnumerable<string> Errors => _errors;

    public static CommandResult Succeed()
    {
        return new CommandResult();
    }

    public static CommandResult Fail(params string[] errors)
    {
        return new CommandResult(errors);
    }
}