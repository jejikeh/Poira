using Poira.Domain.Primitives.Entities;

namespace Poira.Domain.Models;

public class Products : EntityGuid
{
    public int DefaultQuantity { get; set; }

    public Products(Guid id, int defaultQuantity) : base(id)
    {
        DefaultQuantity = defaultQuantity;
    }
}