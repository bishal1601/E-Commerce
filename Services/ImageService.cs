using E_Commerce.Data;
using E_Commerce.Dto.ProductImageDto;
using E_Commerce.Entities;
using E_Commerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services;

public class ImageService : IImageService
{
    private readonly ApplicationDbContext _context;

    public ImageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductImage> Create(ProductImageDto dto)
    {
        if (string.IsNullOrEmpty(dto.ImageUrl) || dto.ProductId <= 0)
        {
            throw new ArgumentException("Invalid product image data.");
        }

        // Check if a primary image already exists for the product
        var primaryImageExists = await _context.ProductImages
            .AnyAsync(i => i.IsPrimary && i.ProductId == dto.ProductId);

        // Create a new ProductImage entity
        var productImage = new ProductImage
        {
            ImageUrl = dto.ImageUrl,
            ProductId = dto.ProductId,
            IsPrimary = !primaryImageExists // Set as primary only if no other primary image exists
        };

        // Add the new image to the database
        await _context.ProductImages.AddAsync(productImage);
        await _context.SaveChangesAsync();

        return productImage;
    }

}