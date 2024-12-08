using E_Commerce.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll();
    Task<Category> GetById(long id);
    List<SelectListItem> GetCategories();

    
}