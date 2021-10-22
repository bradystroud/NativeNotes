using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using NativeNotes.Models;
using NativeNotes.Services;

namespace NativeNotes.Pages
{
    public partial class MainPage
    {
        public NotesFileService Service { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Service = new NotesFileService();
        }

        protected override void OnAppearing()
        {
            ListView.ItemsSource = Service.ReadNotes();
        }

        private async void MenuItem_OnPressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNote());
        }

        private async void DeleteButton_OnPressed(object sender, EventArgs e)
        {
            if (!await DisplayAlert("Confirm delete", "Are you sure you want to delete?", "Yes", "No")) return;
            
            Service.RemoveNote((NoteModel) ((MenuItem) sender).BindingContext);
            ListView.ItemsSource = Service.ReadNotes();
        }
    }
}