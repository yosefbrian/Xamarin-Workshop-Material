using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeratBadan
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnMale.Clicked += Btn_Clicked;
            btnFemale.Clicked += Btn_Clicked;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {            
            int beratIdeal = 0;
            int hbmi = 0;
            var myBtn = (Button)sender;

            if (myBtn.Text == "HITUNG BERAT IDEAL LAKI-LAKI")
            {
                beratIdeal = (int)Math.Floor((int.Parse(entryBil1.Text) - 100) - (0.1 * (int.Parse(entryBil1.Text) - 100)));
                hbmi = (int)Math.Round((int.Parse(entryBil2.Text) / ((double.Parse(entryBil1.Text) / 100) * (double.Parse(entryBil1.Text) / 100))));

                if (hbmi < 17)
                    kesimpulan.Text = string.Format("Kurus ( < 17kg )");
                else if (hbmi <= 23)
                    kesimpulan.Text = string.Format("normal (17 - 23kg)");
                else if (hbmi <= 27)
                    kesimpulan.Text = string.Format("Kegemukan (23 - 27kg)");
                else if (hbmi > 27)
                    kesimpulan.Text = string.Format("Obesitas ( > 27kg )");
            }

        else if (myBtn.Text == "HITUNG BERAT IDEAL PEREMPUAN") {
              beratIdeal = (int)Math.Floor((int.Parse(entryBil1.Text) - 100) - (0.15 * (int.Parse(entryBil1.Text) - 100)));
              hbmi = (int)Math.Round((int.Parse(entryBil2.Text) / ((double.Parse(entryBil1.Text) / 100) * (double.Parse(entryBil1.Text) / 100))));
            if (hbmi < 18)
                kesimpulan.Text = string.Format("Kurus ( < 18kg )");
            else if (hbmi <= 25)
                kesimpulan.Text = string.Format("normal (18 - 25kg)");
            else if (hbmi <= 27)
                kesimpulan.Text = string.Format("Kegemukan (25 - 27kg)");
            else if (hbmi > 27)
                kesimpulan.Text = string.Format("Obesitas ( > 27kg )");
         }

            entryHasil.Text = beratIdeal.ToString();
            bmi.Text = hbmi.ToString();
        }

    }
}

//switch (myBtn.Text)
//{
//    case "HITUNG BERAT IDEAL LAKI-LAKI":
//        beratIdeal = (int)Math.Floor((int.Parse(entryBil1.Text) - 100) - (0.1 * (int.Parse(entryBil1.Text) - 100)));
//        hbmi = (int)Math.Round((int.Parse(entryBil2.Text) / ((double.Parse(entryBil1.Text)/100)*(double.Parse(entryBil1.Text)/100))));
//        break;
//    case "HITUNG BERAT IDEAL PEREMPUAN":
//        beratIdeal = (int)Math.Floor((int.Parse(entryBil1.Text) - 100) - (0.15 * (int.Parse(entryBil1.Text) - 100)));
//        hbmi = (int)Math.Round((int.Parse(entryBil2.Text) / ((double.Parse(entryBil1.Text) / 100) * (double.Parse(entryBil1.Text) / 100))));
//        break;
//}
