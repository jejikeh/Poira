using Poira.Domain.Primitives.Entities;

namespace Poira.Domain.Models;

public class Products : EntityGuid
{
    public string Name { get; set; }
    public int DefaultQuantity { get; set; }

    public Products(Guid id, string name, int defaultQuantity) : base(id)
    {
        Name = name;
        DefaultQuantity = defaultQuantity;
    }
}