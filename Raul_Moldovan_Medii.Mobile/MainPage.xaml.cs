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
    private async void OnCreatePageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateAppointmentPage());
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateAppointmentPage());
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        try
        {
            if (sender is not Button btn) return;
            if (btn.CommandParameter == null) return;

            int id = btn.CommandParameter is int i ? i : int.Parse(btn.CommandParameter.ToString()!);

            var ok = await DisplayAlert("Confirmare", $"Ștergi programarea #{id}?", "Da", "Nu");
            if (!ok) return;

            await _api.DeleteAppointmentAsync(id);

            // reîncarcă lista după ștergere
            AppointmentsList.ItemsSource = await _api.GetAppointmentsAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }

}
