using EfCodeFirst.Models;

namespace EfCodeFirst.DTO;

public class PrescriptionDetailDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PatientDTO Patient { get; set; }
    public DoctorDTO Doctor { get; set; }
    public List<MedicamentDTO> Medicaments { get; set; }
}

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; }
}