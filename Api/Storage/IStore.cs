namespace Api.Storage;

public interface IStore
{
    CompanyModel Get(string id);
    IEnumerable<CompanyModel> GetAll();
}