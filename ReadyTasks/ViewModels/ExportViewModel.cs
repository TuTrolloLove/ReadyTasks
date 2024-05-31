using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadyTasks.ViewModels
{
    public class ExportViewModel : ViewModelBase
    {
        private INoteRepository _noteRepository;
        public ExportViewModel()
        {
            _noteRepository = new NoteRepository();
        }

        public void exportAllNotes(int userId, string exportOption)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                List<NoteModel> exportNotesList = _noteRepository.obtainNotes(userId);
                if (exportNotesList.Count == 0)
                {
                    MessageBox.Show(System.Windows.Application.Current.Resources["ExportFormatViewModelNoNotesMBText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[,] data = new string[exportNotesList.Count + 1, 4];

                // Add headers to the data array
                data[0, 0] = System.Windows.Application.Current.Resources["ExportFormatViewModelHeader1"] as string;
                data[0, 1] = System.Windows.Application.Current.Resources["ExportFormatViewModelHeader2"] as string;
                data[0, 2] = System.Windows.Application.Current.Resources["ExportFormatViewModelHeader3"] as string;
                data[0, 3] = System.Windows.Application.Current.Resources["ExportFormatViewModelHeader4"] as string;

                int i = 1; // Start from the second row
                foreach (NoteModel note in exportNotesList)
                {
                    data[i, 0] = note.title;
                    data[i, 1] = note.body.Replace(Environment.NewLine, " "); // Replaces line breaks with a space
                    data[i, 2] = note.priority;
                    data[i, 3] = note.completed;
                    i++;
                }

                if (exportOption.Equals("CSV"))
                {
                    // User can save the CSV file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder csvContenido = new StringBuilder();

                        for (int j = 0; j < longitud; j++)
                        {
                            csvContenido.AppendLine(string.Join(";", data[j, 0], data[j, 1], data[j, 2], data[j, 3]));
                        }

                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString(), Encoding.UTF8);
                            MessageBox.Show(System.Windows.Application.Current.Resources["ExportFormatViewModelTBSavedFileText"] as string,
                                System.Windows.Application.Current.Resources["ExportFormatViewModelTBSavedFileCaption"] as string,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["ExportFormatViewModelTBSavedFileErrorText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        };

                    }
                }
                else
                {
                    // User can save the TXT file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder txtContenido = new StringBuilder();

                        for (int j = 0; j < longitud; j++)
                        {
                            // Add a header to each note
                            txtContenido.AppendLine(System.Windows.Application.Current.Resources["ExportFormatViewModelTXTContent"] as string);
                            string titulo = System.Windows.Application.Current.Resources["ExportFormatViewModelTXTTitleNoteHeader"] as string;
                            txtContenido.AppendLine($"{titulo} {data[j, 0]}");
                            string body = System.Windows.Application.Current.Resources["ExportFormatViewModelTXTBodyNoteHeader"] as string;
                            txtContenido.AppendLine($"{body} {data[j, 1]}");
                            string priority = System.Windows.Application.Current.Resources["ExportFormatViewModelTXTPriorityNoteHeader"] as string;
                            txtContenido.AppendLine($"{priority} {data[j, 2]}");
                            string completed = System.Windows.Application.Current.Resources["ExportFormatViewModelTXTCompletedNoteHeader"] as string;
                            txtContenido.AppendLine($"{completed} {data[j, 3]}");
                        }

                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, txtContenido.ToString());
                            MessageBox.Show(System.Windows.Application.Current.Resources["ExportFormatViewModelTBSavedFileText"] as string,
                               System.Windows.Application.Current.Resources["ExportFormatViewModelTBSavedFileCaption"] as string,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["ExportFormatViewModelTBSavedFileErrorText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        };
                    }
                }
            }
            else if (language.Equals("en"))
            {
                List<NoteModel> exportNotesList = _noteRepository.obtainNotes(userId);
                if (exportNotesList.Count == 0)
                {
                    MessageBox.Show(System.Windows.Application.Current.Resources["EN_ExportFormatViewModelNoNotesMBText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[,] data = new string[exportNotesList.Count + 1, 4];

                // Add headers to the data array
                data[0, 0] = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelHeader1"] as string;
                data[0, 1] = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelHeader2"] as string;
                data[0, 2] = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelHeader3"] as string;
                data[0, 3] = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelHeader4"] as string;

                int i = 1; // Start from the second row
                foreach (NoteModel note in exportNotesList)
                {
                    data[i, 0] = note.title;
                    data[i, 1] = note.body.Replace(Environment.NewLine, " "); // Replaces line breaks with a space
                    data[i, 2] = note.priority;
                    data[i, 3] = note.completed;
                    i++;
                }

                if (exportOption.Equals("CSV"))
                {
                    // User can save the CSV file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder csvContenido = new StringBuilder();

                        for (int j = 0; j < longitud; j++)
                        {
                            csvContenido.AppendLine(string.Join(";", data[j, 0], data[j, 1], data[j, 2], data[j, 3]));
                        }

                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString(), Encoding.UTF8);
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTBSavedFileText"] as string,
                                                               System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTBSavedFileCaption"] as string,
                                                                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTBSavedFileErrorText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {  // User can save the TXT file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder txtContenido = new StringBuilder();

                        for (int j = 0; j < longitud; j++)
                        {
                            // Add a header to each note
                            txtContenido.AppendLine(System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTXTContent"] as string);
                            string titulo = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTXTTitleNoteHeader"] as string;
                            txtContenido.AppendLine($"{titulo} {data[j, 0]}");
                            string body = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTXTBodyNoteHeader"] as string;
                            txtContenido.AppendLine($"{body} {data[j, 1]}");
                            string priority = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTXTPriorityNoteHeader"] as string;
                            txtContenido.AppendLine($"{priority} {data[j, 2]}");
                            string completed = System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTXTCompletedNoteHeader"] as string;
                            txtContenido.AppendLine($"{completed} {data[j, 3]}");
                        }

                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, txtContenido.ToString());
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTBSavedFileText"] as string,
                               System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTBSavedFileCaption"] as string,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_ExportFormatViewModelTBSavedFileErrorText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        };
                    }
                }
            }
            else
            {
                List<NoteModel> exportNotesList = _noteRepository.obtainNotes(userId);
                if (exportNotesList.Count == 0)
                {
                    MessageBox.Show(System.Windows.Application.Current.Resources["VA_ExportFormatViewModelNoNotesMBText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[,] data = new string[exportNotesList.Count + 1, 4];

                // Add headers to the data array
                data[0, 0] = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelHeader1"] as string;
                data[0, 1] = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelHeader2"] as string;
                data[0, 2] = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelHeader3"] as string;
                data[0, 3] = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelHeader4"] as string;

                int i = 1; // Start from the second row
                foreach (NoteModel note in exportNotesList)
                {
                    data[i, 0] = note.title;
                    data[i, 1] = note.body.Replace(Environment.NewLine, " "); // Replaces line breaks with a space
                    data[i, 2] = note.priority;
                    data[i, 3] = note.completed;
                    i++;
                }

                if (exportOption.Equals("CSV"))
                {
                    // User can save the CSV file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder csvContenido = new StringBuilder();

                        for (int j = 0; j < longitud; j++)
                        {
                            csvContenido.AppendLine(string.Join(";", data[j, 0], data[j, 1], data[j, 2], data[j, 3]));
                        }

                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString(), Encoding.UTF8);
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTBSavedFileText"] as string,
                                                               System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTBSavedFileCaption"] as string,
                                                                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTBSavedFileErrorText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // User can save the TXT file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder txtContenido = new StringBuilder();

                        for (int j = 0; j < longitud; j++)
                        {
                            // Add a header to each note
                            txtContenido.AppendLine(System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTXTContent"] as string);
                            string titulo = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTXTTitleNoteHeader"] as string;
                            txtContenido.AppendLine($"{titulo} {data[j, 0]}");
                            string body = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTXTBodyNoteHeader"] as string;
                            txtContenido.AppendLine($"{body} {data[j, 1]}");
                            string priority = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTXTPriorityNoteHeader"] as string;
                            txtContenido.AppendLine($"{priority} {data[j, 2]}");
                            string completed = System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTXTCompletedNoteHeader"] as string;
                            txtContenido.AppendLine($"{completed} {data[j, 3]}");
                        }

                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, txtContenido.ToString());
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTBSavedFileText"] as string,
                               System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTBSavedFileCaption"] as string,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_ExportFormatViewModelTBSavedFileErrorText"] as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        };
                    }
                }
            }
        }
    }
}
