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
    public partial class ManageTransaksi : ContentPage
    {
        public ManageTransaksi()
        {
            InitializeComponent();
            var vList = App.DBUtils.GetAllTransaksi();
            lstData.ItemsSource = vList;
        }


        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelUser = (Transaksi)e.SelectedItem;
            Navigation.PushAsync(new ShowTransaksi(vSelUser));
        }

        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddTransaksi());
        }



    }



}
