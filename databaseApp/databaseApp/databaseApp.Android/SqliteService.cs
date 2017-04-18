using System;
using Xamarin.Forms;
using SampleSQLite.Droid;
using System.IO;
using SampleSQLite;

[assembly: Dependency(typeof(SqliteService))]
namespace SampleSQLite.Droid
{
    public class SqliteService : ISQLIte
    {
        public SqliteService() { }
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Transaksi.db3";
            string documentsPath =
                   Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            return conn;
        }
    }
}