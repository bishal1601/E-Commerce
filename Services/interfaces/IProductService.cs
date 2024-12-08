
using E_Commerce.Dto.Product;

namespace E_Commerce.Services.Interfaces;

public interface IProductService
{
    Task Create(ProductDto dto);
    Task Update(ProductDto dto);
    Task Delete(long id);

}