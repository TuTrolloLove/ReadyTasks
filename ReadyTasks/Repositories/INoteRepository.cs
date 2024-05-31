using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadyTasks.Models;

namespace ReadyTasks.Repositories
{
    interface INoteRepository
    {
        public int getAllNotesLowPriorityCount();
        public int getAllNotesMediumPriorityCount();
        public int getAllNotesHighPriorityCount();
        public int getAllNotesUncompletedCount();
        public int getAllNotesCompletedCount();
        public int getAllNotesCount();
        public List<NoteModel> obtainNotes(int id_user);
        public List<String> obtainNoteIDNote(int idNote);
        public (List<string>, List<string>) obtainNotesByTitleAndContent(string title, string content);
        public (List<string>, List<string>) obtainNotesByTitleContentAndIdUser(string title, string content, int id_users);
        public (List<string>, List<string>) obtainNotesByTitleContentAndIdNote(string title, string content, int id_note);
        public int obtainNotesCount(int id_user);
        public void addNoteToUser(NoteModel note, int id_user);
        public bool findNote(NoteModel note, int id_user);
        public bool editNote(NoteModel note, int id_user);
        public bool deleteNote(int noteId, int id_user);
        public bool deleteAllNotes(int id_user);
        public bool deleteAllNotesOnly(int id_user);
        public bool markAsCompleted(int noteId, int id_user, string isCompleted);

    }
}
