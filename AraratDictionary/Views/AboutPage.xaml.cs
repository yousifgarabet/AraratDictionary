using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AraratDictionary.Views
{
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            
        }


        private async void BtnSendEmail_OnClicked(object sender, EventArgs e)
        {
           // await Email.ComposeAsync("Email Title", "Write your message here", "yousifgarabet@gmail.com");
           var subject = "Email Title";
           var body = "Write your message here";
           List<string> recipients = new List<string>();
           recipients.Add("yousifgarabet@gmail.com");

           try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }

        }
    }
}