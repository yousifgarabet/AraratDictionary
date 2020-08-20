using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AraratDictionary.ViewModels
{
    public class AboutViewModel 
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(async () => await Email.ComposeAsync("Email Title","Write your message here", "yousifgarabet@gmail.com") );
        }

        public ICommand OpenWebCommand { get; }
    }
}