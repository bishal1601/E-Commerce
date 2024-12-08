using E_Commerce.Data;
using E_Commerce.Dto.Vendor;
using E_Commerce.Entities;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Services.interfaces;

namespace E_Commerce.Services;

public class VendorService: IVendorService
{
    private readonly ApplicationDbContext _context;

    public VendorService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Vendor> Create(VendorDto dto)
    {
        var vendor = new Vendor()
        {
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            Status = dto.Status,
        };
        await _context.Vendors.AddAsync(vendor);
        await _context.SaveChangesAsync();
        return vendor;
        
    }
    
    public async Task<Vendor> Update(VendorDto dto)
    {
        var vendor = await _context.Vendors.FindAsync(dto.Id);
        if (vendor == null)
        {
            throw new Exception("Category not found");
        }

        vendor.Name = dto.Name;
        vendor.Email = dto.Email;
        vendor.PhoneNumber = dto.PhoneNumber;
        vendor.Status = dto.Status;
        vendor.Address = dto.Address; 
        await _context.SaveChangesAsync();
        return vendor;
    }

    public async Task Delete(long id)
    {
        var vendor = await _context.Vendors.FindAsync(id);
        if (vendor == null)
        {
            throw new Exception("Vendor not found");
        }
        _context.Vendors.Remove(vendor);
        await _context.SaveChangesAsync();
    }
}