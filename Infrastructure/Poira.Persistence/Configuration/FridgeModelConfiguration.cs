using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poira.Domain.Models;

namespace Poira.Persistence.Configuration;

public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
{
    public void Configure(EntityTypeBuilder<FridgeModel> builder)
    {
        builder.HasKey(teacher => teacher.Id);
        builder.HasIndex(teacher => teacher.Id).IsUnique();
    }
}