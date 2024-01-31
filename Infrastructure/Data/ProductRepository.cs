using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        
        }

        public async Task<IReadOnlyList<Product>> getALlProductAsync()
        {
            var typeId = 1;
            var products = _context.products.Where(x => x.producttypeId == typeId).Include( x => x.producttype).ToListAsync();
 
            return await _context.products
                .Include(p => p.productbrand)
                .Include(p => p.producttype)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> getAllProductBrandsAsync()
        {
            return await _context.productbrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> getAllProductTypesAsync()
        {
            return await _context.producttypes.ToListAsync();
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            return await _context.products
                .Include(p => p.productbrand)
                .Include(p => p.producttype)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}