using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AraratDictionary.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(ExtendedSearchBarRenderer))]

namespace AraratDictionary.iOS.Renderers
{
    class ExtendedSearchBarRenderer: SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Text")
            {
                Control.ShowsCancelButton = false;
            }
        }
	}
}