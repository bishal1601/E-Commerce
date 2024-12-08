using E_Commerce.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Repositories.Interfaces;

public interface IVendorRepository
{
    Task<List<Vendor>> GetAll();
    Task<Vendor> GetById(long id);
    List<SelectListItem> GetVendors();

}