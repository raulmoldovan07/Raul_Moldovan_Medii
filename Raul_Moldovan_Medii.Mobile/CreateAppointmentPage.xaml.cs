using Raul_Moldovan_Medii.Mobile.Services;
using Raul_Moldovan_Medii.Mobile.Models;

namespace Raul_Moldovan_Medii.Mobile;

public partial class CreateAppointmentPage : ContentPage
{
    private readonly ApiService _api = new ApiService();

    public CreateAppointmentPage()
    {
        InitializeComponent();
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(ClientIdEntry.Text, out int clientId))
                throw new Exception("Client ID invalid");

            if (!int.TryParse(CarIdEntry.Text, out int carId))
                throw new Exception("Car ID invalid");

            int? mechanicId = null;
            if (int.TryParse(MechanicIdEntry.Text, out int m))
                mechanicId = m;

            var date = DatePicker?.Date ?? DateTime.Today;
            var time = TimePicker?.Time ?? TimeSpan.Zero;

            var dateTime = date.Date + time;




            var req = new CreateAppointmentRequest
            {
                AppointmentDateTime = dateTime,
                ClientID = clientId,
                CarID = carId,
                MechanicID = mechanicId,
                Status = 0
            };

            await _api.CreateAppointmentAsync(req);

            await DisplayAlert("Succes", "Programare creată!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }
}
