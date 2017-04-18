using SampleSQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace databaseApp
{
    public partial class App : Application
    {
        private static DataAccess dbUtils;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ManageTransaksi());
        }

        public static DataAccess DBUtils
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }
    }
}
