using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Xamarin.Forms.Platform.Android;

namespace Diary.Droid
{
	[Activity(Label = "Diary", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

			App.DatabaseFolder = FileHelper.GetLocalStoragePath();
		}
	}
}