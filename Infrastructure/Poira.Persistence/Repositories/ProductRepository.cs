using Microsoft.EntityFrameworkCore;
using Poira.Application.Common.Exceptions;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PoiraDbContext _context;

    public ProductRepository(PoiraDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ICollection<Product>> GetAllProductsByQuantity(int quanitity)
    {
        var products = _context.Products.Where(fridge => fridge.DefaultQuantity == quanitity);
        return await products.ToListAsync();
    }

    public async Task<ICollection<Product>> GetAllProductsByName(string name)
    {
        var product = _context.Products.Where(p => p.Name == name);
        return await product.ToListAsync();
    }

    public async Task<Product> GetProductById(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        
        if (product is null)
            throw new NotFoundException<Product>(nameof(product));
        
        return product;
    }

    public async Task<Product> CreateProduct(string name, int defaultQuantity)
    {
        var product = new Product(Guid.NewGuid(), name, defaultQuantity);
        
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProduct(Guid id, string newName, int newQuantity)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(lesson => lesson.Id == id);

        if (product is null)
            throw new NotFoundException<Product>(nameof(product));

        product.Name = newName;
        product.DefaultQuantity = newQuantity;
        
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProduct(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
            throw new NotFoundException<Product>(nameof(product));

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}