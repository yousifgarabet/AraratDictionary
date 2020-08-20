using System;
using System.ComponentModel;
using System.Linq;
using AraratDictionary.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AraratDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private SQLiteConnection _sqLiteConnection;
        private bool isFirstTime = false;
        public SearchPage()
        {
            InitializeComponent();
            if (isFirstTime==false)
            {
                isFirstTime = true;
                Application.Current.Properties["lang"] = "en";
                this.English.IsEnabled = false;
                this.Kurdish.IsEnabled = true;
            }
        }


        protected override void OnAppearing()
        {
            getWordsList();
        }
        public async void getWordsList()
        {
            //var t = _sqLiteConnection.Query<int>("PRAGMA key=Liza@ax28o");

            _sqLiteConnection = await DependencyService.Get<ISQLite>().GetConnection();
            if (lstDisplay.ItemsSource == null)
            {
                lstDisplay.ItemsSource =_sqLiteConnection.Table<words>().ToList();
            }
        }

        private void EntrySearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string lang = Application.Current.Properties["lang"].ToString();
           lstDisplay.ItemsSource = null;
           string text = EntrySearch.Text.ToLower();
           if (lang == "en")
           {
               lstDisplay.ItemsSource = _sqLiteConnection.Table<words>().Where(a => a.English.StartsWith(text)).ToList();
           }
           else
           {
               lstDisplay.ItemsSource = _sqLiteConnection.Table<words>().Where(a => a.Kurdish.Contains(text)).ToList();
           }

        }
        private void English_OnClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["lang"] = "en";
            this.English.IsEnabled = false;
            this.Kurdish.IsEnabled = true;
            EntrySearch.Placeholder = "Search";

        }

        private void Kurdish_OnClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["lang"] = "ku";
            this.Kurdish.IsEnabled = false;
            this.English.IsEnabled = true;
            EntrySearch.Placeholder = "lêgerîan";
        }

        private void Favorite_OnClicked(object sender, EventArgs e)
        {

            ImageButton button = (ImageButton) sender;
            Grid listViewItem = (Grid)button.Parent;
            Label enLabel = (Label)listViewItem.Children[0];
            Label kuLabel = (Label)listViewItem.Children[3];
            ImageButton favImageButton = (ImageButton)listViewItem.Children[2];
            FavoriteItems f = new FavoriteItems();
            f.English = enLabel.Text;
            f.Kurdish = kuLabel.Text;
            if (_sqLiteConnection.Table<FavoriteItems>().Where(a => a.Kurdish == f.Kurdish).Any()==true)
            {
                DependencyService.Get<INotification>().CreateNotification("Ararat Dictionary", $"You already have {enLabel.Text} in your favorite list");

            }
            else
            {
                _sqLiteConnection.BeginTransaction();
                _sqLiteConnection.Insert(f);
                _sqLiteConnection.Commit();
                //DisplayAlert("Favorite Item", "You have added ' " + enLabel.Text + " ' to your favorite list", "OK");
                DependencyService.Get<INotification>().CreateNotification("Ararat Dictionary", $"You have added {enLabel.Text} to your favorite list");
            }
        }

        async void Speak_OnClicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            Grid listViewItem = (Grid)button.Parent;
            Label label = (Label)listViewItem.Children[0];
            await TextToSpeech.SpeakAsync(label.Text);
        }
    }
}