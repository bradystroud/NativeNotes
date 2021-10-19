using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using NativeNotes.Models;
using NativeNotes.Services;

namespace NativeNotes.Pages
{
    public partial class MainPage : ContentPage
    {
        public IList<NoteModel> Notes { get; set; }
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

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNote());
        }

        private void OnDeleteNote(NoteModel note)
        {
            Service.RemoveNote(note);
        }

        private void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            Service.RemoveNote((NoteModel) ((MenuItem) sender).BindingContext);
            ListView.ItemsSource = Service.ReadNotes();
        }
    }
}