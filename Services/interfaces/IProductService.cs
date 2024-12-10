
using E_Commerce.Dto.Product;
using E_Commerce.Entities;

namespace E_Commerce.Services.Interfaces;

public interface IProductService
{
    Task<Product> Create(ProductDto dto);
    Task Update(ProductDto dto);
    Task Delete(long id);

}