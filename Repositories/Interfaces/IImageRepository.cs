
using E_Commerce.Entities;
using E_Commerce.Models.ProductImageVm;

namespace E_Commerce.Repositories.Interfaces;

public interface IImageRepository
{
    Task<List<ProductImage>> GetAll();
    IQueryable<ProductImage> GetQueryable();
    Task<List<ProductImageReportVm>> GetByProductId(long productId);


}