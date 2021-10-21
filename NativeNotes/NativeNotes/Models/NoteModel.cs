using System;
namespace NativeNotes.Models
{
    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Body { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}

