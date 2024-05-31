using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyTasks.ViewModels
{
    public class EditNoteViewModel : ViewModelBase
    {
        private INoteRepository _noteRepository;
        private NoteModel _note;

        public EditNoteViewModel(int userId)
        {
            _noteRepository = new NoteRepository();
        }

        public bool ShowNoteToEdit(int userId, int idNote, string title, string body, string priority, string completed)
        {
            _note = new NoteModel
            {
                id = idNote,
                id_users = userId,
                title = title,
                body = body,
                priority = priority,
                completed = completed
            };
            if (_noteRepository.findNote(_note, userId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool editNote(int userId, int idNote, string title, string body, string priority)
        {
            _note = new NoteModel
            {
                id = idNote,
                id_users = userId,
                title = title,
                body = body,
                priority = priority,
            };
            if (_noteRepository.editNote(_note, userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
