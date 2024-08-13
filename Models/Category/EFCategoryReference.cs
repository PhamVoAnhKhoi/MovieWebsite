// Models/EFCategoryReference.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
    public class EFCategoryReference : ICategoryReference
    {
        private readonly MovieDbContext _context;

        public EFCategoryReference(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(long? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(long? id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        // public async Task<IEnumerable<Category>> GetCategoriesByLetterAsync(string letter)
        // {
        //     return await _context.Categories
        //         .Where(c => c.Name.StartsWith(letter, StringComparison.OrdinalIgnoreCase))
        //         .ToListAsync();
        // }
    }
}