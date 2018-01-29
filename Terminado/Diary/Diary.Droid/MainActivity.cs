using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.CurrentActivity;
using Plugin.Fingerprint;
using Xamarin.Forms.Platform.Android;

namespace Diary.Droid
{
    [Activity(Label = "Diary", Icon = "@drawable/icon", MainLauncher = true, 
	    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
	    Theme = "@style/MyTheme")]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
		    ToolbarResource = Resource.Layout.Toolbar;
		    TabLayoutResource = Resource.Layout.Tabbar;

            base.OnCreate(bundle);

            CrossFingerprint.SetCurrentActivityResolver(()=> CrossCurrentActivity.Current.Activity);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

			App.DatabaseFolder = FileHelper.GetLocalStoragePath();
		}
	}
}