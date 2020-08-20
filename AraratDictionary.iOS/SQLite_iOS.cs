using System;
using System.IO;
using System.Threading.Tasks;
using AraratDictionary.iOS;
using Foundation;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace AraratDictionary.iOS
{
    public class SQLite_iOS:ISQLite
    {

        SQLiteConnection con;

        [Obsolete]
        public async Task<SQLiteConnection> GetConnection()
        {
            String databaseName = "db.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(documentsPath, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            var path = Path.Combine(libFolder, databaseName);
            
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("db", "db3");
                File.Copy(existingDb, path);
            }

            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}