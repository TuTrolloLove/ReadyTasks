using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReadyTasks.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private IUserRepository _userRepository;
        private INoteRepository _noteRepository;
        public AdminViewModel()
        {
            _userRepository = new UserRepository();
            _noteRepository = new NoteRepository();
        }

        public List<String> findUser(string mail)
        {
            // If the mail is a number, it is an ID
            if (int.TryParse(mail, out int id))
            {
                return _userRepository.GetUserById(id);
            }
            else // If the mail is not a number, it is an email
            {
                return _userRepository.GetByMailWithoutPassword(mail);
            }
        }
        public bool isAdmin(int userId)
        {
            return _userRepository.isAdmin(userId);
        }
        public int countNoutes(int userID)
        {
            return _noteRepository.obtainNotesCount(userID);
        }
        public List<String> obtainNotes(int userID)
        {
            List<NoteModel> notes = _noteRepository.obtainNotes(userID);
            List<String> notesString = new List<string>();
            foreach (NoteModel note in notes)
            {
                notesString.Add(note.ToString());
            }
            return notesString;
        }
        public List<String> obtainNoteIDNote(int idNote)
        {
            return _noteRepository.obtainNoteIDNote(idNote);
        }
        public (List<String>, List<String>) obtainNoteByTitleAndContent(string title, string content)
        {
            return _noteRepository.obtainNotesByTitleAndContent(title, content);
        }
        public (List<String>, List<String>) obtainNoteByTitleContentAndId(string title, string content, int id_users)
        {
            return _noteRepository.obtainNotesByTitleContentAndIdUser(title, content, id_users);
        }
        public (List<String>, List<String>) obtainNoteByTitleContentAndIdNote(string title, string content, int id_note)
        {
            return _noteRepository.obtainNotesByTitleContentAndIdNote(title, content, id_note);
        }
        public int getAllUsersCount()
        {
            return _userRepository.getAllUsersCount();
        }
        public int getAllNotesCount()
        {
            return _noteRepository.getAllNotesCount();
        }
        public int getAllNotesCompletedCount()
        {
            return _noteRepository.getAllNotesCompletedCount();
        }
        public int getAllNotesUncompletedCount()
        {
            return _noteRepository.getAllNotesUncompletedCount();
        }
        public int getAllNotesHighPriorityCount()
        {
            return _noteRepository.getAllNotesHighPriorityCount();
        }
        public int getAllNotesMediumPriorityCount()
        {
            return _noteRepository.getAllNotesMediumPriorityCount();
        }
        public int getAllNotesLowPriorityCount()
        {
            return _noteRepository.getAllNotesLowPriorityCount();
        }
        public double getPercentajeNotesCompleted()
        {
            int notesCompleted = _noteRepository.getAllNotesCompletedCount();
            int totalNotes = _noteRepository.getAllNotesCount();
            // Percentages with two decimals
            return Math.Round((double)(notesCompleted * 100) / totalNotes, 2);
        }
        public double getPercentajeNotesUncompleted()
        {
            int notesUncompleted = _noteRepository.getAllNotesUncompletedCount();
            int totalNotes = _noteRepository.getAllNotesCount();
            // Percentages with two decimals
            return Math.Round((double)(notesUncompleted * 100) / totalNotes, 2);
        }
        public double getPercentajeNotesHighPriority()
        {
            int notesHighPriority = _noteRepository.getAllNotesHighPriorityCount();
            int totalNotes = _noteRepository.getAllNotesCount();
            // Percentages with two decimals
            return Math.Round((double)(notesHighPriority * 100) / totalNotes, 2);
        }
        public double getPercentajeNotesMediumPriority()
        {
            int notesMediumPriority = _noteRepository.getAllNotesMediumPriorityCount();
            int totalNotes = _noteRepository.getAllNotesCount();
            // Percentages with two decimals
            return Math.Round((double)(notesMediumPriority * 100) / totalNotes, 2);
        }
        public double getPercentajeNotesLowPriority()
        {
            int notesLowPriority = _noteRepository.getAllNotesLowPriorityCount();
            int totalNotes = _noteRepository.getAllNotesCount();
            // Percentages with two decimals
            return Math.Round((double)(notesLowPriority * 100) / totalNotes, 2);
        }


    }
}
