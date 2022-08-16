namespace Api;

public class Store : IStore
{
    private readonly Dictionary<string, Company> _data;

    public Store(List<Company> startingData)
    {
        _data = new Dictionary<string, Company>(startingData.ToDictionary(company => company.Id));
    }

    public IEnumerable<Company> GetAll()
    {
        return _data.Values;
    }

    public Company Get(string id)
    {
        return _data[id];
    }
}

public interface IStore
{
    Company Get(string id);
    IEnumerable<Company> GetAll();
}