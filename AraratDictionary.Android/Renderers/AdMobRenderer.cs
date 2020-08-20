
using Android.Content;
using Android.Content.Res;
using Android.Gms.Ads;
using AraratDictionary;
using AraratDictionary.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdmobControl), typeof(AdMobRenderer))]

namespace AraratDictionary.Droid.Renderers
{
    public class AdMobRenderer : ViewRenderer<AdmobControl, AdView>
    {

        public AdMobRenderer(Context context) : base(context)
        {
        }

        private int GetSmartBannerDpHeight()
        {
            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            if (dpHeight <= 400)
            {
                return 32;
            }
            if (dpHeight <= 720)
            {
                return 50;
            }
            return 90;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdmobControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var adView = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = Element.AdUnitId
                };

              

                var requestbuilder = new AdRequest.Builder();

                adView.LoadAd(requestbuilder.Build());
                e.NewElement.HeightRequest = GetSmartBannerDpHeight();

                SetNativeControl(adView);
                
            }
        }
    }
}