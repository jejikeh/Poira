using Poira.Domain.Primitives.Entities;

namespace Poira.Domain.Models;

public class FridgeProducts : EntityGuid
{
    public Guid FridgeId { get; set; }
    public int Quantity { get; set; }

    public FridgeProducts(Guid id, Guid fridgeId, int quantity) : base(id)
    {
        FridgeId = fridgeId;
        Quantity = quantity;
    }
}