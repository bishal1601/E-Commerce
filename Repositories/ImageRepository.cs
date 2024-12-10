using E_Commerce.Data;
using E_Commerce.Entities;
using E_Commerce.Models.ProductImageVm;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories;

public class ImageRepository: IImageRepository
{
    private readonly ApplicationDbContext _context;

    public ImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductImage>> GetAll()
    {
        return await _context.ProductImages.ToListAsync();
    }

    public IQueryable<ProductImage> GetQueryable()
    {
        return _context.ProductImages;
    }
    public async Task<List<ProductImageReportVm>> GetByProductId(long productId)
    {
        return await _context.ProductImages
            .Where(img => img.ProductId == productId)
            .Select(img => new ProductImageReportVm
            {
                ProductId = img.ProductId,
                ImageUrl = img.ImageUrl,
                Id = img.Id,
                IsPrimary = img.IsPrimary,
            })
            .ToListAsync();
    }
}