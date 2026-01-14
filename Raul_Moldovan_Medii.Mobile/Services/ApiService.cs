using System.Net.Http.Json;
using Raul_Moldovan_Medii.Mobile.Models;

namespace Raul_Moldovan_Medii.Mobile.Services
{
    public class ApiService
    {
        
        private const string BaseUrl = "https://localhost:7144";

        private readonly HttpClient _http = new HttpClient();

        public async Task<List<AppointmentDto>> GetAppointmentsAsync()
        {
            var url = $"{BaseUrl}/api/AppointmentsApi";
            return await _http.GetFromJsonAsync<List<AppointmentDto>>(url) ?? new();
        }

        public async Task<List<ClientDto>> GetClientsAsync()
        {
            var url = $"{BaseUrl}/api/AppointmentsApi/clients";
            return await _http.GetFromJsonAsync<List<ClientDto>>(url) ?? new();
        }

        public async Task<List<CarDto>> GetCarsAsync()
        {
            var url = $"{BaseUrl}/api/AppointmentsApi/cars";
            return await _http.GetFromJsonAsync<List<CarDto>>(url) ?? new();
        }

        public async Task<List<MechanicDto>> GetMechanicsAsync()
        {
            var url = $"{BaseUrl}/api/AppointmentsApi/mechanics";
            return await _http.GetFromJsonAsync<List<MechanicDto>>(url) ?? new();
        }

        public async Task<int> CreateAppointmentAsync(CreateAppointmentRequest req)
        {
            var url = $"{BaseUrl}/api/AppointmentsApi";

            var resp = await _http.PostAsJsonAsync(url, req);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw new Exception(body);

            var ok = await resp.Content.ReadFromJsonAsync<CreateAppointmentResponse>();
            return ok?.Id ?? 0;
        }
    }
}
