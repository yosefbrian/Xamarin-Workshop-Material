using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListNav
{
    public partial class MainPage : ContentPage
    {
    
    
        public MainPage()
        {

         

            InitializeComponent();
            BindingContext = new ListViewImageCellViewModel();

            listView.ItemTapped += async (sender, e) =>
            {
                var dataItem = e.Item as ListItem;
                await Navigation.PushAsync(new Detail(dataItem));
            };
        }
        public class ListViewImageCellViewModel : BindableObject
        {
            private List<ListItem> listItems;
            public List<ListItem> ListItems
            {
                get { return listItems; }
                set
                {
                    listItems = value;
                    OnPropertyChanged("ListItems");
                }
            }

            public ListViewImageCellViewModel()
            {
                listItems = new List<ListItem>
                {
                    new ListItem { Source="car1.jpg", Title="Range Rover", Description="Angsuran Mulai Rp. 16.000.000", Info="Mesin 1500cc 7 penumpang" },
                    new ListItem { Source="car2.jpg", Title="Rolls Royce", Description="Angsuran Mulai Rp. 16.210.000", Info="Mesin 2500cc 8 penumpang"},
                    new ListItem { Source="car3.jpg", Title="Porsche Mecan", Description="Angsuran Mulai Rp. 12.540.000", Info="Mesin 1600cc 6 penumpang"},
                    new ListItem { Source="car4.jpg", Title="Mercedez Benz", Description="Angsuran Mulai Rp. 11.110.000", Info="Mesin 1900cc 5 penumpang"},
                    new ListItem { Source="car5.jpg", Title="BMW 5 Series",Description="Angsuran Mulai Rp. 12.000.000", Info="Mesin 2200cc 7 penumpang" }
                };
            }
        }

    }
}
