using E_Commerce.Dto.ProductImageDto;
using E_Commerce.Entities;

namespace E_Commerce.Services.Interfaces;

public interface IImageService
{
    Task<ProductImage> Create(ProductImageDto dto);
}