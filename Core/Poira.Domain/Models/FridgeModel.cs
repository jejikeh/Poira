using Poira.Domain.Primitives.Entities;

namespace Poira.Domain.Models;

public class FridgeModel : EntityGuid
{
    public string Name { get; set; }
    public DateTime Year { get; set; }

    public FridgeModel(Guid id, string name, DateTime year) : base(id)
    {
        Name = name;
        Year = year;
    }
}