using E_Commerce.Data;
using E_Commerce.Entities;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Repositories;

public class VendorRepository: IVendorRepository
{
    private readonly ApplicationDbContext _context;

    public VendorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Vendor>> GetAll()
    { 
        return _context.Vendors.ToList();    
    }

    public async Task<Vendor> GetById(long id)
    {
        var vendor= await _context.Vendors.FindAsync(id);
        if (vendor == null)
        {
            throw new KeyNotFoundException("Vendor Not Found");
        }
        return vendor;
    }
    
    public List<SelectListItem> GetVendors()
    {
        var vendors= _context.Vendors.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
        return vendors;
        
    }
}