using ReadyTasks.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ReadyTasks.Views;
using System.Windows;
using System.Diagnostics;
using System.IO;

namespace ReadyTasks.Repositories
{
    class NoteRepository : RepositoryBase, INoteRepository
    {
        public int getAllNotesLowPriorityCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes] WHERE priority='Low' or priority='Baixa' or priority = 'Baja'";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public int getAllNotesMediumPriorityCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes] WHERE priority='Medium' or priority='Media' or priority = 'Mitjana'";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public int getAllNotesHighPriorityCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes] WHERE priority='High' or priority='Alta'";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public int getAllNotesUncompletedCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes] WHERE completed='no'";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public int getAllNotesCompletedCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes] WHERE completed='yes'";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public int getAllNotesCount()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes]";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public List<NoteModel> obtainNotes(int id_user)
        {
            List<NoteModel> notes = new List<NoteModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Notes] WHERE id_users=@id_user";
                command.Parameters.Add("@id_user", SqlDbType.NVarChar).Value = id_user;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NoteModel note = new NoteModel
                        {
                            id = Convert.ToInt32(reader["id"]),
                            id_users = Convert.ToInt32(reader["id_users"]),
                            title = reader["title"].ToString(),
                            body = reader["body"].ToString(),
                            priority = reader["priority"].ToString(),
                            completed = reader["completed"].ToString()
                        };
                        notes.Add(note);
                    }
                }
            }
            return notes;
        }

        public void addNoteToUser(NoteModel note, int id_user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                string language = File.ReadAllText(@"./Language.txt");
                // No repeted notes
                command.CommandText = "SELECT * FROM [Notes] WHERE id_users=@id_user AND body=@body";
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                command.Parameters.Add("@body", SqlDbType.NVarChar).Value = note.body;
                using (SqlDataReader reader = command.ExecuteReader())
                {


                    if (reader.Read())
                    {

                        if (language.Equals("es"))
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBErrorText"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            command.Parameters.Clear();
                            return;
                        }
                        else if (language.Equals("en"))
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBErrorText"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            command.Parameters.Clear();
                            return;
                        }
                        else
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBErrorText"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            command.Parameters.Clear();
                            return;
                        }

                    }
                }
                // Obtain ID of the last note
                command.CommandText = "SELECT TOP 1 id FROM [Notes] ORDER BY id DESC";
                command.ExecuteNonQuery();
                int id = Convert.ToInt32(command.ExecuteScalar());
                // Insert the new note
                command.CommandText = "INSERT INTO [Notes] (id, id_users, title, body, priority, completed) VALUES (@id, @id_users, @title, @body2, @priority, @completed)";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id + 1;
                command.Parameters.Add("@id_users", SqlDbType.Int).Value = id_user;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = note.title;
                command.Parameters.Add("@body2", SqlDbType.NVarChar).Value = note.body;
                command.Parameters.Add("@priority", SqlDbType.NVarChar).Value = note.priority;
                command.Parameters.Add("@completed", SqlDbType.NVarChar).Value = note.completed;
                command.ExecuteNonQuery();
                // Alert
                if (language.Equals("es"))
                {
                    MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBTextOK"] as string,
                    System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (language.Equals("en"))
                {
                    MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBTextOK"] as string,
                    System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBTextOK"] as string,
                    System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }


            }
        }

        public bool findNote(NoteModel note, int id_user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                // Search the note in the DB
                command.CommandText = "SELECT * FROM [Notes] WHERE id_users=@id_user AND body=@body AND title=@title AND priority=priority AND completed=@completed";
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                command.Parameters.Add("@body", SqlDbType.NVarChar).Value = note.body;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = note.title;
                command.Parameters.Add("@priority", SqlDbType.NVarChar).Value = note.priority;
                command.Parameters.Add("@completed", SqlDbType.NVarChar).Value = note.completed;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
        public bool editNote(NoteModel note, int id_user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                string language = File.ReadAllText(@"./Language.txt");
                connection.Open();
                command.Connection = connection;

                // Search the note in the DB
                command.CommandText = "SELECT * FROM [Notes] WHERE id_users=@id_user AND body=@body AND title=@title AND priority=@priority";
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                command.Parameters.Add("@body", SqlDbType.NVarChar).Value = note.body;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = note.title;
                command.Parameters.Add("@priority", SqlDbType.NVarChar).Value = note.priority;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (language.Equals("es"))
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBErrorText"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                        else if (language.Equals("en"))
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBErrorText"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                        else
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBErrorText"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }

                    }
                    else
                    {
                        using (var connection2 = GetConnection())
                        using (var updateCommand = new SqlCommand())
                        {
                            connection2.Open();
                            updateCommand.Connection = connection2;

                            // Update the note
                            updateCommand.CommandText = "UPDATE [Notes] SET title=@title, body=@body, priority=@priority WHERE id_users=@id_user AND id=@id_note";
                            updateCommand.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                            updateCommand.Parameters.Add("@id_note", SqlDbType.Int).Value = note.id;
                            updateCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = note.title;
                            updateCommand.Parameters.Add("@body", SqlDbType.NVarChar).Value = note.body;
                            updateCommand.Parameters.Add("@priority", SqlDbType.NVarChar).Value = note.priority;

                            try
                            {
                                if (language.Equals("es"))
                                {
                                    updateCommand.ExecuteNonQuery();
                                    MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextOK"] as string,
                                       System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                                    return true;
                                }
                                else if (language.Equals("en"))
                                {
                                    updateCommand.ExecuteNonQuery();
                                    MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextOK"] as string,
                                       System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                                    return true;
                                }
                                else
                                {
                                    updateCommand.ExecuteNonQuery();
                                    MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryEditNoteToUserMBTextOK"] as string,
                                       System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                                    return true;
                                }

                            }
                            catch (Exception e)
                            {
                                if (language.Equals("es"))
                                {
                                    MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                                    "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                                else if (language.Equals("en"))
                                {
                                    MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                                    "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                                else
                                {
                                    MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                                    "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }

                            }
                        }
                    }
                }
            }
        }
        public bool deleteNote(int noteId, int id_user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                string language = File.ReadAllText(@"./Language.txt");
                // Delete the note
                command.CommandText = "DELETE FROM [Notes] WHERE id=@id_note AND id_users=@id_user";
                command.Parameters.Add("@id_note", SqlDbType.Int).Value = noteId;
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                try
                {
                    if (language.Equals("es"))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryDeleteNoteToUserMBTextOK"] as string,
                            System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }
                    else if (language.Equals("en"))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryDeleteNoteToUserMBTextOK"] as string,
                            System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }
                    else
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryDeleteNoteToUserMBTextOK"] as string,
                            System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }

                }
                catch (Exception e)
                {
                    if (language.Equals("es"))
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (language.Equals("en"))
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                }
            }
        }

        public bool markAsCompleted(int noteId, int id_user, string isCompleted)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                string language = File.ReadAllText(@"./Language.txt");
                connection.Open();
                command.Connection = connection;

                if (isCompleted.Equals("no"))
                {
                    // Mark the note as completed
                    command.CommandText = "UPDATE [Notes] SET completed='yes' WHERE id=@id_note AND id_users=@id_user";
                    command.Parameters.Add("@id_note", SqlDbType.Int).Value = noteId;
                    command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                    try
                    {
                        if (language.Equals("es"))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryMarkCompletedNoteToUserMBTextOK"] as string,
                                System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                        else if (language.Equals("en"))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryMarkCompletedNoteToUserMBTextOK"] as string,
                                System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                        else
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryMarkCompletedNoteToUserMBTextOK"] as string,
                                System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }

                    }
                    catch (Exception e)
                    {
                        if (language.Equals("es"))
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                        else if (language.Equals("en"))
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                        else
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                            "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }

                    }
                }
                else
                {
                    // Mark the note as no completed
                    command.CommandText = "UPDATE [Notes] SET completed='no' WHERE id=@id_note AND id_users=@id_user";
                    command.Parameters.Add("@id_note", SqlDbType.Int).Value = noteId;
                    command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                }
                try
                {
                    if (language.Equals("es"))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryMarkUncompletedNoteToUserMBTextOK"] as string,
                            System.Windows.Application.Current.Resources["NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }
                    else if (language.Equals("en"))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryMarkUncompletedNoteToUserMBTextOK"] as string,
                            System.Windows.Application.Current.Resources["EN_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }
                    else
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryMarkUncompletedNoteToUserMBTextOK"] as string,
                            System.Windows.Application.Current.Resources["VA_NoteRepositoryAddNoteToUserMBTextCaption"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }

                }
                catch (Exception e)
                {
                    if (language.Equals("es"))
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else if (language.Equals("en"))
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                }
            }
        }

        public bool deleteAllNotes(int id_user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                string language = File.ReadAllText(@"./Language.txt");
                connection.Open();
                command.Connection = connection;

                // Delete all notes
                command.CommandText = "DELETE FROM [Notes] WHERE id_users=@id_user";
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    if (language.Equals("es"))
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    } else if (language.Equals("en")) {
                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    } else
                    {
                        MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    
                }

            }
        }

        public int obtainNotesCount(int id_user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM [Notes] WHERE id_users=@id_user";
                command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public List<string> obtainNoteIDNote(int idNote)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Notes] WHERE id=@id_note";
                command.Parameters.Add("@id_note", SqlDbType.Int).Value = idNote;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        List<string> noteData = new List<string>();
                        noteData.Add(reader["id"].ToString());
                        noteData.Add(reader["id_users"].ToString());
                        noteData.Add(reader["title"].ToString());
                        noteData.Add(reader["body"].ToString());
                        noteData.Add(reader["priority"].ToString());
                        noteData.Add(reader["completed"].ToString());
                        return noteData;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public (List<string>, List<string>) obtainNotesByTitleAndContent(string title, string content)
        {
            List<string> titles = new List<string>();
            List<string> bodies = new List<string>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Notes] WHERE title LIKE '%' + @title + '%'";
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        titles.Add(reader["title"].ToString());
                        titles.Add(reader["body"].ToString());
                        titles.Add(reader["id"].ToString());
                        titles.Add(reader["id_users"].ToString());
                        titles.Add(reader["priority"].ToString());
                        titles.Add(reader["completed"].ToString());
                    }
                }

            }
            using (var connection2 = GetConnection())
            using (var updateCommand = new SqlCommand())
            {
                connection2.Open();
                updateCommand.Connection = connection2;
                updateCommand.CommandText = "SELECT * FROM [Notes] WHERE body LIKE '%' + @body + '%'";
                updateCommand.Parameters.Add("@body", SqlDbType.NVarChar).Value = content;
                using (SqlDataReader reader = updateCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bodies.Add(reader["title"].ToString());
                        bodies.Add(reader["body"].ToString());
                        bodies.Add(reader["id"].ToString());
                        bodies.Add(reader["id_users"].ToString());
                        bodies.Add(reader["priority"].ToString());
                        bodies.Add(reader["completed"].ToString());
                    }
                }
            }
            return (titles, bodies);
        }

        public (List<string>, List<string>) obtainNotesByTitleContentAndIdUser(string title, string content, int id_users)
        {
            List<string> titles = new List<string>();
            List<string> bodies = new List<string>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Notes] WHERE (title LIKE '%' + @title + '%') AND id_users = @id_users";
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("@id_users", SqlDbType.Int).Value = id_users;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        titles.Add(reader["title"].ToString());
                        titles.Add(reader["body"].ToString());
                        titles.Add(reader["id"].ToString());
                        titles.Add(reader["id_users"].ToString());
                        titles.Add(reader["priority"].ToString());
                        titles.Add(reader["completed"].ToString());
                    }
                }

            }
            using (var connection2 = GetConnection())
            using (var updateCommand = new SqlCommand())
            {
                connection2.Open();
                updateCommand.Connection = connection2;
                updateCommand.CommandText = "SELECT * FROM [Notes] WHERE (body LIKE '%' + @body + '%') AND id_users = @id_users";
                updateCommand.Parameters.Add("@body", SqlDbType.NVarChar).Value = content;
                updateCommand.Parameters.Add("@id_users", SqlDbType.Int).Value = id_users;
                using (SqlDataReader reader = updateCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bodies.Add(reader["title"].ToString());
                        bodies.Add(reader["body"].ToString());
                        bodies.Add(reader["id"].ToString());
                        bodies.Add(reader["id_users"].ToString());
                        bodies.Add(reader["priority"].ToString());
                        bodies.Add(reader["completed"].ToString());
                    }
                }
            }
            return (titles, bodies);
        }

        public (List<string>, List<string>) obtainNotesByTitleContentAndIdNote(string title, string content, int id_note)
        {
            List<string> titles = new List<string>();
            List<string> bodies = new List<string>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Notes] WHERE (title LIKE '%' + @title + '%') AND id = @id_note";
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("@id_note", SqlDbType.Int).Value = id_note;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        titles.Add(reader["title"].ToString());
                        titles.Add(reader["body"].ToString());
                        titles.Add(reader["id"].ToString());
                        titles.Add(reader["id_users"].ToString());
                        titles.Add(reader["priority"].ToString());
                        titles.Add(reader["completed"].ToString());
                    }
                }

            }
            using (var connection2 = GetConnection())
            using (var updateCommand = new SqlCommand())
            {
                connection2.Open();
                updateCommand.Connection = connection2;
                updateCommand.CommandText = "SELECT * FROM [Notes] WHERE (body LIKE '%' + @body + '%') AND id = @id_note";
                updateCommand.Parameters.Add("@body", SqlDbType.NVarChar).Value = content;
                updateCommand.Parameters.Add("@id_note", SqlDbType.Int).Value = id_note;
                using (SqlDataReader reader = updateCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bodies.Add(reader["title"].ToString());
                        bodies.Add(reader["body"].ToString());
                        bodies.Add(reader["id"].ToString());
                        bodies.Add(reader["id_users"].ToString());
                        bodies.Add(reader["priority"].ToString());
                        bodies.Add(reader["completed"].ToString());
                    }
                }
            }
            return (titles, bodies);
        }

        public bool deleteAllNotesOnly(int id_user)
        {
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    string language = File.ReadAllText(@"./Language.txt");
                    connection.Open();
                    command.Connection = connection;
                    // Comprobe if has notes
                    command.CommandText = "SELECT * FROM [Notes] WHERE id_users=@id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            if (language.Equals("es")) {
                                MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryDeleteAllNotesOnlyDontNotes"] as string,
                                "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            } else if (language.Equals("en"))
                            {
                                MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryDeleteAllNotesOnlyDontNotes"] as string,
                                "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            } else
                            {
                                MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryDeleteAllNotesOnlyDontNotes"] as string,
                                "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            
                        }
                        else
                        {
                            // Delete all notes
                            using (var connection2 = GetConnection())
                            using (var command2 = new SqlCommand())
                            {
                                connection2.Open();
                                command2.Connection = connection2;

                                // Delete all notes
                                command2.CommandText = "DELETE FROM [Notes] WHERE id_users=@id_user";
                                command2.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                                try
                                {
                                    command2.ExecuteNonQuery();
                                    return true;
                                }
                                catch (Exception e)
                                {
                                    if (language.Equals("es")) {
                                        MessageBox.Show(System.Windows.Application.Current.Resources["NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                                        "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                                        return false;
                                    } else if (language.Equals("en"))
                                    {
                                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                                        "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                                        return false;
                                    }
                                    else {
                                        MessageBox.Show(System.Windows.Application.Current.Resources["VA_NoteRepositoryEditNoteToUserMBTextERROR"] as string,
                                        "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                                        return false;
                                    }
                                    
                                }

                            }
                        }


                    }
                }
            }
        }
    }
}



