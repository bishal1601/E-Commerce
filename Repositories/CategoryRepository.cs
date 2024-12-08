using E_Commerce.Data;
using E_Commerce.Entities;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetById(long id)
    {
        

        var category = await _context.Categories.FindAsync(id );
        if (category == null)
        {
            throw new KeyNotFoundException("Category not found.");
        }
        return category;

    }
    public List<SelectListItem> GetCategories()
    {
        var category= _context.Categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
        return category;
        
    }
}