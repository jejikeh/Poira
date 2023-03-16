using Poira.Domain.Primitives.Entities;

namespace Poira.Domain.Models;

public class Fridge : EntityGuid
{
    public string Name { get; set; }
    public string OwnerName { get; set; } = string.Empty;
    public Guid FridgeModel { get; set; }

    public Fridge(Guid id, string name, string ownerName, Guid fridgeModel) : base(id)
    {
        Name = name;
        OwnerName = ownerName;
        FridgeModel = fridgeModel;
    }
}