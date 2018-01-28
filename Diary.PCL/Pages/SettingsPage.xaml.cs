
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

	    public SettingsPage()
		{
			InitializeComponent ();
		}

	    public SettingsPage(Account account) :this()
	    {
	        _account = account;
	    }

	    protected override void OnAppearing()
	    {

	    }

	    private void ToogleFingerprint(object sender, EventArgs e)
	    {
	        
	    }
	}
}