using System;
using Xamarin.Forms;

namespace AraratDictionary
{
    public static class Constants
    {
        public static string AdUnitId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        //return "ca-app-pub-9983685023330943/5268023064"; // native ads id
                    return "ca-app-pub-9983685023330943/2835438227"; // Android banner AdUnitId

                    case Device.iOS:
                        //return "ca-app-pub-9983685023330943/6518198007"; // Native Ads id
                        return "ca-app-pub-9983685023330943/3394869896";// replace here banner ad unit id

                    default:
                        throw new InvalidOperationException("Invalid platform");
                }
            }
        }

        public static string LanguageVar { get; set; }

    }
}