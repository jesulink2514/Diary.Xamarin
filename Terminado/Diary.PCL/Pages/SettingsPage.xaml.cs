
using Plugin.Fingerprint;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.PCL.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
	    private readonly Account _account;
        private bool enabled;
        private string user;
	    public SettingsPage()
		{
			InitializeComponent ();
		}

	    public SettingsPage(Account account) :this()
	    {
	        _account = account;
	    }

	    protected override async void OnAppearing()
        {
            var isavailable = await CrossFingerprint.Current.IsAvailableAsync();

            if (!isavailable)
            {
                btnFingerprint.IsEnabled = false;
                return;
            }
            
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            ObtenerUsuarioAsociado();

            if (_account.Username == user)
            {
                btnFingerprint.Text = "Disable Fingerprint Auth";
                enabled = true;
            }
            else
            {
                btnFingerprint.Text = "Enable Fingerprint Auth";
                enabled = false;
            }
        }

        private void ObtenerUsuarioAsociado()
        {
            if (!App.Current.Properties.ContainsKey("userAssociated"))
            {
                user = "";
                return;
            }

            user = App.Current.Properties["userAssociated"].ToString();
        }

        private async void ToogleFingerprint(object sender, EventArgs e)
	    {
            if (enabled)
            {
                App.Current.Properties["userAssociated"]="";
                UpdateScreen();
                enabled = false;
            }
            else
            {
                var resp = await CrossFingerprint.Current.AuthenticateAsync("Verifica tu huella");

                if (resp.Authenticated)
                {
                    App.Current.Properties["userAssociated"] = _account.Username;
                    enabled = true;
                    UpdateScreen();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error",resp.ErrorMessage,"Ok");
                }

            }
            await App.Current.SavePropertiesAsync();
	    }
	}
}