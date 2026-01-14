using Raul_Moldovan_Medii.Mobile.Services;

namespace Raul_Moldovan_Medii.Mobile;

public partial class MainPage : ContentPage
{
    private readonly ApiService _api = new ApiService();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLoadClicked(object sender, EventArgs e)
    {
        try
        {
            var list = await _api.GetAppointmentsAsync();
            AppointmentsList.ItemsSource = list;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }
}
