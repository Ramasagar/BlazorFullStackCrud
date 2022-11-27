using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            var doctors = await _context.Doctors.Include(sh => sh.Ward).ToListAsync();
            return Ok(doctors);
        }

        [HttpGet("wards")]
        public async Task<ActionResult<List<Ward>>> GetWards()
        {
            var wards = await _context.Wards.ToListAsync();
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetSingleDoctor(int id)
        {
            var doctor = await _context.Doctors
                .Include(h => h.Ward)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (doctor == null)
            {
                return NotFound("Sorry, no doctor here. :/");
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<List<Doctor>>> CreateDoctor(Doctor doctor)
        {
            doctor.Ward = null;
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return Ok(await GetDbDoctors());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Doctor>>> UpdateDoctor(Doctor doctor, int id)
        {
            var dbDoctor = await _context.Doctors
                .Include(sh => sh.Ward)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbDoctor == null)
                return NotFound("Sorry, but no doctor for you. :/");

            dbDoctor.FirstName = doctor.FirstName;
            dbDoctor.LastName = doctor.LastName;
            dbDoctor.Specialization = doctor.Specialization;
            dbDoctor.WardId = doctor.WardId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbDoctors());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Doctor>>> DeleteDoctor(int id)
        {
            var dbDoctor = await _context.Doctors
                .Include(sh => sh.Ward)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbDoctor == null)
                return NotFound("Sorry, but no doctor for you. :/");

            _context.Doctors.Remove(dbDoctor);
            await _context.SaveChangesAsync();

            return Ok(await GetDbDoctors());
        }

        private async Task<List<Doctor>> GetDbDoctors()
        {
            return await _context.Doctors.Include(sh => sh.Ward).ToListAsync();
        }
    }
}
