using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    public partial class TodoListPage : ContentPage
    {
        bool alertShown = false;

        public TodoListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.TodoManager.GetTasksAsync();
        }

        void OnAddItemClicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem()
            {
                ID = Guid.NewGuid().ToString()
            };
            var todoPage = new TodoItemPage(true);
            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(todoPage);
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as TodoItem;
            var todoPage = new TodoItemPage();
            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(todoPage);
        }
    }
}
