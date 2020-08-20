using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AraratDictionary.Views;
using SQLite;

namespace AraratDictionary
{
    public partial class App : Application
    {

        // Create db static property to perform the 
        // Database calls from around the project
        //public static Database db { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new  SplashScreen();
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
