using SQLite;

namespace AraratDictionary
{
    [Table("words")]
    public class words
    {
        [PrimaryKey, AutoIncrement, Column("No")]
        public int No { get; set; }
        [Column("English")]
        public string English { get; set; }
        [Column("Kurdish")]
        public string Kurdish { get; set; }
        [Column("IsFavorite")]
        public string IsFavorite { get; set; }
    }
}