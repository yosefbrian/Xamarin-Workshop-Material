using SampleSQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace databaseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTransaksi : ContentPage
    {
        public AddTransaksi()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            var vTransaksi = new Transaksi()
            {
                Trans = txtTrans.Text,
                Amount = txtAmount.Text,
                Date = txtDate.Text,
                Info = txtInfo.Text
            };
            App.DBUtils.SaveTransaksi(vTransaksi);
            Navigation.PushAsync(new ManageTransaksi());
        }

    }
}
