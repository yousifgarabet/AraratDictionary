using Xamarin.Forms;

namespace AraratDictionary
{
    public class AdmobControl : View
    {
        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
            nameof(AdUnitId),
            typeof(string),
            typeof(AdmobControl),
            string.Empty);

        public string AdUnitId
        {
            get => (string)GetValue(AdUnitIdProperty);
            set => SetValue(AdUnitIdProperty, value);
        }
    }
}