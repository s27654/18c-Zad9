using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.IdPatient);
        builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Birthdate).HasMaxLength(100).IsRequired();
    }
}