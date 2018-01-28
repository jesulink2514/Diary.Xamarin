using System;
using Xamarin.Forms;
using Xamarin.Auth;
using Diary.Shared;

namespace Diary
{
	public partial class LoginPage : ContentPage
	{
		public event Action<Account> LoginSucceeded = (s) => {};	

		private readonly AccountManager _accountManager;

		public LoginPage ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this,false);

			_accountManager = new AccountManager ();

			btnLogin.Clicked += BtnLoginClicked;
			btnCreateAccount.Clicked += BtnCreateAccountClicked;
		}

		void BtnLoginClicked (object sender, EventArgs e)
		{
			if (_accountManager.LoginToAccount(entryUserName.Text, entryPassword.Text) == false) 
			{
				DisplayAlert ("Login failed",
					"Unable to login, please check your username and password",
					"OK");
			} 
			else 
			{
				LoginSucceeded (_accountManager.GetAccount (entryUserName.Text));
			}
		}

		void BtnCreateAccountClicked (object sender, EventArgs e)
		{
			if (_accountManager.CreateAndSaveAccount(entryUserName.Text, entryPassword.Text) == true)
				LoginSucceeded (_accountManager.GetAccount(entryUserName.Text));
			else 
				DisplayAlert ("Create account Failed", "Unable to create a new account - does this account already exist?", "OK");
		}
	}
}