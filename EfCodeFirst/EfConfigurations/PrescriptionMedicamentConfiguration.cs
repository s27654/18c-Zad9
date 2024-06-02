using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class PresprictionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(pm => new {pm.IdMedicament, pm.IdPrescription});
        builder.Property(pm => pm.Dose).IsRequired();
        builder.Property(pm => pm.Details).HasMaxLength(100).IsRequired();
        builder.HasOne(pm => pm.Medicament).WithMany().HasForeignKey(pm => pm.IdMedicament);
        builder.HasOne(pm => pm.Prescription).WithMany().HasForeignKey(pm => pm.IdPrescription);
    }
}