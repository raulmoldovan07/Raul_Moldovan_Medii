using Raul_Moldovan_Medii.Mobile.Services;

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

            var date = DatePicker.Date;
            var time = TimePicker.Time;
            var dateTime = date.Add(time);

            await _api.CreateAppointmentAsync(
                dateTime,
                clientId,
                carId,
                mechanicId
            );

            await DisplayAlert("Succes", "Programare creată!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }
}
