using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public class EFCountryRepository : ICountryRepository
    {
        private readonly MovieDbContext _context;

        public EFCountryRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(long id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task AddCountryAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCountryAsync(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(long? id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }
    }
}
