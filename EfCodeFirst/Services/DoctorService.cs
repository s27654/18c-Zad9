using EfCodeFirst.DTO;
using EfCodeFirst.Models;

namespace EfCodeFirst.Services;

public class DoctorService : IDoctorService
{
    private readonly AppDbContext _context;

    public DoctorService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DoctorDTO> GetDoctors()
    {
        return _context.Doctors.Select(d => new DoctorDTO
        {
            IdDoctor = d.IdDoctor,
            FirstName = d.FirstName,
            LastName = d.LastName,
            Email = d.Email
        }).ToList();
    }
    public DoctorDTO GetDoctor(int  id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null) return null;
        return new DoctorDTO
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };
    }
    public void AddDoctor(CreateDoctorDTO doctor)
    {
        var newDoctor = new Doctor
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };
        _context.Doctors.Add(newDoctor);
        _context.SaveChanges();
    }
    public void UpdateDoctor(int  id, UpdateDoctorDTO doctor)
    {
        var updoctor = _context.Doctors.Find(id);
        if (updoctor == null) return;
        updoctor.FirstName = doctor.FirstName;
        updoctor.LastName = doctor.LastName;
        updoctor.Email = doctor.Email;
        _context.SaveChanges();
    }
    public void DeleteDoctor(int  id)
    {
        var deldoctor = _context.Doctors.Find(id);
        if (deldoctor == null) return;
        _context.Doctors.Remove(deldoctor);
        _context.SaveChanges();
    }
}