
using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using SkiaSharp.Views.Android;

namespace AraratDictionary.Droid
{
    [Activity(Label = "AraratDictionary", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
                        base.OnCreate(savedInstanceState);
            
              Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-9983685023330943~1832186628");
            LoadApplication(new App());

           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}