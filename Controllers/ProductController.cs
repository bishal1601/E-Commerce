using E_Commerce.Dto.Product;
using E_Commerce.Models.Product;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Services.interfaces;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IVendorRepository _vendorRepository;

    public ProductController(
        IProductService productService,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IVendorRepository vendorRepository
    )
    {
        _productService = productService;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _vendorRepository = vendorRepository;
    }
    
    //display all product from DB 
    public IActionResult Index()
    {
        var products =  _productRepository.GetQueryable();
        var vm = products.Select(product => new ProductListVm
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            VendorName = product.Vendor.Name,
            CategoryName = product.Category.Name,
            Status = product.Status
        }).ToList();
        return View(vm);
    }

    public async Task<IActionResult> Create()
    {
        
            var vm = new ProductVm();
            vm.Categories = _categoryRepository.GetCategories();
            vm.Vendors = _vendorRepository.GetVendors();
            return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductVm vm)
    {
        if(!ModelState.IsValid)return View(vm);
        try
        {
            var dto = new ProductDto()
            {
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                Stock = vm.Stock,
                VendorId = vm.VendorId,
                CategoryId = vm.CategoryId,
                Status = vm.Status
            };
            await _productService.Create(dto);
            TempData["Success"] = "Product created";
            return RedirectToAction("Index");
        }
        catch(Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction("Index");
        }
    }

    public async Task<IActionResult> Edit(long id)
    {
        try
        {
            var product = await _productRepository.GetById(id);
            var vm = new ProductEditVm()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                VendorId = product.VendorId,
                CategoryId = product.CategoryId,
                Status = product.Status
            };
            vm.Categories = _categoryRepository.GetCategories();
            vm.Vendors = _vendorRepository.GetVendors();
            return View(vm);

        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, ProductEditVm vm)
    {
        vm.Categories = _categoryRepository.GetCategories();
        vm.Vendors = _vendorRepository.GetVendors();
        if(!ModelState.IsValid)return View(vm);
        try
        {
            var dto = new ProductDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                Stock = vm.Stock,
                VendorId = vm.VendorId,
                CategoryId = vm.CategoryId,
                Status = vm.Status
            };
            await _productService.Update(dto);
            TempData["Success"] = "Product updated";
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction("Index");
        }
    }

    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _productService.Delete(id);
            TempData["Success"] = "Product deleted";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction("Index");
        }
    }
}