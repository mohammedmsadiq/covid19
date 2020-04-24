using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using covid19.Models;

namespace covid19.Interfaces
{
    public interface IWorldStatsService
    {
        Task<WorldModel> GetWorldAsync();
        Task<IEnumerable<CountryModel>> GetByCountryListAsync();
    }
}
