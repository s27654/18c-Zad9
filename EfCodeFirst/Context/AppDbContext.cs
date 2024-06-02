/*using EfCodeFirst.EfConfigurations;
using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Context;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }


    public AppDbContext() {}

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<Student>(s =>
        {
            s.Property()
        });
        */

        /*
        modelBuilder.ApplyConfigurationsFromAssembly();
        */
        /*
        modelBuilder.ApplyConfiguration(new StudentEfConfiguration());
        modelBuilder.ApplyConfiguration(new GroupEfConfiguration());
        modelBuilder.ApplyConfiguration(new StudentGroupEfConfiguration());
    }
}*/

        using EfCodeFirst.EfConfigurations;
        using Microsoft.EntityFrameworkCore;
using EfCodeFirst.Models;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new PresprictionConfiguration());
        modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
        modelBuilder.ApplyConfiguration(new PresprictionMedicamentConfiguration());
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor {IdDoctor = 1, FirstName = "Jacek", LastName = "Placek", Email = "jacekplacek@email.com"},
            new Doctor {IdDoctor = 2, FirstName = "Janina", LastName = "Grabek", Email = "jagrabek@email.com"}
        );
        modelBuilder.Entity<Patient>().HasData(
            new Patient {IdPatient = 1, FirstName = "Janusz", LastName = "Kowal", Birthdate = new DateTime(1989, 12,21)},
            new Patient {IdPatient = 2, FirstName = "Kamila", LastName = "Knowak", Birthdate = new DateTime(1968, 4,11)}
        );
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament {IdMedicament = 1, Name = "Witaminki", Description = "Vitamins", Type = "Vit"},
            new Medicament {IdMedicament = 2, Name = "Asparsec", Description = "New med", Type = "Heart"}
        );
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription {IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(14), IdDoctor = 1, IdPatient = 1},
            new Prescription {IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(7), IdDoctor = 2, IdPatient = 2}
        );
        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament {IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Once a day"},
            new PrescriptionMedicament {IdMedicament = 2, IdPrescription = 2, Dose = 3, Details = "Trice a day"}
        );
    }
}