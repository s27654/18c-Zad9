using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class StudentEfConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
    }
}