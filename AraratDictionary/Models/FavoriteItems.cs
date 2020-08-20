using SQLite;

namespace AraratDictionary.Models
{
    public class FavoriteItems
    {
        [PrimaryKey, AutoIncrement]
        public int No { get; set; }
        public string English { get; set; }
        public string Kurdish { get; set; }
        public string IsFavorite { get; set; }
    }
}