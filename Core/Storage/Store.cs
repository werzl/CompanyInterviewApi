using System.Collections.Generic;
using System.Linq;

namespace Core.Storage
{
    public class Store : IStore
    {
        private readonly Dictionary<string, CompanyModel> _data;

        public Store(List<CompanyModel> startingData)
        {
            _data = new Dictionary<string, CompanyModel>(startingData.ToDictionary(company => company.Id));
        }

        public IEnumerable<CompanyModel> GetAll()
        {
            return _data.Values;
        }

        public CompanyModel Get(string id)
        {
            return _data[id];
        }
    }
}