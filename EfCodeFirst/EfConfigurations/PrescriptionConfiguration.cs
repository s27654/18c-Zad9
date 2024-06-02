using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class PresprictionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.IdPrescription);
        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.DueDate).IsRequired();
        builder.HasOne(p => p.Patient).WithMany().HasForeignKey(p => p.IdPatient);
        builder.HasOne(p => p.Doctor).WithMany().HasForeignKey(p => p.IdDoctor);
    }
}