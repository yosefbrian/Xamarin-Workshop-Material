﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST
{
    public partial class TodoItemPage : ContentPage
    {
        bool isNewItem;

        public TodoItemPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }

        async void OnSaveActivated(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.TodoManager.SaveTaskAsync(todoItem, isNewItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteActivated(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.TodoManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
