using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ta_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowMovie : ContentPage
    {
        public ShowMovie()
        {
            InitializeComponent();
            btnBack.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync(true);
            };
        }
    }
}
