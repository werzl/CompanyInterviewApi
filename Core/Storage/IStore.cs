using System.Collections.Generic;

namespace Core.Storage
{
    public interface IStore
    {
        CompanyModel Get(string id);
        IEnumerable<CompanyModel> GetAll();
    }
}