using EfCodeFirst.DTO;

namespace EfCodeFirst.Services;

public interface IDoctorService
{
    IEnumerable<DoctorDTO> GetDoctors();
    DoctorDTO GetDoctor(int id);
    void AddDoctor(CreateDoctorDTO doctor);
    void UpdateDoctor(int id, UpdateDoctorDTO doctor);
    void DeleteDoctor(int id);
}