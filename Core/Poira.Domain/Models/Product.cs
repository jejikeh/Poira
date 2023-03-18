using Poira.Domain.Primitives.Entities;

namespace Poira.Domain.Models;

public class Product : EntityGuid
{
    public string Name { get; set; }
    public int DefaultQuantity { get; set; }

    public Product(Guid id, string name, int defaultQuantity) : base(id)
    {
        Name = name;
        DefaultQuantity = defaultQuantity;
    }
}