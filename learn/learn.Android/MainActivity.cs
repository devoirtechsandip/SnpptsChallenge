using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using learn.Services;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;


namespace learn.Droid
{
    [Activity(Label = "Enlighten", Icon = "@mipmap/enlightenlogo", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IMessageSender
    {
        private readonly int VOICE = 10;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

			Forms.SetFlags("CollectionView_Experimental");

			Rg.Plugins.Popup.Popup.Init(this, bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			
			Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            //Android.Glide.Forms.Init();
            
            UserDialogs.Init(this);
			FormsMaterial.Init(this, bundle);
			FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
           

            LoadApplication(new App(new AndroidInitializer()));
        }

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

           

            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		public override void OnBackPressed()
		{
			if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
			{
				// Do something if there are some pages in the `PopupStack`
			}
			else
			{
				// Do something if there are not any pages in the `PopupStack`
			}
		}

        
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

