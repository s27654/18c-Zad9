using EfCodeFirst.DTO;
using EfCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;
namespace EfCodeFirst.Controller;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DoctorDTO>> GetDoctors()
    {
        return Ok(_doctorService.GetDoctors());
    }

    [HttpGet]
    public ActionResult<DoctorDTO> GetDoctor(int id)
    {
        var doctor = _doctorService.GetDoctor(id);
        if (doctor == null) return NotFound();
        return Ok(doctor);
    }

    [HttpPost]
    public ActionResult AddDoctor(CreateDoctorDTO doctor)
    {
        _doctorService.AddDoctor(doctor);
        return CreatedAtAction(nameof(GetDoctor), new { id = doctor.IdDoctor }, doctor);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDocotr(int id, UpdateDoctorDTO doctor)
    {
        _doctorService.UpdateDoctor(id, doctor);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDoctor(int id)
    {
        _doctorService.DeleteDoctor(id);
        return NoContent();
    }
}