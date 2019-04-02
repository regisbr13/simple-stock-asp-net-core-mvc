using Microsoft.EntityFrameworkCore;
using SimpleStock.Data;
using SimpleStock.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleStock.Services
{
    public class CategoryService
    {
        private readonly StockContext _context;

        public CategoryService(StockContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task InsertAsync(Category obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Category.FindAsync(id);
                _context.Category.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Category obj)
        {
            bool hasAny = await _context.Category.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                return;
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw;
            }
        }
    }
}
