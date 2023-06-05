﻿
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Models;
using MAUITraining.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUITraining.ViewModels
{
    internal class NotesViewModel : IQueryAttributable
    {
        public NotesViewModel()
        {
            AllNotes = new ObservableCollection<NoteViewModel>(
                Note.LoadAll().Select(n => new NoteViewModel(n)).OrderBy(order => order.Date));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<NoteViewModel>(SelectNoteAsync);
            
        }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(NotesPage));
        }

        private async Task SelectNoteAsync(NoteViewModel note)
        {
            if(note != null)
                await Shell.Current.GoToAsync($"{nameof(NotesPage)}?load={note.Identifier}");
        }
        

        public ObservableCollection<NoteViewModel> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }
        

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                    matchedNote.Reload();

                // If note isn't found, it's new; add it.
                else
                    AllNotes.Add(new NoteViewModel(Note.Load(noteId)));
            }
        }
    }
}
