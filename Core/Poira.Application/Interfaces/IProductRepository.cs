using Poira.Domain.Models;

namespace Poira.Application.Interfaces;

public interface IProductRepository
{
    public Task<ICollection<Product>> GetAllProducts();
    public Task<ICollection<Product>> GetAllProductsByQuantity(int quanitity);
    public Task<ICollection<Product>> GetAllProductsByName(string name);
    public Task<Product> GetProductById(Guid productId);
    public Task<Product> CreateProduct(string name, int defaultQuantity);
    public Task<Product> UpdateProduct(Guid id, string newName, int newQuantity);
    public Task DeleteProduct(Guid id);
}