using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ta_2.Data;
using Xamarin.Forms;

namespace Ta_2
{
    public partial class App : Application
    {
        public static Data.MovieManager MovieManager { get; private set; }

        public App()
        {
            InitializeComponent();
            MovieManager = new MovieManager(new RestService());

            MainPage = new NavigationPage(new MovieItem());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
