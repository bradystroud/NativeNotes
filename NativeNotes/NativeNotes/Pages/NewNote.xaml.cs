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
                Heading = HeadingEntry.Text,
                Body = BodyEditor.Text,
                ReminderDate = Date.Date
            };
            Console.WriteLine(Model.Body);
            Console.WriteLine(Model.Heading);
            Console.WriteLine(Model.ReminderDate);
            
            FileService.AddNote(Model);

            await Navigation.PopAsync();
        }
    }
}