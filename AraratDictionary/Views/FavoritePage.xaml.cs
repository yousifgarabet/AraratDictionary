using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AraratDictionary;
using AraratDictionary.Models;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AraratDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        private SQLiteConnection _sqLiteConnection;
        public FavoritePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getFavoriteList();
            setTitle();
        }

        async void setTitle()
        {
            if (_sqLiteConnection.Table<FavoriteItems>().Count()==0)
            {
                lblFavorite.Text = "Favorite list is empty";
            }
            else
            {
                lblFavorite.Text = "My favorite words";

            }
        }

        public async void getFavoriteList()
        {

            _sqLiteConnection = await DependencyService.Get<ISQLite>().GetConnection();
            _sqLiteConnection.CreateTable<FavoriteItems>();
            lstFavorite.ItemsSource = null;
            lstFavorite.ItemsSource = _sqLiteConnection.Table<FavoriteItems>().ToList();
        }

        private void RemoveFavorite_OnClicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            Grid listViewItem = (Grid)button.Parent;
            Label enLabel = (Label)listViewItem.Children[0];
            Label kuLabel = (Label)listViewItem.Children[3];
            ImageButton favImageButton = (ImageButton)listViewItem.Children[1];
            FavoriteItems f = new FavoriteItems();
            f.English = enLabel.Text;
            f.Kurdish = kuLabel.Text;
            f.IsFavorite = "FALSE";
            _sqLiteConnection.Table<FavoriteItems>().Delete(a => a.English == f.English);
            lstFavorite.ItemsSource = null;
            lstFavorite.ItemsSource = _sqLiteConnection.Table<FavoriteItems>().ToList();
            setTitle();
            DependencyService.Get<INotification>().CreateNotification("Ararat Dictionary", $"You have Deleted {f.English} from your favorite list");
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