using Poira.Domain.Models;

namespace Poira.Application.Interfaces;

public interface IFridgeRepository
{
    public Task<ICollection<Fridge>> GetAllFridges();
    public Task<ICollection<Fridge>> GetAllFridgesByModelId(Guid modelId);
    public Task<ICollection<Fridge>> GetAllFridgesByOwnerName(string ownerName);
    public Task<Fridge> GetFridgeByModelId(Guid modelId);
    public Task<Fridge> GetFridgeByOwnerName(string ownerName);
    public Task<Fridge> GetFridgeByName(string name);
    public Task<Fridge> CreateFridge(string name, string ownerName, Guid modelId);
    public Task<Fridge> UpdateFridge(Guid id, string newName, string newOwnerName, Guid newModelId);
    public Task DeleteFridge(Guid id);
}