using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryByIdAsync(long id);
        Task AddCountryAsync(Country country);
        Task UpdateCountryAsync(Country country);
        Task DeleteCountryAsync(long? id);
    }
}
