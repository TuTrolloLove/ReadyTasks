
using MaterialDesignThemes.Wpf;
using ReadyTasks.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ReadyTasks.Views
{

    public partial class AdminView : UserControl
    {
        private AdminViewModel _adminViewModel;

        public AdminView()
        {
            InitializeComponent();
            _adminViewModel = new AdminViewModel();
            translate();
            setData();
        }

        private void FindUserData_Click(object sender, RoutedEventArgs e)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                if (string.IsNullOrEmpty(tbEmailOrID.Text))
                {
                    MessageBox.Show(Application.Current.Resources["AdminViewCSFindUserDataClickTextBoxEmpty"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    List<String> user = _adminViewModel.findUser(tbEmailOrID.Text);

                    if (user.Count == 0)
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSDontResultsFound"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        bool isAdmin = _adminViewModel.isAdmin(int.Parse(user[0]));
                        int notesCount = _adminViewModel.countNoutes(int.Parse(user[0]));
                        // Show results
                        rUserData.Visibility = Visibility.Visible;
                        tbID.Text = "ID: " + user[0];
                        tbEmail.Text = "Email: " + user[1];
                        tbfromGoogle.Text = Application.Current.Resources["AdminViewCSTbFromGoogleText"] as string + " " + user[2];
                        tbCountNotes.Text = Application.Current.Resources["AdminViewCSTbNoteCount"] as string + " " + notesCount;
                        tbIsAdmin.Text = Application.Current.Resources["AdminViewCSTbIsAdmin"] as string + " " + (isAdmin ? "Sí" : "No");
                    }
                }
            }
            else if (language.Equals("en"))
            {
                if (string.IsNullOrEmpty(tbEmailOrID.Text))
                {
                    MessageBox.Show(Application.Current.Resources["EN_AdminViewCSFindUserDataClickTextBoxEmpty"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    List<String> user = _adminViewModel.findUser(tbEmailOrID.Text);

                    if (user.Count == 0)
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSDontResultsFound"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        bool isAdmin = _adminViewModel.isAdmin(int.Parse(user[0]));
                        int notesCount = _adminViewModel.countNoutes(int.Parse(user[0]));
                        // Show results
                        rUserData.Visibility = Visibility.Visible;
                        tbID.Text = "ID: " + user[0];
                        tbEmail.Text = "Email: " + user[1];
                        tbfromGoogle.Text = Application.Current.Resources["EN_AdminViewCSTbFromGoogleText"] as string + " " + user[2];
                        tbCountNotes.Text = Application.Current.Resources["EN_AdminViewCSTbNoteCount"] as string + " " + notesCount;
                        tbIsAdmin.Text = Application.Current.Resources["EN_AdminViewCSTbIsAdmin"] as string + " " + (isAdmin ? "Yes" : "No");
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tbEmailOrID.Text))
                {
                    MessageBox.Show(Application.Current.Resources["VA_AdminViewCSFindUserDataClickTextBoxEmpty"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    List<String> user = _adminViewModel.findUser(tbEmailOrID.Text);

                    if (user.Count == 0)
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSDontResultsFound"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        bool isAdmin = _adminViewModel.isAdmin(int.Parse(user[0]));
                        int notesCount = _adminViewModel.countNoutes(int.Parse(user[0]));
                        // Show results
                        rUserData.Visibility = Visibility.Visible;
                        tbID.Text = "ID: " + user[0];
                        tbEmail.Text = "Email: " + user[1];
                        tbfromGoogle.Text = Application.Current.Resources["VA_AdminViewCSTbFromGoogleText"] as string + " " + user[2];
                        tbCountNotes.Text = Application.Current.Resources["VA_AdminViewCSTbNoteCount"] as string + " " + notesCount;
                        tbIsAdmin.Text = Application.Current.Resources["VA_AdminViewCSTbIsAdmin"] as string + " " + (isAdmin ? "Sí" : "No");
                    }
                }
            }

        }


        private void btnFindNotes_Click(object sender, RoutedEventArgs e)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                // If ID User is selected
                if (cbIDOrNoteID.SelectedIndex == 0)
                {
                    // And the field isn't empty
                    if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id))
                    {
                        loadNotes(_adminViewModel.obtainNotes(id));
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSErrorMessageNotUserID"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                } // If ID Note is selected
                else
                {
                    // And the field isn't empty
                    if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id))
                    {
                        loadNotesIDNote(_adminViewModel.obtainNoteIDNote(id));
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSErrorMessageNotNoteID"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }
            else if (language.Equals("en"))
            {
                // If ID User is selected
                if (cbIDOrNoteID.SelectedIndex == 0)
                {
                    // And the field isn't empty
                    if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id))
                    {
                        loadNotes(_adminViewModel.obtainNotes(id));
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorMessageNotUserID"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                } // If ID Note is selected
                else
                {
                    // And the field isn't empty
                    if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id))
                    {
                        loadNotesIDNote(_adminViewModel.obtainNoteIDNote(id));
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorMessageNotNoteID"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                // If ID User is selected
                if (cbIDOrNoteID.SelectedIndex == 0)
                {
                    // And the field isn't empty
                    if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id))
                    {
                        loadNotes(_adminViewModel.obtainNotes(id));
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorMessageNotUserID"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                } // If ID Note is selected
                else
                {
                    // And the field isn't empty
                    if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id))
                    {
                        loadNotesIDNote(_adminViewModel.obtainNoteIDNote(id));
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorMessageNotNoteID"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ButtonCombined_Click(object sender, RoutedEventArgs e)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                // If ID User is selected
                if (cbIDOrNoteID.SelectedIndex == 0)
                {
                    // If the field of ID or Note ID is empty or the field of title or content is empty
                    if (string.IsNullOrEmpty(tbIDOrNoteID.Text) || string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSErrorMessageNotAllFields"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    } // If the field of ID or Note ID is not empty and the field of title or content is not empty
                    else if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id2) && !string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        List<String> titles = _adminViewModel.obtainNoteByTitleContentAndId(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item1;
                        List<String> contents = _adminViewModel.obtainNoteByTitleContentAndId(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item2;
                        loadNotesTitlesAndBodies(titles, contents);
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSErrorMessageOnlyNumbersOnFirstField"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                } // If ID Note is selected
                else
                {
                    // If the field of ID or Note ID is empty or the field of title or content is empty
                    if (string.IsNullOrEmpty(tbIDOrNoteID.Text) || string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSErrorMessageNotAllFields2"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    } // If the field of ID or Note ID is not empty and the field of title or content is not empty
                    else if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id2) && !string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        List<String> titles = _adminViewModel.obtainNoteByTitleContentAndIdNote(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item1;
                        List<String> contents = _adminViewModel.obtainNoteByTitleContentAndIdNote(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item2;
                        loadNotesTitlesAndBodies(titles, contents);
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["AdminViewCSErrorMessageOnlyNumbersOnFirstField2"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else if (language.Equals("en"))
            {
                if (cbIDOrNoteID.SelectedIndex == 0)
                {

                    if (string.IsNullOrEmpty(tbIDOrNoteID.Text) || string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorMessageNotAllFields"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id2) && !string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        List<String> titles = _adminViewModel.obtainNoteByTitleContentAndId(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item1;
                        List<String> contents = _adminViewModel.obtainNoteByTitleContentAndId(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item2;
                        loadNotesTitlesAndBodies(titles, contents);
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorMessageOnlyNumbersOnFirstField"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {

                    if (string.IsNullOrEmpty(tbIDOrNoteID.Text) || string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorMessageNotAllFields2"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id2) && !string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        List<String> titles = _adminViewModel.obtainNoteByTitleContentAndIdNote(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item1;
                        List<String> contents = _adminViewModel.obtainNoteByTitleContentAndIdNote(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item2;
                        loadNotesTitlesAndBodies(titles, contents);
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorMessageOnlyNumbersOnFirstField2"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                if (cbIDOrNoteID.SelectedIndex == 0)
                {

                    if (string.IsNullOrEmpty(tbIDOrNoteID.Text) || string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorMessageNotAllFields"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id2) && !string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        List<String> titles = _adminViewModel.obtainNoteByTitleContentAndId(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item1;
                        List<String> contents = _adminViewModel.obtainNoteByTitleContentAndId(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item2;
                        loadNotesTitlesAndBodies(titles, contents);
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorMessageOnlyNumbersOnFirstField"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {

                    if (string.IsNullOrEmpty(tbIDOrNoteID.Text) || string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorMessageNotAllFields2"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (!string.IsNullOrEmpty(tbIDOrNoteID.Text) && int.TryParse(tbIDOrNoteID.Text, out int id2) && !string.IsNullOrEmpty(tbTitleOrContent.Text))
                    {
                        List<String> titles = _adminViewModel.obtainNoteByTitleContentAndIdNote(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item1;
                        List<String> contents = _adminViewModel.obtainNoteByTitleContentAndIdNote(tbTitleOrContent.Text, tbTitleOrContent.Text, id2).Item2;
                        loadNotesTitlesAndBodies(titles, contents);
                    }
                    else
                    {
                        MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorMessageOnlyNumbersOnFirstField2"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnFindNotesTitleOrContent_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitleOrContent.Text.Equals(""))
            {
                string language = File.ReadAllText(@"./Language.txt");
                if (language.Equals("es"))
                {
                    MessageBox.Show(Application.Current.Resources["AdminViewCSErrorDontContent"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (language.Equals("en"))
                {
                    MessageBox.Show(Application.Current.Resources["EN_AdminViewCSErrorDontContent"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["VA_AdminViewCSErrorDontContent"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return;
            }
            else
            {
                List<String> titles = _adminViewModel.obtainNoteByTitleAndContent(tbTitleOrContent.Text, tbTitleOrContent.Text).Item1;
                List<String> contents = _adminViewModel.obtainNoteByTitleAndContent(tbTitleOrContent.Text, tbTitleOrContent.Text).Item2;
                for (int i = 0; i < titles.Count; i++)
                {
                    Debug.WriteLine("Título: " + titles[i]);
                }
                for (int i = 0; i < contents.Count; i++)
                {
                    Debug.WriteLine("Contenido: " + contents[i]);
                }
                loadNotesTitlesAndBodies(titles, contents);
            }
        }


        private void Button_Click_Report(object sender, RoutedEventArgs e)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                MessageBox.Show(Application.Current.Resources["AdminViewCSReport"] as string,
                    Application.Current.Resources["AdminViewCSReportCaption"] as string,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (language.Equals("en"))
            {
                MessageBox.Show(Application.Current.Resources["EN_AdminViewCSReport"] as string,
                                   Application.Current.Resources["EN_AdminViewCSReportCaption"] as string,
                                                      MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(Application.Current.Resources["VA_AdminViewCSReport"] as string,
                                       Application.Current.Resources["VA_AdminViewCSReportCaption"] as string,
                                                          MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void loadNotes(List<String> notes)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (notes.Count == 0)
            {
                if (language.Equals("es")) { MessageBox.Show(Application.Current.Resources["AdminViewCSNotNotesFound"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                else if (language.Equals("en")) { MessageBox.Show(Application.Current.Resources["EN_AdminViewCSNotNotesFound"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                else { MessageBox.Show(Application.Current.Resources["VA_AdminViewCSNotNotesFound"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                return;
            }
            // Create a Grid
            Grid grid = new Grid();
            // Create a ScrollViewer
            ScrollViewer scrollViewerNotes = new ScrollViewer();
            // Create a main StackPanel
            StackPanel mainStackPanel = new StackPanel();
            mainStackPanel.Orientation = Orientation.Vertical;
            // Create a WrapPanel
            WrapPanel wrapPanelTop = new WrapPanel();
            wrapPanelTop.Orientation = Orientation.Horizontal;
            wrapPanelTop.ItemWidth = 200;
            wrapPanelTop.Margin = new Thickness(0, 10, 0, 0);


            // Create a TextBlock
            TextBlock tbUserIDOrNoteID = new TextBlock()
            {
                Margin = new Thickness(20, 13, 632, 391),
                Text = "ID de usuario o ID de nota",
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbUserIDOrNoteID);

            // Create a ComboBox
            ComboBox cbUserIDOrNoteID = new ComboBox()
            {
                Name = "cbIDOrNoteID",
                Width = 120,
                Margin = new Thickness(167, 11, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                SelectedIndex = 0,
                Items =
            {
                "ID de usuario",
                "ID de nota"
            }
            };
            wrapPanelTop.Children.Add(cbUserIDOrNoteID);

            // Create a TextBox
            TextBox tbIDOrNoteID = new TextBox()
            {
                Name = "tbIDOrNoteID",
                Width = 66,
                Margin = new Thickness(292, 13, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbIDOrNoteID);

            // Create a TextBlock
            TextBlock tbTitleOrContent = new TextBlock()
            {
                Margin = new Thickness(383, 14, 309, 389),
                Text = "Título o contenido",
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbTitleOrContent);

            // Create a TextBox
            TextBox tboxTitleOrContent = new TextBox()
            {
                Name = "txTitleOrContent",
                Width = 231,
                Margin = new Thickness(490, 14, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tboxTitleOrContent);

            // Create a Button
            Button btnFindNotes = new Button()
            {
                Name = "btnFindNotes",
                Width = 43,
                Height = 19,
                Margin = new Thickness(726, 13, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = "Buscar",
            };
            btnFindNotes.Click += btnFindNotes_Click;
            wrapPanelTop.Children.Add(btnFindNotes);

            // Add wrapPanelTop to mainStackPanel
            mainStackPanel.Children.Add(wrapPanelTop);

            // Create a WrapPanel to the notes
            WrapPanel wrapPanelNotes = new WrapPanel();
            wrapPanelNotes.Orientation = Orientation.Horizontal;
            wrapPanelNotes.ItemWidth = 200;
            wrapPanelNotes.Margin = new Thickness(0, 10, 0, 0);

            // Show the notes
            foreach (string note in notes)
            {
                Debug.WriteLine(note);
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;

                stackPanel.Visibility = Visibility.Visible;
                if (note.Contains("completed: yes"))
                {
                    stackPanel.Background = Brushes.Green;
                }
                else
                {
                    if (note.Contains("priority: Alta") || note.Contains("priority: High"))
                    {
                        stackPanel.Background = Brushes.Red;
                    }
                    else if (note.Contains("priority: Media") || note.Contains("priority: Medium") || note.Contains("priority: Mitjana"))
                    {
                        stackPanel.Background = Brushes.Orange;
                    }
                    else if (note.Contains("priority: Baja") || note.Contains("priority: Low") || note.Contains("priority: Baixa"))
                    {
                        stackPanel.Background = Brushes.White;
                    }
                }
                int startIndex = note.IndexOf("title:") + "title:".Length;
                int endIndex = note.IndexOf("body:");
                // TextBox for the title
                TextBlock tbTitle = new TextBlock()
                {

                    Text = note.Substring(startIndex, endIndex - startIndex).Trim(),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 186,
                };

                tbTitle.Height = 60;
                tbTitle.Width = 186;
                tbTitle.Margin = new Thickness(0, 0, 0, 5);
                tbTitle.HorizontalAlignment = HorizontalAlignment.Center;
                tbTitle.FontWeight = FontWeights.Bold;
                stackPanel.Children.Add(tbTitle);

                int startIndexBody = note.IndexOf("body:") + "body:".Length;
                int endIndexBody = note.IndexOf("priority:");

                // TextBox for the body
                TextBlock tbBody = new TextBlock()
                {
                    Text = note.Substring(startIndexBody, endIndexBody - startIndexBody).Trim(),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 186,
                };


                int startIndexPriority = note.IndexOf("priority:") + "priority:".Length;
                int endIndexPriority = note.IndexOf("completed:");


                // Create a ScrollViewer
                ScrollViewer scrollViewerBody = new ScrollViewer()
                {
                    Content = tbBody,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    MaxHeight = 340, // Set a maximum height
                    MinHeight = 340  // Set a minimum height
                };

                stackPanel.Children.Add(scrollViewerBody);

                // ID note
                int startIndexID = note.IndexOf("id:") + "id:".Length;
                int endIndexID = note.IndexOf("id_users:");

                if (language.Equals("es"))
                {
                    TextBlock tbIdNote = new TextBlock()
                    {

                        Text = Application.Current.Resources["AdminViewCSLoadNotesIdNote"] as string + " " + note.Substring(startIndexID, endIndexID - startIndexID).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbIdNote);
                }
                else if (language.Equals("en"))
                {
                    TextBlock tbIdNote = new TextBlock()
                    {

                        Text = Application.Current.Resources["EN_AdminViewCSLoadNotesIdNote"] as string + " " + note.Substring(startIndexID, endIndexID - startIndexID).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbIdNote);
                }
                else
                {
                    TextBlock tbIdNote = new TextBlock()
                    {

                        Text = Application.Current.Resources["VA_AdminViewCSLoadNotesIdNote"] as string + " " + note.Substring(startIndexID, endIndexID - startIndexID).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbIdNote);
                }



                // ID User
                int startIndexIDUser = note.IndexOf("id_users:") + "id_users:".Length;
                int endIndexIDUser = note.IndexOf("title:");
                if (language.Equals("es"))
                {
                    TextBlock tbIdUser = new TextBlock()
                    {
                        Text = Application.Current.Resources["AdminViewCSLoadNotesUserID"] as string + " " + note.Substring(startIndexIDUser, endIndexIDUser - startIndexIDUser).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbIdUser);
                }
                else if (language.Equals("en"))
                {
                    TextBlock tbIdUser = new TextBlock()
                    {
                        Text = Application.Current.Resources["EN_AdminViewCSLoadNotesUserID"] as string + " " + note.Substring(startIndexIDUser, endIndexIDUser - startIndexIDUser).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbIdUser);
                }
                else
                {
                    TextBlock tbIdUser = new TextBlock()
                    {
                        Text = Application.Current.Resources["VA_AdminViewCSLoadNotesUserID"] as string + " " + note.Substring(startIndexIDUser, endIndexIDUser - startIndexIDUser).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbIdUser);
                }


                // TextBox for the priority
                if (language.Equals("es"))
                {
                    TextBlock tbPriority = new TextBlock()
                    {
                        Text = Application.Current.Resources["AdminViewCSLoadNotesPriority"] as string + " " + note.Substring(startIndexPriority, endIndexPriority - startIndexPriority).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbPriority);
                }
                else if (language.Equals("en"))
                {
                    TextBlock tbPriority = new TextBlock()
                    {
                        Text = Application.Current.Resources["EN_AdminViewCSLoadNotesPriority"] as string + " " + note.Substring(startIndexPriority, endIndexPriority - startIndexPriority).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbPriority);
                }
                else
                {
                    TextBlock tbPriority = new TextBlock()
                    {
                        Text = Application.Current.Resources["VA_AdminViewCSLoadNotesPriority"] as string + " " + note.Substring(startIndexPriority, endIndexPriority - startIndexPriority).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbPriority);
                }


                if (language.Equals("es"))
                {// TextBox for completed
                    int startIndexCompleted = note.IndexOf("completed:") + "completed:".Length;
                    TextBlock tbCompleted = new TextBlock()
                    {
                        Text = Application.Current.Resources["AdminViewCSLoadNotesCompleted"] as string + " " + note.Substring(startIndexCompleted).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbCompleted);
                }
                else if (language.Equals("en"))
                {
                    int startIndexCompleted = note.IndexOf("completed:") + "completed:".Length;
                    TextBlock tbCompleted = new TextBlock()
                    {
                        Text = Application.Current.Resources["EN_AdminViewCSLoadNotesCompleted"] as string + " " + note.Substring(startIndexCompleted).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbCompleted);
                }
                else
                {
                    int startIndexCompleted = note.IndexOf("completed:") + "completed:".Length;
                    TextBlock tbCompleted = new TextBlock()
                    {
                        Text = Application.Current.Resources["VA_AdminViewCSLoadNotesCompleted"] as string + " " + note.Substring(startIndexCompleted).Trim(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                        Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                    };
                    stackPanel.Children.Add(tbCompleted);
                }



                // StackPanel for the buttons
                StackPanel stackPanelButtons = new StackPanel();
                stackPanelButtons.Orientation = Orientation.Horizontal;
                stackPanelButtons.HorizontalAlignment = HorizontalAlignment.Center;
                stackPanelButtons.VerticalAlignment = VerticalAlignment.Bottom; // Align the buttons at the bottom
                stackPanel.Children.Add(stackPanelButtons);

                // Not blue background when mouse is over the button
                // Create a ControlTemplate for the button
                ControlTemplate buttonTemplate = new ControlTemplate(typeof(System.Windows.Controls.Button));

                // Create a FrameworkElementFactory for the Border
                FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
                border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(System.Windows.Controls.Button.BackgroundProperty));

                // Create a FrameworkElementFactory for the ContentPresenter
                FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
                contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

                // Add the ContentPresenter to the Border
                border.AppendChild(contentPresenter);

                // Add the Border to the ControlTemplate
                buttonTemplate.VisualTree = border;

                // Create a Trigger for the mouse over
                Trigger mouseOverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
                mouseOverTrigger.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = Brushes.Transparent });

                // Button to report
                int idNoteInt = int.Parse(note.Substring(startIndexIDUser, endIndexIDUser - startIndexIDUser).Trim());
                System.Windows.Controls.Button btnReport = new System.Windows.Controls.Button();
                btnReport.Width = 25;
                btnReport.Height = 25;
                btnReport.Background = Brushes.Transparent;
                btnReport.BorderBrush = Brushes.Transparent;
                btnReport.Template = buttonTemplate;
                btnReport.Content = new PackIcon()
                {
                    Kind = PackIconKind.Report,
                    Width = 21,
                    Height = 21,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                btnReport.Click += Button_Click_Report;
                btnReport.Tag = idNoteInt;
                stackPanelButtons.Children.Add(btnReport);
                if (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange))
                {
                    tbTitle.Foreground = Brushes.White;
                    tbBody.Foreground = Brushes.White;
                    btnReport.Foreground = Brushes.White;

                }
                else
                {
                    tbTitle.Foreground = Brushes.Black;
                    tbBody.Foreground = Brushes.Black;
                    btnReport.Foreground = Brushes.Black;
                }

                wrapPanelNotes.Children.Add(stackPanel);
            }
            // Add wrapPanelNotes to scrollViewerNotes
            scrollViewerNotes.Content = wrapPanelNotes;
            // Add scrollViewerNotes to grid
            grid.Children.Add(scrollViewerNotes);

            this.Content = grid;
        }
        private void loadNotesIDNote(List<String> notes)
        {
            string language = File.ReadAllText(@"./Language.txt");
            // If notes are null
            if (notes == null)
            {
                if (language.Equals("es"))
                {
                    MessageBox.Show(Application.Current.Resources["AdminViewCSLoadNotesIdNoteDontFoundNotes"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (language.Equals("en"))
                {
                    MessageBox.Show(Application.Current.Resources["EN_AdminViewCSLoadNotesIdNoteDontFoundNotes"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["VA_AdminViewCSLoadNotesIdNoteDontFoundNotes"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            // Create a Grid
            Grid grid = new Grid();
            // Create a ScrollViewer
            ScrollViewer scrollViewerNotes = new ScrollViewer();
            // Create main StackPanel
            StackPanel mainStackPanel = new StackPanel();
            mainStackPanel.Orientation = Orientation.Vertical;
            // Create a WrapPanel
            WrapPanel wrapPanelTop = new WrapPanel();
            wrapPanelTop.Orientation = Orientation.Horizontal;
            wrapPanelTop.ItemWidth = 200; // Ajustar según el tamaño de las notas
            wrapPanelTop.Margin = new Thickness(0, 10, 0, 0);


            // Create a TextBlock
            TextBlock tbUserIDOrNoteID = new TextBlock()
            {
                Margin = new Thickness(20, 13, 632, 391),
                Text = "ID de usuario o ID de nota",
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbUserIDOrNoteID);

            // Create a ComboBox
            ComboBox cbUserIDOrNoteID = new ComboBox()
            {
                Name = "cbIDOrNoteID",
                Width = 120,
                Margin = new Thickness(167, 11, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                SelectedIndex = 0,
                Items =
            {
                "ID de usuario",
                "ID de nota"
            }
            };
            wrapPanelTop.Children.Add(cbUserIDOrNoteID);

            // Create a TextBox
            TextBox tbIDOrNoteID = new TextBox()
            {
                Name = "tbIDOrNoteID",
                Width = 66,
                Margin = new Thickness(292, 13, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbIDOrNoteID);

            // Create a TextBlock
            TextBlock tbTitleOrContent = new TextBlock()
            {
                Margin = new Thickness(383, 14, 309, 389),
                Text = "Título o contenido",
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbTitleOrContent);

            // Create a TextBox
            TextBox tboxTitleOrContent = new TextBox()
            {
                Name = "txTitleOrContent",
                Width = 231,
                Margin = new Thickness(490, 14, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tboxTitleOrContent);

            // Create a Button
            Button btnFindNotes = new Button()
            {
                Name = "btnFindNotes",
                Width = 43,
                Height = 19,
                Margin = new Thickness(726, 13, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = "Buscar",
            };
            btnFindNotes.Click += btnFindNotes_Click;
            wrapPanelTop.Children.Add(btnFindNotes);

            // Add wrapPanelTop to mainStackPanel
            mainStackPanel.Children.Add(wrapPanelTop);

            // Create a WrapPanel to the notes
            WrapPanel wrapPanelNotes = new WrapPanel();
            wrapPanelNotes.Orientation = Orientation.Horizontal;
            wrapPanelNotes.ItemWidth = 200;
            wrapPanelNotes.Margin = new Thickness(0, 10, 0, 0);

            // Show the notes
            for (int i = 0; i < 1; i++)
            {
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Vertical;

                    stackPanel.Visibility = Visibility.Visible;
                    if (notes[5].Contains("yes"))
                    {
                        stackPanel.Background = Brushes.Green;
                    }
                    else
                    {
                        if (notes[4].Contains("Alta") || notes[4].Contains("High"))
                        {
                            stackPanel.Background = Brushes.Red;
                        }
                        else if (notes[4].Contains("Media") || notes[4].Contains("Medium") || notes[4].Contains("Mitjana"))
                        {
                            stackPanel.Background = Brushes.Orange;
                        }
                        else if (notes[4].Contains("Baja") || notes[4].Contains("Low") || notes[4].Contains("Baixa"))
                        {
                            stackPanel.Background = Brushes.White;
                        }
                    }
                    Debug.WriteLine("Nota " + notes[i]);

                    // TextBox for the title
                    TextBlock tbTitle = new TextBlock()
                    {

                        Text = notes[2].ToString(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                    };

                    tbTitle.Height = 60;
                    tbTitle.Width = 186;
                    tbTitle.Margin = new Thickness(0, 0, 0, 5);
                    tbTitle.HorizontalAlignment = HorizontalAlignment.Center;
                    tbTitle.FontWeight = FontWeights.Bold;
                    stackPanel.Children.Add(tbTitle);

                    // TextBox for the body
                    TextBlock tbBody = new TextBlock()
                    {
                        Text = notes[3].ToString(),
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                    };

                    // Create a ScrollViewer
                    ScrollViewer scrollViewerBody = new ScrollViewer()
                    {
                        Content = tbBody,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        MaxHeight = 340, // Set a maximum height
                        MinHeight = 340  // Set a minimum height
                    };

                    stackPanel.Children.Add(scrollViewerBody);

                    // TextBox for the ID Note
                    if (language.Equals("es"))
                    {
                        TextBlock tbIdNote = new TextBlock()
                        {
                            Text = Application.Current.Resources["AdminViewCSLoadNotesIdNoteNoteID"] as string + " " + notes[0].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbIdNote);
                    }
                    else if (language.Equals("en"))
                    {
                        TextBlock tbIdNote = new TextBlock()
                        {
                            Text = Application.Current.Resources["EN_AdminViewCSLoadNotesIdNoteNoteID"] as string + " " + notes[0].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbIdNote);
                    }
                    else
                    {
                        TextBlock tbIdNote = new TextBlock()
                        {
                            Text = Application.Current.Resources["VA_AdminViewCSLoadNotesIdNoteNoteID"] as string + " " + notes[0].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbIdNote);
                    }

                    if (language.Equals("es"))
                    { // TextBox for the ID User
                        TextBlock tbIdUser = new TextBlock()
                        {
                            Text = Application.Current.Resources["AdminViewCSLoadNotesIdNoteUserID"] as string + " " + notes[1].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbIdUser);
                    }
                    else if (language.Equals("en"))
                    {
                        TextBlock tbIdUser = new TextBlock()
                        {
                            Text = Application.Current.Resources["EN_AdminViewCSLoadNotesIdNoteUserID"] as string + " " + notes[1].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbIdUser);
                    }
                    else
                    {
                        TextBlock tbIdUser = new TextBlock()
                        {
                            Text = Application.Current.Resources["VA_AdminViewCSLoadNotesIdNoteUserID"] as string + " " + notes[1].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbIdUser);
                    }

                    if (language.Equals("es"))
                    { // TextBox for the priority
                        TextBlock tbPriority = new TextBlock()
                        {
                            Text = Application.Current.Resources["AdminViewCSLoadNotesIdNotePriority"] as string + " " + notes[4].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbPriority);
                    }
                    else if (language.Equals("en"))
                    {
                        TextBlock tbPriority = new TextBlock()
                        {
                            Text = Application.Current.Resources["EN_AdminViewCSLoadNotesIdNotePriority"] as string + " " + notes[4].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbPriority);
                    }
                    else
                    {
                        TextBlock tbPriority = new TextBlock()
                        {
                            Text = Application.Current.Resources["VA_AdminViewCSLoadNotesIdNotePriority"] as string + " " + notes[4].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbPriority);
                    }

                    if (language.Equals("es"))
                    { // TextBox for completed
                        TextBlock tbCompleted = new TextBlock()
                        {
                            Text = Application.Current.Resources["AdminViewCSLoadNotesIdNoteCompleted"] as string + " " + notes[5].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbCompleted);
                    }
                    else if (language.Equals("en"))
                    {
                        TextBlock tbCompleted = new TextBlock()
                        {
                            Text = Application.Current.Resources["EN_AdminViewCSLoadNotesIdNoteCompleted"] as string + " " + notes[5].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbCompleted);
                    }
                    else
                    {
                        TextBlock tbCompleted = new TextBlock()
                        {
                            Text = Application.Current.Resources["VA_AdminViewCSLoadNotesIdNoteCompleted"] as string + " " + notes[5].ToString(),
                            TextWrapping = TextWrapping.Wrap,
                            Width = 186,
                            Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black
                        };
                        stackPanel.Children.Add(tbCompleted);
                    }


                    // StackPanel for the buttons
                    StackPanel stackPanelButtons = new StackPanel();
                    stackPanelButtons.Orientation = Orientation.Horizontal;
                    stackPanelButtons.HorizontalAlignment = HorizontalAlignment.Center;
                    stackPanelButtons.VerticalAlignment = VerticalAlignment.Bottom; // Align the buttons at the bottom
                    stackPanel.Children.Add(stackPanelButtons);

                    // Quit blue background when mouse is over the button
                    // Create a ControlTemplate for the button
                    ControlTemplate buttonTemplate = new ControlTemplate(typeof(System.Windows.Controls.Button));

                    // Create a FrameworkElementFactory for the Border
                    FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
                    border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(System.Windows.Controls.Button.BackgroundProperty));

                    // Create a FrameworkElementFactory for the ContentPresenter
                    FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
                    contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

                    // Add the ContentPresenter to the Border
                    border.AppendChild(contentPresenter);

                    // Add the Border to the ControlTemplate
                    buttonTemplate.VisualTree = border;

                    // Create a Trigger for the mouse over
                    Trigger mouseOverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
                    mouseOverTrigger.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = Brushes.Transparent });

                    // Button to report
                    System.Windows.Controls.Button btnReport = new System.Windows.Controls.Button();
                    btnReport.Width = 25;
                    btnReport.Height = 25;
                    btnReport.Background = Brushes.Transparent;
                    btnReport.BorderBrush = Brushes.Transparent;
                    btnReport.Template = buttonTemplate;
                    btnReport.Content = new PackIcon()
                    {
                        Kind = PackIconKind.Report,
                        Width = 21,
                        Height = 21,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    btnReport.Click += Button_Click_Report;
                    btnReport.Tag = notes[0];

                    if (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange))
                    {
                        tbTitle.Foreground = Brushes.White;
                        tbBody.Foreground = Brushes.White;
                        btnReport.Foreground = Brushes.White;

                    }
                    else
                    {
                        tbTitle.Foreground = Brushes.Black;
                        tbBody.Foreground = Brushes.Black;
                        btnReport.Foreground = Brushes.Black;
                    }

                    stackPanelButtons.Children.Add(btnReport);

                    wrapPanelNotes.Children.Add(stackPanel);
                }
            }
            // Add wrapPanelNotes to scrollViewerNotes
            scrollViewerNotes.Content = wrapPanelNotes;
            // Add scrollViewerNotes to grid
            grid.Children.Add(scrollViewerNotes);

            this.Content = grid;
        }

        private void loadNotesTitlesAndBodies(List<String> titles, List<String> bodies)
        {
            string language = File.ReadAllText(@"./Language.txt");

            if (titles.Count == 0 && bodies.Count == 0)
            {
                if (language.Equals("es"))
                {
                    MessageBox.Show(Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesDontFoundNotes"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (language.Equals("en"))
                {
                    MessageBox.Show(Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesDontFoundNotes"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesDontFoundNotes"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            // If exists a duplicated note, remove it
            for (int i = 0; i < titles.Count; i++)
            {
                for (int j = 0; j < bodies.Count; j++)
                {
                    if (titles[i].Equals(titles[j]))
                    {
                        bodies.RemoveAt(j);
                        j--;
                    }
                }
            }
            // Create a Grid
            Grid grid = new Grid();
            // Create a ScrollViewer
            ScrollViewer scrollViewerNotes = new ScrollViewer();
            // Create a StackPanel
            StackPanel mainStackPanel = new StackPanel();
            mainStackPanel.Orientation = Orientation.Vertical;
            // Create a WrapPanel
            WrapPanel wrapPanelTop = new WrapPanel();
            wrapPanelTop.Orientation = Orientation.Horizontal;
            wrapPanelTop.ItemWidth = 200;
            wrapPanelTop.Margin = new Thickness(0, 10, 0, 0);


            // Create a TextBlock
            TextBlock tbUserIDOrNoteID = new TextBlock()
            {
                Margin = new Thickness(20, 13, 632, 391),
                Text = "ID de usuario o ID de nota",
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbUserIDOrNoteID);

            // Create a ComboBox
            ComboBox cbUserIDOrNoteID = new ComboBox()
            {
                Name = "cbIDOrNoteID",
                Width = 120,
                Margin = new Thickness(167, 11, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                SelectedIndex = 0,
                Items =
            {
                "ID de usuario",
                "ID de nota"
            }
            };
            wrapPanelTop.Children.Add(cbUserIDOrNoteID);

            // Create a TextBox
            TextBox tbIDOrNoteID = new TextBox()
            {
                Name = "tbIDOrNoteID",
                Width = 66,
                Margin = new Thickness(292, 13, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbIDOrNoteID);

            // Create a TextBlock
            TextBlock tbTitleOrContent = new TextBlock()
            {
                Margin = new Thickness(383, 14, 309, 389),
                Text = "Título o contenido",
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tbTitleOrContent);

            // Create a TextBox
            TextBox tboxTitleOrContent = new TextBox()
            {
                Name = "txTitleOrContent",
                Width = 231,
                Margin = new Thickness(490, 14, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap
            };
            wrapPanelTop.Children.Add(tboxTitleOrContent);

            // Create a Button
            Button btnFindNotes = new Button()
            {
                Name = "btnFindNotes",
                Width = 43,
                Height = 19,
                Margin = new Thickness(726, 13, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = "Buscar",
            };
            btnFindNotes.Click += btnFindNotes_Click;
            wrapPanelTop.Children.Add(btnFindNotes);

            // Add wrapPanelTop to mainStackPanel
            mainStackPanel.Children.Add(wrapPanelTop);

            // Create a wrapPanel for the notes
            WrapPanel wrapPanelNotes = new WrapPanel();
            wrapPanelNotes.Orientation = Orientation.Horizontal;
            wrapPanelNotes.ItemWidth = 200;
            wrapPanelNotes.Margin = new Thickness(0, 10, 0, 0);

            int contador = 0;
            Debug.WriteLine(titles.Count / 6);
            for (int i = 0; i < titles.Count / 6; i++)
            {
                Debug.WriteLine(titles.Count / 6);
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Visibility = Visibility.Visible;


                TextBlock tbTitle = new TextBlock();
                TextBlock tbBody = new TextBlock();
                TextBlock tbIdNote = new TextBlock();
                TextBlock tbIdUser = new TextBlock();
                TextBlock tbPriority = new TextBlock();
                TextBlock tbCompleted = new TextBlock();
                if (contador % 6 == 0)
                {

                    tbTitle.Text = titles[contador].ToString();
                    tbTitle.TextWrapping = TextWrapping.Wrap;
                    tbTitle.Width = 186;
                    tbTitle.Height = 60;
                    tbTitle.Width = 186;
                    tbTitle.Margin = new Thickness(0, 0, 0, 5);
                    tbTitle.HorizontalAlignment = HorizontalAlignment.Center;
                    tbTitle.FontWeight = FontWeights.Bold;
                    stackPanel.Children.Add(tbTitle);
                    contador++;
                }
                // TextBox for the body

                if (contador % 6 == 1)
                {

                    tbBody.Text = titles[contador].ToString();
                    tbBody.TextWrapping = TextWrapping.Wrap;
                    tbBody.Width = 186;
                    ScrollViewer scrollViewerBody = new ScrollViewer();
                    scrollViewerBody.Content = tbBody;
                    scrollViewerBody.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollViewerBody.MaxHeight = 340; // Set a maximum height
                    scrollViewerBody.MinHeight = 340; // Set a minimum height
                    stackPanel.Children.Add(scrollViewerBody);
                    contador++;
                }
                if (language.Equals("es"))
                {// TextBox for the ID Note

                    if (contador % 6 == 2)
                    {

                        tbIdNote.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesIDNote"] as string + " " + titles[contador].ToString();
                        tbIdNote.TextWrapping = TextWrapping.Wrap;
                        tbIdNote.Width = 186;
                        stackPanel.Children.Add(tbIdNote);
                        contador++;
                    }
                }
                else if (language.Equals("en"))
                {
                    if (contador % 6 == 2)
                    {
                        tbIdNote.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesIDNote"] as string + " " + titles[contador].ToString();
                        tbIdNote.TextWrapping = TextWrapping.Wrap;
                        tbIdNote.Width = 186;
                        stackPanel.Children.Add(tbIdNote);
                        contador++;
                    }
                }
                else
                {
                    if (contador % 6 == 2)
                    {
                        tbIdNote.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesIDNote"] as string + " " + titles[contador].ToString();
                        tbIdNote.TextWrapping = TextWrapping.Wrap;
                        tbIdNote.Width = 186;
                        stackPanel.Children.Add(tbIdNote);
                        contador++;
                    }
                }

                if (language.Equals("es"))
                {
                    // TextBox for the ID User
                    if (contador % 6 == 3)
                    {

                        tbIdUser.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesIDUser"] as string + " " + titles[contador].ToString();
                        tbIdUser.TextWrapping = TextWrapping.Wrap;
                        tbIdUser.Width = 186;
                        stackPanel.Children.Add(tbIdUser);
                        contador++;
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for the ID User
                    if (contador % 6 == 3)
                    {
                        tbIdUser.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesIDUser"] as string + " " + titles[contador].ToString();
                        tbIdUser.TextWrapping = TextWrapping.Wrap;
                        tbIdUser.Width = 186;
                        stackPanel.Children.Add(tbIdUser);
                        contador++;
                    }
                }
                else
                {
                    // TextBox for the ID User
                    if (contador % 6 == 3)
                    {
                        tbIdUser.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesIDUser"] as string + " " + titles[contador].ToString();
                        tbIdUser.TextWrapping = TextWrapping.Wrap;
                        tbIdUser.Width = 186;
                        stackPanel.Children.Add(tbIdUser);
                        contador++;
                    }
                }

                if (language.Equals("es"))
                {
                    // TextBox for the priority
                    if (contador % 6 == 4)
                    {

                        tbPriority.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesPriority"] as string + " " + titles[contador].ToString();
                        tbPriority.TextWrapping = TextWrapping.Wrap;
                        tbPriority.Width = 186;
                        stackPanel.Children.Add(tbPriority);
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for the priority
                    if (contador % 6 == 4)
                    {
                        tbPriority.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesPriority"] as string + " " + titles[contador].ToString();
                        tbPriority.TextWrapping = TextWrapping.Wrap;
                        tbPriority.Width = 186;
                        stackPanel.Children.Add(tbPriority);
                    }
                }
                else
                {
                    // TextBox for the priority
                    if (contador % 6 == 4)
                    {
                        tbPriority.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesPriority"] as string + " " + titles[contador].ToString();
                        tbPriority.TextWrapping = TextWrapping.Wrap;
                        tbPriority.Width = 186;
                        stackPanel.Children.Add(tbPriority);
                    }
                }
                if ((contador % 6 == 4 && titles[contador].Contains("Alta")) || (contador % 6 == 4 && titles[contador].Contains("High")))
                {
                    stackPanel.Background = Brushes.Red;
                    contador++;
                }
                else if ((contador % 6 == 4 && titles[contador].Contains("Media")) || (contador % 6 == 4 && titles[contador].Contains("Medium")) || (contador % 6 == 4 && titles[contador].Contains("Mitjana")))
                {
                    stackPanel.Background = Brushes.Orange;
                    contador++;
                }
                else if ((contador % 6 == 4 && titles[contador].Contains("Baja")) || (contador % 6 == 4 && titles[contador].Contains("Low")) || (contador % 6 == 4 && titles[contador].Contains("Baixa")))
                {
                    stackPanel.Background = Brushes.White;
                    contador++;
                }
                if (contador % 6 == 5 && titles[contador].Contains("yes"))
                {
                    stackPanel.Background = Brushes.Green;
                    Debug.WriteLine(contador);

                }

                if (language.Equals("es"))
                {// TextBox for completed
                    if (contador % 6 == 5)
                    {

                        tbCompleted.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesCompleted"] as string + " " + titles[contador].ToString();
                        tbCompleted.TextWrapping = TextWrapping.Wrap;
                        tbCompleted.Width = 186;
                        stackPanel.Children.Add(tbCompleted);
                        contador++;
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for completed
                    if (contador % 6 == 5)
                    {
                        tbCompleted.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesCompleted"] as string + " " + titles[contador].ToString();
                        tbCompleted.TextWrapping = TextWrapping.Wrap;
                        tbCompleted.Width = 186;
                        stackPanel.Children.Add(tbCompleted);
                        contador++;
                    }
                }
                else
                {
                    // TextBox for completed
                    if (contador % 6 == 5)
                    {
                        tbCompleted.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesCompleted"] as string + " " + titles[contador].ToString();
                        tbCompleted.TextWrapping = TextWrapping.Wrap;
                        tbCompleted.Width = 186;
                        stackPanel.Children.Add(tbCompleted);
                        contador++;
                    }
                }




                // StackPanel for the buttons
                StackPanel stackPanelButtons = new StackPanel();
                stackPanelButtons.Orientation = Orientation.Horizontal;
                stackPanelButtons.HorizontalAlignment = HorizontalAlignment.Center;
                stackPanelButtons.VerticalAlignment = VerticalAlignment.Bottom; // Align the buttons at the bottom
                stackPanel.Children.Add(stackPanelButtons);


                ControlTemplate buttonTemplate = new ControlTemplate(typeof(System.Windows.Controls.Button));


                FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
                border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(System.Windows.Controls.Button.BackgroundProperty));


                FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
                contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);


                border.AppendChild(contentPresenter);


                buttonTemplate.VisualTree = border;


                Trigger mouseOverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
                mouseOverTrigger.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = Brushes.Transparent });

                // Button to report
                System.Windows.Controls.Button btnReport = new System.Windows.Controls.Button();
                btnReport.Width = 25;
                btnReport.Height = 25;
                btnReport.Background = Brushes.Transparent;
                btnReport.BorderBrush = Brushes.Transparent;
                btnReport.Template = buttonTemplate;
                btnReport.Content = new PackIcon()
                {
                    Kind = PackIconKind.Report,
                    Width = 21,
                    Height = 21,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black,

                };

                if (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange))
                {
                    tbTitle.Foreground = Brushes.White;
                    tbBody.Foreground = Brushes.White;
                    tbIdNote.Foreground = Brushes.White;
                    tbIdUser.Foreground = Brushes.White;
                    tbPriority.Foreground = Brushes.White;
                    tbCompleted.Foreground = Brushes.White;
                    btnReport.Foreground = Brushes.White;

                }
                else
                {
                    tbTitle.Foreground = Brushes.Black;
                    tbBody.Foreground = Brushes.Black;
                    tbIdNote.Foreground = Brushes.Black;
                    tbIdUser.Foreground = Brushes.Black;
                    tbPriority.Foreground = Brushes.Black;
                    tbCompleted.Foreground = Brushes.Black;
                    btnReport.Foreground = Brushes.Black;
                }
                btnReport.Click += Button_Click_Report;
                stackPanelButtons.Children.Add(btnReport);

                wrapPanelNotes.Children.Add(stackPanel);

                scrollViewerNotes.Content = wrapPanelNotes;
            }
            int contadorBodies = 0;

            for (int i = 0; i < bodies.Count / 6; i++)
            {
                Debug.WriteLine(bodies.Count / 6);
                Debug.WriteLine("Bodies: " + bodies.Count);
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Visibility = Visibility.Visible;

                TextBlock tbTitle = new TextBlock();
                TextBlock tbBody = new TextBlock();
                TextBlock tbIdNote = new TextBlock();
                TextBlock tbIdUser = new TextBlock();
                TextBlock tbPriority = new TextBlock();
                TextBlock tbCompleted = new TextBlock();

                // TextBox for the title
                if (contadorBodies % 6 == 0)
                {
                    tbTitle.Text = bodies[contadorBodies].ToString();
                    tbTitle.TextWrapping = TextWrapping.Wrap;
                    tbTitle.Width = 186;
                    tbTitle.Height = 60;
                    tbTitle.Width = 186;
                    tbTitle.Margin = new Thickness(0, 0, 0, 5);
                    tbTitle.HorizontalAlignment = HorizontalAlignment.Center;
                    tbTitle.FontWeight = FontWeights.Bold;
                    stackPanel.Children.Add(tbTitle);
                    contadorBodies++;
                }
                // TextBox for the body
                if (contadorBodies % 6 == 1)
                {
                    tbBody.Text = bodies[contadorBodies].ToString();
                    tbBody.TextWrapping = TextWrapping.Wrap;
                    tbBody.Width = 186;
                    ScrollViewer scrollViewerBody = new ScrollViewer();
                    scrollViewerBody.Content = tbBody;
                    scrollViewerBody.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollViewerBody.MaxHeight = 340; // Set a maximum height
                    scrollViewerBody.MinHeight = 340; // Set a minimum height
                    stackPanel.Children.Add(scrollViewerBody);
                    contadorBodies++;
                }
                if (language.Equals("es"))
                { // TextBox for the ID Note
                    if (contadorBodies % 6 == 2)
                    {
                        tbIdNote.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesIDNoteBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbIdNote.TextWrapping = TextWrapping.Wrap;
                        tbIdNote.Width = 186;
                        stackPanel.Children.Add(tbIdNote);
                        contadorBodies++;
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for the ID Note
                    if (contadorBodies % 6 == 2)
                    {
                        tbIdNote.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesIDNoteBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbIdNote.TextWrapping = TextWrapping.Wrap;
                        tbIdNote.Width = 186;
                        stackPanel.Children.Add(tbIdNote);
                        contadorBodies++;
                    }
                }
                else
                {
                    // TextBox for the ID Note
                    if (contadorBodies % 6 == 2)
                    {
                        tbIdNote.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesIDNoteBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbIdNote.TextWrapping = TextWrapping.Wrap;
                        tbIdNote.Width = 186;
                        stackPanel.Children.Add(tbIdNote);
                        contadorBodies++;
                    }
                }

                if (language.Equals("es"))
                { // TextBox for the ID User
                    if (contadorBodies % 6 == 3)
                    {
                        tbIdUser.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesIDUserBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbIdUser.TextWrapping = TextWrapping.Wrap;
                        tbIdUser.Width = 186;
                        stackPanel.Children.Add(tbIdUser);
                        contadorBodies++;
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for the ID User
                    if (contadorBodies % 6 == 3)
                    {
                        tbIdUser.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesIDUserBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbIdUser.TextWrapping = TextWrapping.Wrap;
                        tbIdUser.Width = 186;
                        stackPanel.Children.Add(tbIdUser);
                        contadorBodies++;
                    }
                }
                else
                {
                    // TextBox for the ID User
                    if (contadorBodies % 6 == 3)
                    {
                        tbIdUser.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesIDUserBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbIdUser.TextWrapping = TextWrapping.Wrap;
                        tbIdUser.Width = 186;
                        stackPanel.Children.Add(tbIdUser);
                        contadorBodies++;
                    }
                }

                if (language.Equals("es"))
                {
                    // TextBox for the priority
                    if (contadorBodies % 6 == 4)
                    {
                        tbPriority.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesPriorityBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbPriority.TextWrapping = TextWrapping.Wrap;
                        tbPriority.Width = 186;
                        stackPanel.Children.Add(tbPriority);
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for the priority
                    if (contadorBodies % 6 == 4)
                    {
                        tbPriority.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesPriorityBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbPriority.TextWrapping = TextWrapping.Wrap;
                        tbPriority.Width = 186;
                        stackPanel.Children.Add(tbPriority);
                    }
                }
                else
                {
                    // TextBox for the priority
                    if (contadorBodies % 6 == 4)
                    {
                        tbPriority.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesPriorityBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbPriority.TextWrapping = TextWrapping.Wrap;
                        tbPriority.Width = 186;
                        stackPanel.Children.Add(tbPriority);
                    }
                }
                if ((contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Alta")) || (contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("High")))
                {
                    stackPanel.Background = Brushes.Red;
                    contadorBodies++;
                }
                else if ((contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Media")) || (contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Medium")) || (contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Mitjana")))
                {
                    stackPanel.Background = Brushes.Orange;
                    contadorBodies++;
                }
                else if ((contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Baja")) || (contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Low")) || (contadorBodies % 6 == 4 && bodies[contadorBodies].Contains("Baixa")))
                {
                    stackPanel.Background = Brushes.White;
                    contadorBodies++;
                }
                if (contadorBodies % 6 == 5 && bodies[contadorBodies].Contains("yes"))
                {
                    stackPanel.Background = Brushes.Green;
                    Debug.WriteLine(contadorBodies);

                }
                if (language.Equals("es"))
                {// TextBox for completed
                    if (contadorBodies % 6 == 5)
                    {
                        tbCompleted.Text = Application.Current.Resources["AdminViewCSLoadNotesTitlesAndBodiesCompletedBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbCompleted.TextWrapping = TextWrapping.Wrap;
                        tbCompleted.Width = 186;
                        stackPanel.Children.Add(tbCompleted);
                        contadorBodies++;
                    }
                }
                else if (language.Equals("en"))
                {
                    // TextBox for completed
                    if (contadorBodies % 6 == 5)
                    {
                        tbCompleted.Text = Application.Current.Resources["EN_AdminViewCSLoadNotesTitlesAndBodiesCompletedBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbCompleted.TextWrapping = TextWrapping.Wrap;
                        tbCompleted.Width = 186;
                        stackPanel.Children.Add(tbCompleted);
                        contadorBodies++;
                    }
                }
                else
                {
                    // TextBox for completed
                    if (contadorBodies % 6 == 5)
                    {
                        tbCompleted.Text = Application.Current.Resources["VA_AdminViewCSLoadNotesTitlesAndBodiesCompletedBodies"] as string + " " + bodies[contadorBodies].ToString();
                        tbCompleted.TextWrapping = TextWrapping.Wrap;
                        tbCompleted.Width = 186;
                        stackPanel.Children.Add(tbCompleted);
                        contadorBodies++;
                    }
                }




                // StackPanel for the buttons
                StackPanel stackPanelButtons = new StackPanel();
                stackPanelButtons.Orientation = Orientation.Horizontal;
                stackPanelButtons.HorizontalAlignment = HorizontalAlignment.Center;
                stackPanelButtons.VerticalAlignment = VerticalAlignment.Bottom; // Align the buttons at the bottom
                stackPanel.Children.Add(stackPanelButtons);


                ControlTemplate buttonTemplate = new ControlTemplate(typeof(System.Windows.Controls.Button));


                FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
                border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(System.Windows.Controls.Button.BackgroundProperty));


                FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
                contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);


                border.AppendChild(contentPresenter);


                buttonTemplate.VisualTree = border;


                Trigger mouseOverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
                mouseOverTrigger.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = Brushes.Transparent });

                // Button to report
                System.Windows.Controls.Button btnReport = new System.Windows.Controls.Button();
                btnReport.Width = 25;
                btnReport.Height = 25;
                btnReport.Background = Brushes.Transparent;
                btnReport.BorderBrush = Brushes.Transparent;
                btnReport.Template = buttonTemplate;
                btnReport.Content = new PackIcon()
                {
                    Kind = PackIconKind.Report,
                    Width = 21,
                    Height = 21,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Foreground = (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange)) ? Brushes.White : Brushes.Black,
                };
                btnReport.Click += Button_Click_Report;
                stackPanelButtons.Children.Add(btnReport);

                if (stackPanel.Background.Equals(Brushes.Green) || stackPanel.Background.Equals(Brushes.Red) || stackPanel.Background.Equals(Brushes.Orange))
                {
                    tbTitle.Foreground = Brushes.White;
                    tbBody.Foreground = Brushes.White;
                    tbIdNote.Foreground = Brushes.White;
                    tbIdUser.Foreground = Brushes.White;
                    tbPriority.Foreground = Brushes.White;
                    tbCompleted.Foreground = Brushes.White;
                    btnReport.Foreground = Brushes.White;

                }
                else
                {
                    tbTitle.Foreground = Brushes.Black;
                    tbBody.Foreground = Brushes.Black;
                    tbIdNote.Foreground = Brushes.Black;
                    tbIdUser.Foreground = Brushes.Black;
                    tbPriority.Foreground = Brushes.Black;
                    tbCompleted.Foreground = Brushes.Black;
                    btnReport.Foreground = Brushes.Black;
                }

                wrapPanelNotes.Children.Add(stackPanel);

                scrollViewerNotes.Content = wrapPanelNotes;
            }

            grid.Children.Add(scrollViewerNotes);

            this.Content = grid;
        }
        private void translate()
        {
            string language = File.ReadAllText(@"./Language.txt");
            Debug.WriteLine("Language del archivo: " + language);
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainView))
                {
                    MainView mainWindow = (MainView)window;
                    mainWindow.tbSecondaryViewOpened.Text = "Admin";
                }
            }
            if (language.Equals("es"))
            {
                TIUser.Header = System.Windows.Application.Current.Resources["AdminViewTab1Header"] as string;
                TINotes.Header = System.Windows.Application.Current.Resources["AdminViewTab2Header"] as string;
                TIDashboard.Header = System.Windows.Application.Current.Resources["AdminViewTab3Header"] as string;
                TBTotalUsers.Text = System.Windows.Application.Current.Resources["AdminViewTotalUsers"] as string;
                TBTotalNotes.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotes"] as string;
                TBTotalNotesCompleted.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesCompleted"] as string;
                TBTotalNotesNoCompleted.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesNoCompleted"] as string;
                TBTotalHighPriorityNotes.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesHigh"] as string;
                TBTotalMediumPriorityNotes.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesMedium"] as string;
                TBTotalLowPriorityNotes.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesLow"] as string;
                TBPercentageNotesCompleted.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesCompletedPercentage"] as string;
                TBPercentageNotesNoCompleted.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesNoCompletedPercentage"] as string;
                TBPercentageNotesHighPriority.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesHighPercentage"] as string;
                TBPercentageNotesMediumPriority.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesMediumPercentage"] as string;
                TBPercentageNotesLowPriority.Text = System.Windows.Application.Current.Resources["AdminViewTotalNotesLowPercentage"] as string;
                TBEmailOrID.Text = System.Windows.Application.Current.Resources["AdminViewTab1TextBlock"] as string;
                TBIDUserOrIDNote.Text = System.Windows.Application.Current.Resources["AdminViewTab2TextBlock1"] as string;
                TBTitleOrContent.Text = System.Windows.Application.Current.Resources["AdminViewTab2TextBlock2"] as string;
                CBIIDUser.Content = System.Windows.Application.Current.Resources["AdminViewTab2ComboBoxItem1"] as string;
                CBIIDNote.Content = System.Windows.Application.Current.Resources["AdminViewTab2BomboBoxItem2"] as string;
                btnFindUserData.Content = System.Windows.Application.Current.Resources["AdminViewTab1Button"] as string;
                btnFindNotes.Content = System.Windows.Application.Current.Resources["AdminViewTab2Button1"] as string;
                btnFindNotesTitleOrContent.Content = System.Windows.Application.Current.Resources["AdminViewTab2Button2"] as string;
                btnCombinedSearch.Content = System.Windows.Application.Current.Resources["AdminViewTab2ButtonCombined"] as string;
            }
            else if (language.Equals("en"))
            {
                TIUser.Header = System.Windows.Application.Current.Resources["EN_AdminViewTab1Header"] as string;
                TINotes.Header = System.Windows.Application.Current.Resources["EN_AdminViewTab2Header"] as string;
                TIDashboard.Header = System.Windows.Application.Current.Resources["EN_AdminViewTab3Header"] as string;
                TBTotalUsers.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalUsers"] as string;
                TBTotalNotes.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotes"] as string;
                TBTotalNotesCompleted.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalCompletedNotes"] as string;
                TBTotalNotesNoCompleted.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotCompletedNotes"] as string;
                TBTotalHighPriorityNotes.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalHighPriorityNotes"] as string;
                TBTotalMediumPriorityNotes.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalMediumPriorityNotes"] as string;
                TBTotalLowPriorityNotes.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalLowPriorityNotes"] as string;
                TBPercentageNotesCompleted.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotesCompletedPercentage"] as string;
                TBPercentageNotesNoCompleted.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotesNotCompletedPercentage"] as string;
                TBPercentageNotesHighPriority.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotesHighPriorityPercentage"] as string;
                TBPercentageNotesMediumPriority.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotesMediumPriorityPercentage"] as string;
                TBPercentageNotesLowPriority.Text = System.Windows.Application.Current.Resources["EN_AdminViewTotalNotesLowPriorityPercentage"] as string;
                TBEmailOrID.Text = System.Windows.Application.Current.Resources["EN_AdminViewTab1TextBlock"] as string;
                TBIDUserOrIDNote.Text = System.Windows.Application.Current.Resources["EN_AdminViewTab2TextBlock1"] as string;
                TBTitleOrContent.Text = System.Windows.Application.Current.Resources["EN_AdminViewTab2TextBlock2"] as string;
                CBIIDUser.Content = System.Windows.Application.Current.Resources["EN_AdminViewTab2ComboBoxItem1"] as string;
                CBIIDNote.Content = System.Windows.Application.Current.Resources["EN_AdminViewTab2BomboBoxItem2"] as string;
                btnFindUserData.Content = System.Windows.Application.Current.Resources["EN_AdminViewTab1Button"] as string;
                btnFindNotes.Content = System.Windows.Application.Current.Resources["EN_AdminViewTab2Button1"] as string;
                btnFindNotesTitleOrContent.Content = System.Windows.Application.Current.Resources["EN_AdminViewTab2Button2"] as string;
                btnCombinedSearch.Content = System.Windows.Application.Current.Resources["EN_AdminViewTab2ButtonCombined"] as string;
            }
            else
            {
                TIUser.Header = System.Windows.Application.Current.Resources["VA_AdminViewTab1Header"] as string;
                TINotes.Header = System.Windows.Application.Current.Resources["VA_AdminViewTab2Header"] as string;
                TIDashboard.Header = System.Windows.Application.Current.Resources["VA_AdminViewTab3Header"] as string;
                TBTotalUsers.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalUsers"] as string;
                TBTotalNotes.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNotes"] as string;
                TBTotalNotesCompleted.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalCompletedNotes"] as string;
                TBTotalNotesNoCompleted.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNoCompletedNotes"] as string;
                TBTotalHighPriorityNotes.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalHighPriorityNotes"] as string;
                TBTotalMediumPriorityNotes.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalMediumPriorityNotes"] as string;
                TBTotalLowPriorityNotes.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalLowPriorityNotes"] as string;
                TBPercentageNotesCompleted.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNotesCompletedPercentage"] as string;
                TBPercentageNotesNoCompleted.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNotesNoCompletedPercentage"] as string;
                TBPercentageNotesHighPriority.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNotesHighPriorityPercentage"] as string;
                TBPercentageNotesMediumPriority.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNotesMediumPriorityPercentage"] as string;
                TBPercentageNotesLowPriority.Text = System.Windows.Application.Current.Resources["VA_AdminViewTotalNotesLowPriorityPercentage"] as string;
                TBEmailOrID.Text = System.Windows.Application.Current.Resources["VA_AdminViewTab1TextBlock"] as string;
                TBIDUserOrIDNote.Text = System.Windows.Application.Current.Resources["VA_AdminViewTab2TextBlock1"] as string;
                TBTitleOrContent.Text = System.Windows.Application.Current.Resources["VA_AdminViewTab2TextBlock2"] as string;
                CBIIDUser.Content = System.Windows.Application.Current.Resources["VA_AdminViewTab2ComboBoxItem1"] as string;
                CBIIDNote.Content = System.Windows.Application.Current.Resources["VA_AdminViewTab2BomboBoxItem2"] as string;
                btnFindUserData.Content = System.Windows.Application.Current.Resources["VA_AdminViewTab1Button"] as string;
                btnFindNotes.Content = System.Windows.Application.Current.Resources["VA_AdminViewTab2Button1"] as string;
                btnFindNotesTitleOrContent.Content = System.Windows.Application.Current.Resources["VA_AdminViewTab2Button2"] as string;
                btnCombinedSearch.Content = System.Windows.Application.Current.Resources["VA_AdminViewTab2ButtonCombined"] as string;
            }
        }

        private void setData()
        {
            TBTotalUsersCount.Text = _adminViewModel.getAllUsersCount().ToString(); // Set the total users count
            TBTotalNotesCount.Text = _adminViewModel.getAllNotesCount().ToString(); // Set the total notes count
            TBTotalNotesCompletedCount.Text = _adminViewModel.getAllNotesCompletedCount().ToString(); // Set the total notes completed count
            TBTotalNotesNoCompletedCount.Text = _adminViewModel.getAllNotesUncompletedCount().ToString(); // Set the total notes no completed count
            TBTotalHighPriorityNotesCount.Text = _adminViewModel.getAllNotesHighPriorityCount().ToString(); // Set the total high priority notes count
            TBTotalMediumPriorityNotesCount.Text = _adminViewModel.getAllNotesMediumPriorityCount().ToString(); // Set the total medium priority notes count
            TBTotalLowPriorityNotesCount.Text = _adminViewModel.getAllNotesLowPriorityCount().ToString(); // Set the total low priority notes count
                                                                                                          // Set the percentage of notes completed. If it's NaN, show 0
            double percentageNotesCompleted = _adminViewModel.getPercentajeNotesCompleted();
            if (double.IsNaN(percentageNotesCompleted))
            {
                TBPercentageNotesCompletedCount.Text = "0%";
            }
            else
            {
                TBPercentageNotesCompletedCount.Text = percentageNotesCompleted.ToString() + "%";
            }
            // Set the percentage of notes no completed. If it's NaN, show 0
            double percentageNotesNoCompleted = _adminViewModel.getPercentajeNotesUncompleted();
            if (double.IsNaN(percentageNotesNoCompleted))
            {
                TBPercentageNotesNoCompletedCount.Text = "0%";
            }
            else
            {
                TBPercentageNotesNoCompletedCount.Text = percentageNotesNoCompleted.ToString() + "%";
            }
            // Set the percentage of high priority notes. If it's NaN, show 0
            double percentageHighPriorityNotes = _adminViewModel.getPercentajeNotesHighPriority();
            if (double.IsNaN(percentageHighPriorityNotes))
            {
                TBPercentageNotesHighPriorityCount.Text = "0%";
            }
            else
            {
                TBPercentageNotesHighPriorityCount.Text = percentageHighPriorityNotes.ToString() + "%";
            }
            // Set the percentage of medium priority notes. If it's NaN, show 0
            double percentageMediumPriorityNotes = _adminViewModel.getPercentajeNotesMediumPriority();
            if (double.IsNaN(percentageMediumPriorityNotes))
            {
                TBPercentageNotesMediumPriorityCount.Text = "0%";
            }
            else
            {
                TBPercentageNotesMediumPriorityCount.Text = percentageMediumPriorityNotes.ToString() + "%";
            }
            // Set the percentage of low priority notes. If it's NaN, show 0
            double percentageLowPriorityNotes = _adminViewModel.getPercentajeNotesLowPriority();
            if (double.IsNaN(percentageLowPriorityNotes))
            {
                TBPercentageNotesLowPriorityCount.Text = "0%";
            }
            else
            {
                TBPercentageNotesLowPriorityCount.Text = percentageLowPriorityNotes.ToString() + "%";
            }
        }
    }
}