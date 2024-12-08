using E_Commerce.Dto.Vendor;
using E_Commerce.Models.Vendor;
using Vendor = E_Commerce.Entities.Vendor;

namespace E_Commerce.Services.interfaces;

public interface IVendorService
{
    Task<Vendor> Create(VendorDto dto);
    Task<Vendor> Update(VendorDto dto);
    Task Delete(long id);

}