using Poira.Domain.Models;

namespace Poira.Application.Interfaces;

public interface IFridgeModelRepository
{
    public Task<ICollection<FridgeModel>> GetAllFridgeModels();
    public Task<ICollection<FridgeModel>> GetAllFridgeModelsByYear(DateTime dateTime);
    public Task<FridgeModel> GetFridgeModelById(Guid modelId);
    public Task<FridgeModel> GetFridgeModelByName(string modelName);
    public Task<FridgeModel> CreateFridgeModel(string name, DateTime year);
    public Task<FridgeModel> UpdateFridgeModel(Guid id, string newName, DateTime newYear);
    public Task DeleteFridgeModel(Guid id);
}