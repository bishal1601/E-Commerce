using E_Commerce.Data;
using E_Commerce.Dto.Category;
using E_Commerce.Entities;
using E_Commerce.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Category> Create(CategoryDto dto)
    {
        var category = new Category()
        {
            Name = dto.Name,
            Description = dto.Description,
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task Update(CategoryDto dto)
    {
        var category = await _context.Categories.FindAsync(dto.Id);
        if (category == null)
        {
            throw new Exception("Category not found");
        }

        category.Name = dto.Name;
        category.Description = dto.Description;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var hasProduct = await _context.Products.AnyAsync(p => p.CategoryId == id);
        if (hasProduct)
        {
            throw new InvalidOperationException("Cannot delete the category because it has associated with products.");
        }

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            throw new KeyNotFoundException("Category not found");
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}