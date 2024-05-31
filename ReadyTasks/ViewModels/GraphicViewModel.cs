using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.VisualStyles;

namespace ReadyTasks.ViewModels
{
    public class GraphicViewModel : ViewModelBase
    {
        private INoteRepository _noteRepository;
        List<NoteModel> notes;

        public GraphicViewModel()
        {
            _noteRepository = new NoteRepository();
        }


        public List<int> doGraphics(int userId)
        {
            notes = _noteRepository.obtainNotes(userId);
            // Amount of completed and not completed notes
            int completedNotes = 0;
            int notCompletedNotes = 0;
            // Amount of notes
            int totalNotes = notes.Count;
            // Amount of notes with high, medium and low priority
            int highPriority = 0;
            int mediumPriority = 0;
            int lowPriority = 0;

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].completed == "yes")
                {
                    completedNotes++;
                }
                else if (notes[i].completed == "no")
                {
                    notCompletedNotes++;
                }
            }

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].priority == "Baja" || notes[i].priority == "Baixa" || notes[i].priority == "Low")
                {
                    lowPriority++;
                }
                else if (notes[i].priority == "Media" || notes[i].priority == "Mitjana" || notes[i].priority == "Medium")
                {
                    mediumPriority++;
                }
                else if (notes[i].priority == "Alta" || notes[i].priority == "High")
                {
                    highPriority++;
                }
            }
            Debug.WriteLine("Notas completadas: " + completedNotes);
            Debug.WriteLine("Notas no completadas: " + notCompletedNotes);
            Debug.WriteLine("Notas totales: " + totalNotes);
            Debug.WriteLine("Notas con prioridad alta: " + highPriority);
            Debug.WriteLine("Notas con prioridad media: " + mediumPriority);
            Debug.WriteLine("Notas con prioridad baja: " + lowPriority);

            // Return the values of the graphics in a list to print them in the view
            List<int> values = new List<int>();
            values.Add(completedNotes);
            values.Add(notCompletedNotes);
            values.Add(totalNotes);
            values.Add(highPriority);
            values.Add(mediumPriority);
            values.Add(lowPriority);
            return values;

        }
    }
}
