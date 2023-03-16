using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poira.Domain.Models;

namespace Poira.Persistence.Configuration;

public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
{
    public void Configure(EntityTypeBuilder<Fridge> builder)
    {
        builder.HasKey(teacher => teacher.Id);
        builder.HasIndex(teacher => teacher.Id).IsUnique();
        builder.Property(teacher => teacher.FridgeModel).IsRequired();
    }
}