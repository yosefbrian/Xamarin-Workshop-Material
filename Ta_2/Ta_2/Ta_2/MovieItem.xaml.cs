using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ta_2
{

    public partial class MovieItem : ContentPage
    {
       // bool alertShown = false;
        public MovieItem()
        {
            InitializeComponent();
        }

         protected async override void OnAppearing() 
    {
 
            base.OnAppearing(); 
            listView.ItemsSource = await App.MovieManager.GetTasksAsync();         
         
    }






        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try { 
            var movieItem = e.SelectedItem as Movie;
            var moviePage = new ShowMovie();
            moviePage.BindingContext = movieItem;
            Navigation.PushAsync(moviePage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Kesalahan {0}", ex.Message);
            }

        }

    }
}
