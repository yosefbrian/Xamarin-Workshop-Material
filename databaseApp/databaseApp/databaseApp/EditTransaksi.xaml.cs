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
    public partial class EditTransaksi : ContentPage
    {
        Transaksi mSelTransaksi;
        public EditTransaksi(Transaksi aSelectedTrans)
        {
            InitializeComponent();
            mSelTransaksi = aSelectedTrans;
            BindingContext = mSelTransaksi;
        }


        public void OnSaveClicked(object sender, EventArgs args)
        {
            mSelTransaksi.Trans = txtEmpTrans.Text;
            mSelTransaksi.Amount = txtAmount.Text;
            mSelTransaksi.Date = txtDate.Text;
            mSelTransaksi.Info = txtInfo.Text;
            App.DBUtils.EditTransaksi(mSelTransaksi);
            Navigation.PushAsync(new ManageTransaksi());
        }
    }
}
