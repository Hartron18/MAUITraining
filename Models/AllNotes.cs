using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; }
        public AllNotes() => LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            //Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Note> notes = Directory.EnumerateFiles(appDataPath, "*.notes.txt")
                .Select(filename => new Note()
                {
                    FileName = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                })
                .OrderBy(x => x.Date);

            foreach (Note note in notes) Notes.Add(note);

        }
    }
}
