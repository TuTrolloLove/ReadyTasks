using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.VisualBasic.ApplicationServices;
using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ReadyTasks.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private INoteRepository _noteRepository;
        public HomeViewModel()
        {
            _noteRepository = new NoteRepository();
        }
        public bool deleteNote(int noteId, int id_user)
        {
            if (_noteRepository.deleteNote(noteId, id_user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool markAsCompleted(int noteId, int id_user, string isCompleted)
        {
            if (_noteRepository.markAsCompleted(noteId, id_user, isCompleted))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void exportNote(string exportOption, string noteTitle, string noteBody, string notePriority, string noteCompleted)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                string[,] data = new string[4, 2]
                    {
                    { System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteTitleHeader"] as string, noteTitle },
                    { System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteBodyHeader"] as string, noteBody },
                    { System.Windows.Application.Current.Resources["HomeViewViewModelExportNotePriorityHeader"] as string, notePriority },
                    { System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteCompletedHeader"] as string, noteCompleted}
                    };
                if (exportOption.Equals("CSV"))
                {
                    // User can save the CSV file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder csvContenido = new StringBuilder();

                        for (int i = 0; i < longitud; i++)
                        {
                            csvContenido.AppendLine(string.Join(";", data[i, 0], data[i, 1]));
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString(), Encoding.UTF8);
                        // Alert file saved
                        System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteCompletedMBText"] as string,
                            System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteCompletedMBCaption"] as string,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        StringBuilder csvContenido = new StringBuilder();

                        for (int i = 0; i < longitud; i++)
                        {
                            csvContenido.AppendLine(string.Join(": ", data[i, 0], data[i, 1]));
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString());
                        // Alert file saved
                        System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteCompletedMBText"] as string,
                             System.Windows.Application.Current.Resources["HomeViewViewModelExportNoteCompletedMBCaption"] as string,
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else if (language.Equals("en"))
            {
                string[,] data = new string[4, 2]
                    {
                    { System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteTitleHeader"] as string, noteTitle },
                    { System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteBodyHeader"] as string, noteBody },
                    { System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNotePriorityHeader"] as string, notePriority },
                    { System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteCompletedHeader"] as string, noteCompleted}
                    };
                if (exportOption.Equals("CSV"))
                {
                    // User can save the CSV file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder csvContenido = new StringBuilder();

                        for (int i = 0; i < longitud; i++)
                        {
                            csvContenido.AppendLine(string.Join(";", data[i, 0], data[i, 1]));
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString(), Encoding.UTF8);
                        // Alert file saved
                        System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteCompletedMBText"] as string,
                            System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteCompletedMBCaption"] as string,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        StringBuilder csvContenido = new StringBuilder();

                        for (int i = 0; i < longitud; i++)
                        {
                            csvContenido.AppendLine(string.Join(": ", data[i, 0], data[i, 1]));
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString());
                        // Alert file saved
                        System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteCompletedMBText"] as string,
                             System.Windows.Application.Current.Resources["EN_HomeViewViewModelExportNoteCompletedMBCaption"] as string,
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                string[,] data = new string[4, 2]
                    {
                    { System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteTitleHeader"] as string, noteTitle },
                    { System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteBodyHeader"] as string, noteBody },
                    { System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNotePriorityHeader"] as string, notePriority },
                    { System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteCompletedHeader"] as string, noteCompleted}
                    };
                if (exportOption.Equals("CSV"))
                {
                    // User can save the CSV file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int longitud = data.GetLength(0);

                        StringBuilder csvContenido = new StringBuilder();

                        for (int i = 0; i < longitud; i++)
                        {
                            csvContenido.AppendLine(string.Join(";", data[i, 0], data[i, 1]));
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString(), Encoding.UTF8);
                        // Alert file saved
                        System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteCompletedMBText"] as string,
                            System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteCompletedMBCaption"] as string,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        StringBuilder csvContenido = new StringBuilder();

                        for (int i = 0; i < longitud; i++)
                        {
                            csvContenido.AppendLine(string.Join(": ", data[i, 0], data[i, 1]));
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContenido.ToString());
                        // Alert file saved
                        System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteCompletedMBText"] as string,
                             System.Windows.Application.Current.Resources["VA_HomeViewViewModelExportNoteCompletedMBCaption"] as string,
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void createAndShowNotification(string title, string message)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                // Alert bug: explorer.exe can get stuck with the bin folder.
                System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewViewModelNotificationMBWarningText"] as string,
                    System.Windows.Application.Current.Resources["HomeViewViewModelNotificationMBWarningCaption"] as string,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                // Form to introduce date and time
                Form prompt = new Form()
                {
                    Width = 700,
                    Height = 300,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = System.Windows.Application.Current.Resources["HomeViewViewModelNotificationFormText"] as string,
                    StartPosition = FormStartPosition.CenterScreen,
                    Padding = new Padding(15)
                };
                Label textLabel = new Label()
                {
                    Dock = DockStyle.Top,
                    Height = 120,
                    Text = System.Windows.Application.Current.Resources["HomeViewViewModelNotificationLabelText"] as string,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                TextBox textBox = new TextBox() { Dock = DockStyle.Top, Margin = new Padding(0, 10, 0, 10) };
                Button confirmation = new Button() { Text = "Ok", Dock = DockStyle.Bottom, Width = 100, DialogResult = DialogResult.OK, Margin = new Padding(0, 10, 0, 0) };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                DialogResult result;
                DateTime dateTime = DateTime.Now;
                do
                {
                    result = prompt.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string date = textBox.Text;
                        if (!DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTime))
                        {
                            System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewViewModelNotificationMBErrorFormatText"] as string,
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        if (dateTime <= DateTime.Now)
                        {
                            System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewViewModelNotificationMBErrorOldTimeText"] as string,
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        // Calculate the seconds from now to the date and time entered
                        double seconds = (dateTime - DateTime.Now).TotalSeconds;
                        // Create notification
                        new ToastContentBuilder()
                            .AddArgument("action", System.Windows.Application.Current.Resources["HomeViewViewModelNotificationToastArgumentValue"] as string)
                            .AddText(title)
                            .AddText(message)
                            .Schedule(DateTime.Now.AddSeconds(seconds), toast =>
                            {
                                toast.Tag = title;
                                toast.Group = System.Windows.Application.Current.Resources["HomeViewViewModelNotificationToastGroup"] as string;
                            });
                    }
                } while (result == DialogResult.OK && (dateTime <= DateTime.Now || !DateTime.TryParseExact(textBox.Text, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTime)));


            }
            else if (language.Equals("en"))
            {
                // Alert bug: explorer.exe can get stuck with the bin folder.
                System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewViewModelNotificationMBWarningText"] as string,
                                       System.Windows.Application.Current.Resources["EN_HomeViewViewModelNotificationMBWarningCaption"] as string,
                                                          MessageBoxButton.OK, MessageBoxImage.Warning);
                // Form to introduce date and time
                Form prompt = new Form()
                {
                    Width = 700,
                    Height = 300,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = System.Windows.Application.Current.Resources["EN_HomeViewViewModelNotificationFormText"] as string,
                    StartPosition = FormStartPosition.CenterScreen,
                    Padding = new Padding(15)
                };
                Label textLabel = new Label()
                {
                    Dock = DockStyle.Top,
                    Height = 120,
                    Text = System.Windows.Application.Current.Resources["EN_HomeViewViewModelNotificationLabelText"] as string,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                TextBox textBox = new TextBox() { Dock = DockStyle.Top, Margin = new Padding(0, 10, 0, 10) };
                Button confirmation = new Button() { Text = "Ok", Dock = DockStyle.Bottom, Width = 100, DialogResult = DialogResult.OK, Margin = new Padding(0, 10, 0, 0) };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                DialogResult result;
                DateTime dateTime = DateTime.Now;
                do
                {
                    result = prompt.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string date = textBox.Text;
                        if (!DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTime))
                        {
                            System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewViewModelNotificationMBErrorFormatText"] as string,
                                                               "Error",
                                                                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        if (dateTime <= DateTime.Now)
                        {
                            System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewViewModelNotificationMBErrorOldTimeText"] as string,
                                                               "Error",
                                                                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        // Calculate the seconds from now to the date and time entered
                        double seconds = (dateTime - DateTime.Now).TotalSeconds;
                        // Create notification
                        new ToastContentBuilder()
                            .AddArgument("action", System.Windows.Application.Current.Resources["HomeViewViewModelNotificationToastArgumentValue"] as string)
                            .AddText(title)
                            .AddText(message)
                            .Schedule(DateTime.Now.AddSeconds(seconds), toast =>
                            {
                                toast.Tag = title;
                                toast.Group = System.Windows.Application.Current.Resources["HomeViewViewModelNotificationToastGroup"] as string;
                            });

                    }
                } while (result == DialogResult.OK && (dateTime <= DateTime.Now || !DateTime.TryParseExact(textBox.Text, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTime)));
            }
            else
            {
                // Alert bug: explorer.exe can get stuck with the bin folder.
                System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewViewModelNotificationMBWarningText"] as string,
                                       System.Windows.Application.Current.Resources["VA_HomeViewViewModelNotificationMBWarningCaption"] as string,
                                                          MessageBoxButton.OK, MessageBoxImage.Warning);
                // Form to introduce date and time
                Form prompt = new Form()
                {
                    Width = 700,
                    Height = 300,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = System.Windows.Application.Current.Resources["VA_HomeViewViewModelNotificationFormText"] as string,
                    StartPosition = FormStartPosition.CenterScreen,
                    Padding = new Padding(15)
                };
                Label textLabel = new Label()
                {
                    Dock = DockStyle.Top,
                    Height = 120,
                    Text = System.Windows.Application.Current.Resources["VA_HomeViewViewModelNotificationLabelText"] as string,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                TextBox textBox = new TextBox() { Dock = DockStyle.Top, Margin = new Padding(0, 10, 0, 10) };
                Button confirmation = new Button() { Text = "Ok", Dock = DockStyle.Bottom, Width = 100, DialogResult = DialogResult.OK, Margin = new Padding(0, 10, 0, 0) };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                DialogResult result;
                DateTime dateTime = DateTime.Now;
                do
                {
                    result = prompt.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string date = textBox.Text;
                        if (!DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTime))
                        {
                            System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewViewModelNotificationMBErrorFormatText"] as string,
                                                               "Error",
                                                                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        if (dateTime <= DateTime.Now)
                        {
                            System.Windows.Forms.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewViewModelNotificationMBErrorOldTimeText"] as string,
                                                               "Error",
                                                                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        // Calculate the seconds from now to the date and time entered
                        double seconds = (dateTime - DateTime.Now).TotalSeconds;
                        // Create notification
                        new ToastContentBuilder()
                            .AddArgument("action", System.Windows.Application.Current.Resources["HomeViewViewModelNotificationToastArgumentValue"] as string)
                            .AddText(title)
                            .AddText(message)
                            .Schedule(DateTime.Now.AddSeconds(seconds), toast =>
                            {
                                toast.Tag = title;
                                toast.Group = System.Windows.Application.Current.Resources["HomeViewViewModelNotificationToastGroup"] as string;
                            });

                    }
                } while (result == DialogResult.OK && (dateTime <= DateTime.Now || !DateTime.TryParseExact(textBox.Text, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out dateTime)));
            }
        }
    }
}
