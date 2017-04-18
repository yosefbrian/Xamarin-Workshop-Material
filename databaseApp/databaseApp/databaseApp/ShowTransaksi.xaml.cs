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

  
        public partial class ShowTransaksi : ContentPage
        {
            Transaksi mSelTransaksi;
            public ShowTransaksi(Transaksi aSelectedtrans)
            {
                InitializeComponent();
                mSelTransaksi = aSelectedtrans;
                BindingContext = mSelTransaksi;
            }

            public void OnEditClicked(object sender, EventArgs args)
            {
                Navigation.PushAsync(new EditTransaksi(mSelTransaksi));
            }
            public async void OnDeleteClicked(object sender, EventArgs args)
            {
                bool accepted = await DisplayAlert("Konfirmasi", "Apakah anda yakin untuk mendelete data ?", "Yes", "No");
                if (accepted)
                {
                    App.DBUtils.DeleteTransaksi(mSelTransaksi);
                }
                await Navigation.PushAsync(new ManageTransaksi());
            }
        }
    }

