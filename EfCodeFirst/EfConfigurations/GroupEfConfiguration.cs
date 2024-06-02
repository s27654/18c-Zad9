using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class GroupEfConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Description).IsRequired(false).HasMaxLength(200);
    }
}