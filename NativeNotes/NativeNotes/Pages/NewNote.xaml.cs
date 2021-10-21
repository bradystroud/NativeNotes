using System;
using System.Threading.Tasks;
using NativeNotes.Models;
using NativeNotes.Services;
using Xamarin.Forms;

namespace NativeNotes.Pages
{
    public partial class NewNote : ContentPage
    {
        public NotesFileService FileService { get; set; }
        public NoteModel Model { get; set; }

        public NewNote()
        {
            InitializeComponent();
            FileService = new NotesFileService();

            SaveButton.Clicked += async (sender, e) => await Button_OnClicked(sender, e);
        }

        private async Task Button_OnClicked(object sender, EventArgs e)
        {
            Model = new NoteModel
            {
                Id = Guid.NewGuid(),
                Heading = HeadingEntry.Text,
                Body = BodyEditor.Text,
                ReminderDate = Date.Date
            };

            FileService.AddNote(Model);

            await Navigation.PopAsync();
        }
    }
}