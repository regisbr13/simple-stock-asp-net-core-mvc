using Microsoft.EntityFrameworkCore;
using SimpleStock.Data;
using SimpleStock.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleStock.Services
{
    public class ProductService
    {
        private readonly StockContext _context;

        public ProductService(StockContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task InsertAsync(Product obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Product.FindAsync(id);
                _context.Product.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Product obj)
        {
            bool hasAny = await _context.Product.AnyAsync(x => x.Id == obj.Id);
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

