using E_Commerce.Dto.Category;
using E_Commerce.Entities;

namespace E_Commerce.Services.interfaces;

public interface ICategoryService
{
    Task<Category> Create(CategoryDto dto);
    Task Update(CategoryDto dto);
    Task Delete(long id);
}