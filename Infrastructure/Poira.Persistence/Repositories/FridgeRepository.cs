using Microsoft.EntityFrameworkCore;
using Poira.Application.Common.Exceptions;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Persistence.Repositories;

public class FridgeRepository : IFridgeRepository
{
    private readonly PoiraDbContext _context;

    public FridgeRepository(PoiraDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Fridge>> GetAllFridges()
    {
        return await _context.Fridges.ToListAsync();
    }

    public async Task<ICollection<Fridge>> GetAllFridgesByModelId(Guid modelId)
    {
        var fridges = _context.Fridges.Where(fridge => fridge.FridgeModel == modelId);
        return await fridges.ToListAsync();
    }

    public async Task<ICollection<Fridge>> GetAllFridgesByOwnerName(string ownerName)
    {
        var fridges = _context.Fridges.Where(fridge => fridge.OwnerName == ownerName);
        return await fridges.ToListAsync();
    }

    public async Task<Fridge> GetFridgeByModelId(Guid modelId)
    {
        var fridge = await _context.Fridges.FirstOrDefaultAsync(f => f.FridgeModel == modelId);
        
        if (fridge is null)
            throw new NotFoundException<Fridge>(nameof(fridge));

        return fridge;
    }

    public async Task<Fridge> GetFridgeByOwnerName(string ownerName)
    {
        var fridge = await _context.Fridges.FirstOrDefaultAsync(f => f.OwnerName == ownerName);
        
        if (fridge is null)
            throw new NotFoundException<Fridge>(nameof(fridge));

        return fridge;
    }

    public async Task<Fridge> GetFridgeByName(string name)
    {
        var fridge = await _context.Fridges.FirstOrDefaultAsync(f => f.Name == name);
        
        if (fridge is null)
            throw new NotFoundException<Fridge>(nameof(fridge));

        return fridge;
    }

    public async Task<Fridge> CreateFridge(string name, string ownerName, Guid modelId)
    {
        var fridge = new Fridge(Guid.NewGuid(), name, ownerName, modelId);
        
        await _context.Fridges.AddAsync(fridge);
        await _context.SaveChangesAsync();
        return fridge;
    }

    public async Task<Fridge> UpdateFridge(Guid id, string newName, string newOwnerName, Guid newModelId)
    {
        var fridge = await _context.Fridges
            .FirstOrDefaultAsync(lesson => lesson.Id == id);

        if (fridge is null)
            throw new NotFoundException<Fridge>(nameof(fridge));

        fridge.Name = newName;
        fridge.OwnerName = newOwnerName;
        fridge.FridgeModel = newModelId;
        
        await _context.SaveChangesAsync();
        return fridge;
    }

    public async Task DeleteFridge(Guid id)
    {
        var fridge = await _context.Fridges.FirstOrDefaultAsync(x => x.Id == id);

        if (fridge is null)
            throw new NotFoundException<Fridge>(nameof(fridge));

        _context.Fridges.Remove(fridge);
        await _context.SaveChangesAsync();
    }
}