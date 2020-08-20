using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace AraratDictionary
{
    public interface ISQLite
    {
        Task<SQLiteConnection> GetConnection();
        //List<words> GetWords();
    }
}