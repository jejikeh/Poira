using Microsoft.EntityFrameworkCore;

namespace Poira.Persistence;

public static class DbInitializer
{
    public static void Initialize<T>(T context) where T : DbContext
    {
        context.Database.EnsureCreated();
    }
}