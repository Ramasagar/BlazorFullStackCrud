namespace BlazorFullStackCrud.Client.Services.DoctorService
{
    public interface IDoctorService
    {
        List<Doctor> Doctors { get; set; }
        List<Ward> Wards { get; set; }
        Task GetWards();
        Task GetDoctors();
        Task<Doctor> GetSingleDoctor(int id);
        Task CreateDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(int id);
    }
}
