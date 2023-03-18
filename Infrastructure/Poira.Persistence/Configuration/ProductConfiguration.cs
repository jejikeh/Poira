using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poira.Domain.Models;

namespace Poira.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(teacher => teacher.Id);
        builder.HasIndex(teacher => teacher.Id).IsUnique();
        builder.HasKey(product => product.Name);
        builder.HasIndex(product => product.Name).IsUnique();        
    }
}