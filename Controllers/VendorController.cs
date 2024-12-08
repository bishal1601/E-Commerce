using E_Commerce.Dto.Vendor;
using E_Commerce.Models.Vendor;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers;

public class VendorController : Controller
{
    private readonly IVendorService _vendorService;
    private readonly IVendorRepository _vendorRepository;

    public VendorController(
        IVendorService vendorService,
        IVendorRepository vendorRepository
    )
    {
        _vendorService = vendorService;
        _vendorRepository = vendorRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var vendors = await _vendorRepository.GetAll();
        return View(vendors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(VendorVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        try
        {
            var dto = new VendorDto()
            {
                Name = vm.Name,
                Address = vm.Address,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Status = vm.Status,
            };
            await _vendorService.Create(dto);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return View(vm);
        }
    }

    public async Task<IActionResult> Edit(long id)
    {
        try
        {
            var vendors = await _vendorRepository.GetById(id);
            var vm = new VendorEditVm()
            {
                Id = vendors.Id,
                Name = vendors.Name,
                Address = vendors.Address,
                Email = vendors.Email,
                PhoneNumber = vendors.PhoneNumber,
                Status = vendors.Status,
            };
            return View(vm);
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Edit(long id, VendorEditVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        try
        {
            var dto = new VendorDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Status = vm.Status,
            };
            await _vendorService.Update(dto);
            TempData["Success"] = "Vendor was updated";
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
            await _vendorService.Delete(id);
            TempData["Success"] = "Vendor was deleted";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction("Index");
        }
    }
}