using EfCodeFirst.DTO;
using EfCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Controller;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PrescriptionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public ActionResult<PrescriptionDetailDTO> GetPrescription(int id)
    {
        var prescription = _context.Prescriptions.Include(pr => pr.Patient).Include(pr => pr.Doctor)
            .Include(pr => pr.PrescriptionMedicaments).ThenInclude(pm => pm.Medicament)
            .FirstOrDefault(p => p.IdPrescription == id);
        if (prescription == null) return NotFound();
        var result = new PrescriptionDetailDTO
        {
            IdPrescription = prescription.IdPrescription,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Patient = new PatientDTO
            {
                IdPatient = prescription.Patient.IdPatient,
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                Birthdate = prescription.Patient.Birthdate
            },
            Doctor = new DoctorDTO
            {
                IdDoctor = prescription.Doctor.IdDoctor,
                FirstName = prescription.Doctor.FirstName,
                LastName = prescription.Doctor.LastName,
                Email = prescription.Doctor.Email
            },
            Medicaments = prescription.PrescriptionMedicaments.Select(pm => new MedicamentDTO()
            {
                IdMedicament = pm.Medicament.IdMedicament,
                Name = pm.Medicament.Name,
                Description = pm.Medicament.Description,
                Type = pm.Medicament.Type,
                Dose = pm.Dose,
                Details = pm.Details
            }).ToList()
        };
        return Ok(result);
    }
}
