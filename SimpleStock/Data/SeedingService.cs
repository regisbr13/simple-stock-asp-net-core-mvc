using SimpleStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStock.Data
{
    public class SeedingService
    {
        private readonly StockContext _context;

        public SeedingService(StockContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Product.Any() || _context.Category.Any())
            {
                return;
            }

            Category c1 = new Category(1, "Informática");
            Category c2 = new Category(2, "Eletrodomésticos");

            Product p1 = new Product(1, "TV", 2, 500.00, 700.00, c2);
            Product p2 = new Product(2, "Notebook", 1, 1000.00, 1500.00, c1);
            Product p3 = new Product(3, "Geladeira", 3, 1200.00, 1700.00, c2);
            Product p4 = new Product(4, "Fogão", 2, 300.00, 500.00, c2);

            _context.Product.AddRange(p1, p2, p3, p4);
            _context.Category.AddRange(c1, c2);
            _context.SaveChanges();
        }
    }
}
