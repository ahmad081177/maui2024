
using FinalProject.Services;
using FinalProject.ViewModels;
namespace FinalProject.Views.Auth;
public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }

 

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new Auth.LoginPage());
    }
}
