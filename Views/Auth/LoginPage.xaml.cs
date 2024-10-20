using FinalProject.Services;
using FinalProject.ViewModels;

namespace FinalProject.Views.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();

    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new Auth.RegistrationPage());
    }
    //private async void Register_Clicked(object sender, EventArgs e)
    //{
    //    await Application.Current.MainPage.Navigation.PushAsync(new Auth.RegistrationPage());

    //}
}