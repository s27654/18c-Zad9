using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(m => m.IdMeticament);
        builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Type).HasMaxLength(100).IsRequired();
    }
}