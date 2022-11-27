using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public DoctorService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Ward> Wards { get; set; } = new List<Ward>();

        public async Task CreateDoctor(Doctor doctor)
        {
            var result = await _http.PostAsJsonAsync("api/doctor", doctor);
            await SetDoctors(result);
        }

        private async Task SetDoctors(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Doctor>>();
            Doctors = response;
            _navigationManager.NavigateTo("doctors");
        }

        public async Task DeleteDoctor(int id)
        {
            var result = await _http.DeleteAsync($"api/doctor/{id}");
            await SetDoctors(result);
        }

        public async Task GetWards()
        {
            var result = await _http.GetFromJsonAsync<List<Ward>>("api/doctor/wards");
            if (result != null)
                Wards = result;
        }

        public async Task<Doctor> GetSingleDoctor(int id)
        {
            var result = await _http.GetFromJsonAsync<Doctor>($"api/doctor/{id}");
            if (result != null)
                return result;
            throw new Exception("Doctor not found!");
        }

        public async Task GetDoctors()
        {
            var result = await _http.GetFromJsonAsync<List<Doctor>>("api/doctor");
            if (result != null)
                Doctors = result;
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            var result = await _http.PutAsJsonAsync($"api/doctor/{doctor.Id}", doctor);
            await SetDoctors(result);
        }
    }
}
