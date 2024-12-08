using E_Commerce.Data;
using E_Commerce.Entities;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAll()
    {
        return _context.Products.ToList();
    }
    public IQueryable<Product> GetQueryable()
    {
        return _context.Products;
    }

    public async Task<Product> GetById(long id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        return product;
        
    }
}