using Poira.Domain.Utils;

namespace Poira.Domain.Primitives.Entities;

public abstract class EntityGuid : Entity<Guid>
{
    protected EntityGuid(Guid id)
    {
        Ensure.GreaterThan(id, Guid.Empty, "The entity guid must be greater than empty", nameof(id));
        Id = id;
    }
}