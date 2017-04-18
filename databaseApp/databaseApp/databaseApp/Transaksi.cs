using SQLite.Net.Attributes;
using System;

namespace SampleSQLite
{
    public class Transaksi
    {
        [PrimaryKey, AutoIncrement]
        public long MakulId { get; set; }
        [NotNull]
        public string Trans { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string Info { get; set; }
    }
}