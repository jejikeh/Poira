using Microsoft.EntityFrameworkCore;
using Poira.Application.Common.Exceptions;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Persistence.Repositories;

public class FridgeModelRepository : IFridgeModelRepository
{
    private readonly PoiraDbContext _context;

    public FridgeModelRepository(PoiraDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<FridgeModel>> GetAllFridgeModels()
    {
        return await _context.FridgeModels.ToListAsync();
    }

    public async Task<ICollection<FridgeModel>> GetAllFridgeModelsByYear(DateTime dateTime)
    {
        var fridgesModels = _context.FridgeModels.Where(fridgeModel => fridgeModel.Year == dateTime);
        return await fridgesModels.ToListAsync();
    }

    public async Task<FridgeModel> GetFridgeModelById(Guid modelId)
    {
        var fridgesModel = await _context.FridgeModels.FirstOrDefaultAsync(fridge => fridge.Id == modelId);
        
        if (fridgesModel is null)
            throw new NotFoundException<FridgeModel>(nameof(fridgesModel));
        
        return fridgesModel;
    }

    public async Task<FridgeModel> GetFridgeModelByName(string modelName)
    {
        var fridgeModel = await _context.FridgeModels.FirstOrDefaultAsync(f => f.Name == modelName);
        
        if (fridgeModel is null)
            throw new NotFoundException<FridgeModel>(nameof(fridgeModel));

        return fridgeModel;
    }

    public async Task<FridgeModel> CreateFridgeModel(string name, DateTime year)
    {
        var fridge = new FridgeModel(Guid.NewGuid(), name, year);
        
        await _context.FridgeModels.AddAsync(fridge);
        await _context.SaveChangesAsync();
        return fridge;
    }

    public async Task<FridgeModel> UpdateFridgeModel(Guid id, string newName, DateTime newYear)
    {
        var fridgeModel = await _context.FridgeModels
            .FirstOrDefaultAsync(lesson => lesson.Id == id);

        if (fridgeModel is null)
            throw new NotFoundException<FridgeModel>(nameof(fridgeModel));

        fridgeModel.Name = newName;
        fridgeModel.Year = newYear;
        
        await _context.SaveChangesAsync();
        return fridgeModel;
    }

    public async Task DeleteFridgeModel(Guid id)
    {
        var fridgeModel = await _context.FridgeModels.FirstOrDefaultAsync(x => x.Id == id);

        if (fridgeModel is null)
            throw new NotFoundException<FridgeModel>(nameof(fridgeModel));

        _context.FridgeModels.Remove(fridgeModel);
        await _context.SaveChangesAsync();
    }
}