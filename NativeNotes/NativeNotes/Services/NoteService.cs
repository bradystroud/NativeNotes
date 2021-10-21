using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NativeNotes.Models;
using Newtonsoft.Json;

namespace NativeNotes.Services
{
    public class NotesFileService
    {
        private string FilePath { get; set; }

        public NotesFileService()
        {
            FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "notes.json");
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            if (!File.ReadLines(FilePath).Any())
            {
                var list = new List<NoteModel>();
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
            }
            // var list = new List<NoteModel>();
            // File.WriteAllText(FilePath, JsonConvert.SerializeObject(list));
        }

        public void AddNote(NoteModel note)
        {
            var contents = File.ReadAllText(FilePath);
            Console.WriteLine(contents);
            var notesList = JsonConvert.DeserializeObject<IList<NoteModel>>(contents);
            notesList?.Add(note);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(notesList));
        }

        public void RemoveNote(NoteModel note)
        {
            var contents = File.ReadAllText(FilePath);
            var notesList = JsonConvert.DeserializeObject<List<NoteModel>>(contents);
            notesList?.RemoveAll(n => n.Id == note.Id);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(notesList));
        }


        public IList<NoteModel> ReadNotes()
        {
            if (File.Exists(FilePath))
            {
                var text = File.ReadAllText(FilePath);
                var test = JsonConvert.DeserializeObject<NoteModel[]>(text);
                return test.ToList();
            }

            Console.WriteLine("File not found!");
            return new List<NoteModel>();
        }
    }
}