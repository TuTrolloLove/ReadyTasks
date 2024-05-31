using Microsoft.VisualBasic.ApplicationServices;
using ReadyTasks.Models;
using ReadyTasks.Repositories;
using ReadyTasks.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadyTasks.ViewModels
{
    public class AddNoteViewModel : ViewModelBase
    {
        private INoteRepository noteRepository;
        private NoteModel _note;

        public ICommand AddNoteCommand { get; }

        public AddNoteViewModel(int userId)
        {
            noteRepository = new NoteRepository();
        }

        public void AddNote(int userId, string title, string body, string priority)
        {
            NoteModel noteModel = new NoteModel();
            noteModel.title = title;
            noteModel.body = body;
            noteModel.priority = priority;
            noteModel.completed = "no";
            NoteRepository noteRepository = new NoteRepository();
            noteRepository.addNoteToUser(noteModel, userId);
        }
    }
}
