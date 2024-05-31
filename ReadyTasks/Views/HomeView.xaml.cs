using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using MaterialDesignThemes.Wpf;
using System.IO;
using ReadyTasks.ViewModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Interop;

using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace ReadyTasks.Views
{

    public partial class HomeView : UserControl
    {
        private INoteRepository _INoteRepository;
        INoteRepository noteRepository = new NoteRepository();
        private NoteRepository _noteRepository = new NoteRepository();
        private MainView _mainView;

        List<NoteModel> notes;

        public int _userId;
        public HomeView(int userId)
        {
            InitializeComponent();



            Debug.WriteLine("UserId: " + _userId);
            if (File.Exists(@"./ID.txt"))
            {
                _userId = int.Parse(File.ReadAllText(@"./ID.txt"));
                Debug.WriteLine("UserId del archivo: " + _userId);

            }
            if (!File.Exists(@"./Language.txt"))
            {
                File.WriteAllText(@"./Language.txt", "es");
            }
            translateCaption();
            LoadNotes();

        }


        public HomeView()
        {
            InitializeComponent();
            Debug.WriteLine("Hola");
            _INoteRepository = noteRepository;


            if (File.Exists(@"./ID.txt"))
            {

                _userId = int.Parse(File.ReadAllText(@"./ID.txt"));
                Debug.WriteLine("UserId del archivo: " + _userId);

            }

            translateCaption();
            LoadNotes();

        }

        public void LoadNotes()
        {
            notes = new List<NoteModel>();
            if (notes.Count != 0)
            {
                notes.Clear();
            }
            notes = _noteRepository.obtainNotes(_userId);
            Grid grid = new Grid();
            // Create an StackPanel with vertical orientation
            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Vertical;

            // Create a button to add notes
            System.Windows.Controls.Button btnAddNote = new System.Windows.Controls.Button();
            btnAddNote.Width = 25;
            btnAddNote.Height = 25;
            btnAddNote.Content = new PackIcon()
            {
                Kind = PackIconKind.Plus,
                Width = 21,
                Height = 21,
            };
            btnAddNote.Background = Brushes.Transparent;
            btnAddNote.BorderBrush = Brushes.Transparent;

            // Remove the blue background on mouse-over
            // Create a new instance of ControlTemplate
            ControlTemplate buttonTemplate = new ControlTemplate(typeof(System.Windows.Controls.Button));

            // Create a new frame (Border) and set its Background property
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(System.Windows.Controls.Button.BackgroundProperty));

            // Create a new ContentPresenter and set its alignment properties
            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            // Adding the ContentPresenter to the frame
            border.AppendChild(contentPresenter);

            // Add the frame to the button template
            buttonTemplate.VisualTree = border;

            // Create a new trigger for the IsMouseOver status
            Trigger mouseOverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
            mouseOverTrigger.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = Brushes.Transparent });

            // Add the trigger to the button template
            buttonTemplate.Triggers.Add(mouseOverTrigger);

            // Establish your template
            btnAddNote.Template = buttonTemplate;


            btnAddNote.Click += Button_Click;
            btnAddNote.Margin = new Thickness(0, 10, 0, 10);
            btnAddNote.HorizontalAlignment = HorizontalAlignment.Left;

            // Add button to the main StackPanel
            mainPanel.Children.Add(btnAddNote);

            if (notes.Count == 0)
            {

                tbFirstNote.Visibility = Visibility.Visible;
                //imageFirstNote.Visibility = Visibility.Visible;
                //if (imageFirstNote.Parent is Panel parentPanel)
                //{
                //    parentPanel.Children.Remove(imageFirstNote);
                //}
                //mainPanel.Children.Add(imageFirstNote);
            }
            else
            {
                tbFirstNote.Visibility = Visibility.Hidden;
                //imageFirstNote.Visibility = Visibility.Hidden;

                // ScrollViewer for scrolling the view
                ScrollViewer scrollViewerNotes = new ScrollViewer();
                scrollViewerNotes.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

                // WrapPanel for the notes
                WrapPanel wrapPanel = new WrapPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.ItemWidth = 200;
                wrapPanel.Margin = new Thickness(0, 10, 0, 0);

                for (int i = notes.Count - 1; i >= 0; i--)
                {
                    Debug.WriteLine("Nota " + i);
                    Debug.WriteLine("Title: " + notes[i].title);
                    Debug.WriteLine("Body: " + notes[i].body);
                    Debug.WriteLine("Priority: " + notes[i].priority);
                    Debug.WriteLine("Completed: " + notes[i].completed);


                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Vertical;


                    // TextBox for the title
                    TextBlock tbTitle = new TextBlock()
                    {
                        Text = notes[i].title,
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
                        Text = notes[i].body,
                        TextWrapping = TextWrapping.Wrap,
                        Width = 186,
                    };

                    stackPanel.Visibility = Visibility.Visible;
                    if (notes[i].completed.Equals("yes"))
                    {
                        stackPanel.Background = Brushes.Green;
                        tbTitle.Foreground = Brushes.White;
                        tbBody.Foreground = Brushes.White;
                    }
                    else
                    {

                        if (notes[i].priority.Equals("Alta") || notes[i].priority.Equals("High") || notes[i].priority.Equals("Alta"))
                        {
                            stackPanel.Background = Brushes.Red;
                            tbTitle.Foreground = Brushes.White; ;
                            tbBody.Foreground = Brushes.White; ;
                        }
                        else if (notes[i].priority.Equals("Media") || notes[i].priority.Equals("Medium") || notes[i].priority.Equals("Mitjana"))
                        {
                            stackPanel.Background = Brushes.Orange;
                            tbTitle.Foreground = Brushes.White; ;
                            tbBody.Foreground = Brushes.White; ;
                        }
                        else if (notes[i].priority.Equals("Baja") || notes[i].priority.Equals("Low") || notes[i].priority.Equals("Baixa"))
                        {
                            stackPanel.Background = Brushes.White;
                            tbTitle.Foreground = Brushes.Black;
                            tbBody.Foreground = Brushes.Black;
                        }
                    }



                    // ScrollViewer for the body of the notes
                    ScrollViewer scrollViewerBody = new ScrollViewer()
                    {
                        Content = tbBody,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        MaxHeight = 340,
                        MinHeight = 340
                    };

                    stackPanel.Children.Add(scrollViewerBody);

                    // StackPanel for the buttons
                    StackPanel stackPanelButtons = new StackPanel();
                    stackPanelButtons.Orientation = Orientation.Horizontal;
                    stackPanelButtons.HorizontalAlignment = HorizontalAlignment.Center;
                    stackPanelButtons.VerticalAlignment = VerticalAlignment.Bottom; // Align the buttons at the bottom
                    stackPanel.Children.Add(stackPanelButtons);

                    // Button for delete
                    System.Windows.Controls.Button btnDelete = new System.Windows.Controls.Button();
                    btnDelete.Width = 25;
                    btnDelete.Height = 25;
                    btnDelete.BorderBrush = Brushes.Transparent;
                    btnDelete.Background = Brushes.Transparent;

                    // Establish your template to delete blue background button
                    btnDelete.Template = buttonTemplate;

                    btnDelete.Content = new PackIcon()
                    {
                        Kind = PackIconKind.Delete,
                        Width = 21,
                        Height = 21,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Foreground = (stackPanel.Background.Equals(Brushes.White) ? Brushes.Black : Brushes.White)
                    };
                    btnDelete.Click += Button_Click_Delete;
                    btnDelete.Tag = notes[i].id;
                    stackPanelButtons.Children.Add(btnDelete);



                    // Button for edit
                    System.Windows.Controls.Button btnEdit = new System.Windows.Controls.Button();
                    btnEdit.Width = 25;
                    btnEdit.Height = 25;
                    btnEdit.BorderBrush = Brushes.Transparent;
                    btnEdit.Background = Brushes.Transparent;
                    btnEdit.Template = buttonTemplate;
                    btnEdit.Content = new PackIcon()
                    {
                        Kind = PackIconKind.Edit,
                        Width = 21,
                        Height = 21,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Foreground = (stackPanel.Background.Equals(Brushes.White) ? Brushes.Black : Brushes.White)
                    };
                    btnEdit.Click += Button_Click_Edit;
                    btnEdit.Tag = notes[i].id;
                    stackPanelButtons.Children.Add(btnEdit);

                    // Button for complete
                    System.Windows.Controls.Button btnComplete = new System.Windows.Controls.Button();
                    btnComplete.Width = 25;
                    btnComplete.Height = 25;
                    btnComplete.BorderBrush = Brushes.Transparent;
                    btnComplete.Background = Brushes.Transparent;
                    btnComplete.Template = buttonTemplate;
                    btnComplete.Content = new PackIcon()
                    {
                        Kind = PackIconKind.Check,
                        Width = 21,
                        Height = 21,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Foreground = (stackPanel.Background.Equals(Brushes.White) ? Brushes.Black : Brushes.White)
                    };
                    btnComplete.Click += Button_Click_Complete;
                    btnComplete.Tag = notes[i].id;
                    stackPanelButtons.Children.Add(btnComplete);

                    // Button for export notes
                    System.Windows.Controls.Button btnExport = new System.Windows.Controls.Button();
                    btnExport.Width = 25;
                    btnExport.Height = 25;
                    btnExport.BorderBrush = Brushes.Transparent;
                    btnExport.Background = Brushes.Transparent;
                    btnExport.Template = buttonTemplate;
                    btnExport.Content = new PackIcon()
                    {
                        Kind = PackIconKind.Export,
                        Width = 21,
                        Height = 21,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Foreground = (stackPanel.Background.Equals(Brushes.White) ? Brushes.Black : Brushes.White)
                    };
                    btnExport.Click += Button_Click_Export;
                    btnExport.Tag = notes[i].id;
                    stackPanelButtons.Children.Add(btnExport);

                    // Button for Windows notification
                    System.Windows.Controls.Button btnNotification = new System.Windows.Controls.Button();
                    btnNotification.Width = 25;
                    btnNotification.Height = 25;
                    btnNotification.BorderBrush = Brushes.Transparent;
                    btnNotification.Background = Brushes.Transparent;
                    btnNotification.Template = buttonTemplate;
                    btnNotification.Content = new PackIcon()
                    {
                        Kind = PackIconKind.Bell,
                        Width = 21,
                        Height = 21,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Foreground = (stackPanel.Background.Equals(Brushes.White) ? Brushes.Black : Brushes.White)
                    };


                    btnNotification.Click += Button_Click_Notification;
                    btnNotification.Tag = notes[i].id;
                    stackPanelButtons.Children.Add(btnNotification);

                    wrapPanel.Children.Add(stackPanel);
                }

                // Added wrapPanel to the main panel
                mainPanel.Children.Add(wrapPanel);

                this.Content = grid;


            }
            // ScrollViewer for the main panel
            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.Content = mainPanel;
            if (notes.Count == 0)
            {
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

            }
            else
            {
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;

            // Added the ScrollViewer to the grid
            grid.Children.Add(scrollViewer);

            this.Content = grid;

            Debug.WriteLine("Notes count: " + notes.Count);

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {

                if (MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewDeleteConfirmationMBText"] as string,
                    System.Windows.Application.Current.Resources["HomeViewDeleteConfirmationMBCaption"] as string,
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
                    if (button != null)
                    {
                        int id = (int)button.Tag;

                        for (int i = 0; i < notes.Count; i++)
                        {
                            if (notes[i].id == id)
                            {
                                HomeViewModel homeViewModel = new HomeViewModel();
                                homeViewModel.deleteNote(notes[i].id, _userId);

                                LoadNotes();
                            }
                        }
                    }
                }
            }
            else if (language.Equals("en"))
            { // Alert
                if (MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewDeleteConfirmationMBText"] as string,
                    System.Windows.Application.Current.Resources["EN_HomeViewDeleteConfirmationMBCaption"] as string,
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
                    if (button != null)
                    {
                        int id = (int)button.Tag;
                        // Search ID in the notes list
                        for (int i = 0; i < notes.Count; i++)
                        {
                            if (notes[i].id == id)
                            {
                                HomeViewModel homeViewModel = new HomeViewModel();
                                homeViewModel.deleteNote(notes[i].id, _userId);

                                LoadNotes();
                            }
                        }
                    }

                }
            }
            else
            {
                // Alerta de confirmación
                if (MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewDeleteConfirmationMBText"] as string,
                    System.Windows.Application.Current.Resources["VA_HomeViewDeleteConfirmationMBCaption"] as string,
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
                    if (button != null)
                    {
                        int id = (int)button.Tag;
                        // Buscar el id en la lista de notas
                        for (int i = 0; i < notes.Count; i++)
                        {
                            if (notes[i].id == id)
                            {
                                HomeViewModel homeViewModel = new HomeViewModel();
                                homeViewModel.deleteNote(notes[i].id, _userId);

                                LoadNotes();
                            }
                        }
                    }

                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(_userId);
            AddNoteView addNoteView = new AddNoteView(_userId);

            addNoteView.Show();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                int id = (int)button.Tag;
                // Search ID in the notes list
                for (int i = 0; i < notes.Count; i++)
                {
                    if (notes[i].id == id)
                    {
                        EditNoteView editNoteView = new EditNoteView(_userId, notes[i].id, notes[i].title, notes[i].body, notes[i].priority, notes[i].completed);
                        editNoteView.Show();

                    }
                }
            }

        }
        private void Button_Click_Complete(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                int id = (int)button.Tag;
                // Buscar el id en la lista de notas
                for (int i = 0; i < notes.Count; i++)
                {
                    if (notes[i].id == id)
                    {
                        HomeViewModel homeViewModel = new HomeViewModel();
                        homeViewModel.markAsCompleted(notes[i].id, _userId, notes[i].completed);

                        LoadNotes();

                    }
                }
            }
        }
        private void Button_Click_Export(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                int id = (int)button.Tag;
                // Search ID in the notes list
                for (int i = 0; i < notes.Count; i++)
                {
                    if (notes[i].id == id)
                    {

                        ExportFormatWindow exportFormatWindow = new ExportFormatWindow();
                        if (exportFormatWindow.ShowDialog() == true)
                        {
                            string selectedFormat = exportFormatWindow.SelectedFormat;
                            if (selectedFormat.Equals("CSV"))
                            {
                                HomeViewModel homeViewModel = new HomeViewModel();
                                try
                                {
                                    homeViewModel.exportNote(selectedFormat, notes[i].title, notes[i].body, notes[i].priority, notes[i].completed);
                                }
                                catch (System.IO.IOException)
                                {
                                    string language = File.ReadAllText(@"./Language.txt");
                                    if (language.Equals("es"))
                                    {
                                        System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewConvertErrorMBText"] as string,
                                        "Error", MessageBoxButton.OK, (MessageBoxImage)System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                    else if (language.Equals("en"))
                                    {
                                        System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewConvertErrorMBText"] as string,
                                                                               "Error", MessageBoxButton.OK, (MessageBoxImage)System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewConvertErrorMBText"] as string,
                                                                               "Error", MessageBoxButton.OK, (MessageBoxImage)System.Windows.Forms.MessageBoxIcon.Error);
                                    };

                                };



                            }
                            else if (selectedFormat.Equals("TXT"))
                            {
                                HomeViewModel homeViewModel = new HomeViewModel();
                                try
                                {
                                    homeViewModel.exportNote(selectedFormat, notes[i].title, notes[i].body, notes[i].priority, notes[i].completed);
                                }
                                catch (System.IO.IOException)
                                {
                                    string language = File.ReadAllText(@"./Language.txt");
                                    if (language.Equals("es"))
                                    {
                                        System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["HomeViewConvertErrorMBText"] as string,
                                            "Error", MessageBoxButton.OK, (MessageBoxImage)System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                    else if (language.Equals("en"))
                                    {
                                        System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HomeViewConvertErrorMBText"] as string,
                                            "Error", MessageBoxButton.OK, (MessageBoxImage)System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HomeViewConvertErrorMBText"] as string,
                                        "Error", MessageBoxButton.OK, (MessageBoxImage)System.Windows.Forms.MessageBoxIcon.Error);
                                    };

                                };

                            }
                        }
                    }
                }
            }
        }
        private void Button_Click_Notification(object sender, RoutedEventArgs e)
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                int id = (int)button.Tag;
                // Find the id in the notes list
                for (int i = 0; i < notes.Count; i++)
                {
                    if (notes[i].id == id)
                    {
                        homeViewModel.createAndShowNotification(notes[i].title, notes[i].body);
                    }
                }
            }
        }

        private void translateCaption()
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["HomeViewCaption"] as string;
                    }
                }
            }
            else if (language.Equals("en"))
            {
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["EN_HomeViewCaption"] as string;
                    }
                }
            }
            else
            {
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["VA_HomeViewCaption"] as string;
                    }
                }
            }
        }


    }
}