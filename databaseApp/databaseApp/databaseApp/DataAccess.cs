using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleSQLite
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLIte>().GetConnection();
            dbConn.CreateTable<Transaksi>();
        }

        public List<Transaksi> GetAllTransaksi()
        {
            return dbConn.Query<Transaksi>("Select * From [Transaksi]");
        }

        public int SaveTransaksi(Transaksi aTransaksi)
        {
            return dbConn.Insert(aTransaksi);
        }

        public int DeleteTransaksi(Transaksi aTransaksi)
        {
            return dbConn.Delete(aTransaksi);
        }

        public int EditTransaksi(Transaksi aTransaksi)
        {
            return dbConn.Update(aTransaksi);
        }
    }
}