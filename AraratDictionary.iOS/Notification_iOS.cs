using AraratDictionary.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Notification_iOS))]

namespace AraratDictionary.iOS
{
    public class Notification_iOS : INotification
    {
        public void CreateNotification(string title, string message)
        {
            new NotificationDelegate().RegisterNotification(title, message);
        }
    }
}