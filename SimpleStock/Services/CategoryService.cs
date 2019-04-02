using Microsoft.EntityFrameworkCore;
using SimpleStock.Data;
using SimpleStock.Models;
using SimpleStock.Services.Exceptions;
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
            return await _context.Category.Include(p => p.Products).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            bool hasAny = await _context.Product.AnyAsync(x => x.CategoryId == id);
            if (!hasAny)
            {
                var obj = await _context.Category.FindAsync(id);
                _context.Category.Remove(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new IntegrityException("Não é possível a exclusão pois existem produtos nesta categoria");
            }
        }

        public async Task UpdateAsync(Category obj)
        {
            bool hasAny = await _context.Category.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
