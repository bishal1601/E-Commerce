using E_Commerce.Data;
using E_Commerce.Dto.Product;
using E_Commerce.Entities;
using E_Commerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Services;

public class ProductService: IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }
    //Create product 
    public async  Task<Product> Create(ProductDto dto)
    {
        var product = new Product()//entity
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            Stock = dto.Stock,
            CategoryId = dto.CategoryId,
            VendorId = dto.VendorId,
            Status = dto.Status,
        };
        product.CreatedAt = DateTime.Now.ToUniversalTime();
        product.UpdatedAt = DateTime.Now.ToUniversalTime();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;

    }
    //Edit Product
    public async Task Update(ProductDto dto)
    {
        var product = await _context.Products.FindAsync(dto.Id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Description = dto.Description;
        product.Stock = dto.Stock;
        product.CategoryId = dto.CategoryId;
        product.VendorId = dto.VendorId;
        product.Status = dto.Status;
        await _context.SaveChangesAsync();
    }
    //Delecte product
    public async Task Delete(long id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}