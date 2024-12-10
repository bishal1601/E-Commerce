using System.Collections.Immutable;
using E_Commerce.Dto.Category;
using E_Commerce.Models.Category;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(
        ICategoryService categoryService,
        ICategoryRepository categoryRepository
    )
    {
        _categoryService = categoryService;
        _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index()
    {
        var category = await _categoryRepository.GetAll();
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var dto = new CategoryDto()
        {
            Name = vm.Name,
            Description = vm.Description,
        };
        try
        {
            await _categoryService.Create(dto);
            TempData["Success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["error"] = e.Message;
            return View(vm);
        }
    }

    public async Task<IActionResult> Update(long id)
    {
        try
        {
            var category = await _categoryRepository.GetById(id);
            var vm = new CategoryEditVm()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            return View(vm);
        }
        catch (Exception e)
        {
            TempData["error"] = e.Message;
            return RedirectToAction("Index");
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, CategoryEditVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        var dto = new CategoryDto()
        {
            Id = vm.Id,
            Name = vm.Name,
            Description = vm.Description
        };
        try
        {
            await _categoryService.Update(dto);
            TempData["Success"] = "Category Updated successfully";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["error"] = e.Message;
            return View("Index");
        }
    }

    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _categoryService.Delete(id);
            TempData["Success"] = "Category deleted successfully.";
        }
        catch (Exception e)
        {
            TempData["error"] = e.Message;
        }
        return RedirectToAction("Index");
    }
}