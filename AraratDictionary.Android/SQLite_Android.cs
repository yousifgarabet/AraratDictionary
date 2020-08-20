using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AraratDictionary.Droid;
using AraratDictionary.Models;
using Java.Text;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: Dependency(typeof(SQLite_Android))]
namespace AraratDictionary.Droid
{
    class SQLite_Android : ISQLite
    {
        SQLiteConnection con;

        [Obsolete]
        public async Task<SQLiteConnection> GetConnection()
        {
             string dbName = "db.db3";
             string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, dbName);

            if (!File.Exists(path))
            {
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                await Forms.Context.Assets.Open(dbName).CopyToAsync(writeStream);
            }

            //con.CreateTable<FavoriteItems>();
           
            
            con = new SQLiteConnection(path);
            
            return con;
        }

        
    }
}