using E_Commerce.Dto.Category;
using E_Commerce.Entities;

namespace E_Commerce.Services.interfaces;

public interface ICategoryService
{
    Task<Category> Create(CategoryDto dto);
    Task UpdateCategory(CategoryDto dto);
    Task DeleteCategory(long id);
}