using E_Commerce.Entities;

namespace E_Commerce.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    IQueryable<Product> GetQueryable();
    Task<Product> GetById(long id);
}