using Microsoft.VisualBasic.ApplicationServices;
using ReadyTasks.Models;
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
using System.Windows.Shapes;

namespace ReadyTasks.Views
{

    public partial class EditNoteView : Window
    {
        private EditNoteViewModel _editNoteViewModel;
        private int _userId;
        private int _idNote;
        private MainView _mainView;
        public EditNoteView(int userId, int idNote, string title, string body, string priority, string completed)
        {
            _userId = userId;
            _editNoteViewModel = new EditNoteViewModel(_userId);
            _idNote = idNote;

            if (_editNoteViewModel.ShowNoteToEdit(userId, idNote, title, body, priority, completed))
            {
                InitializeComponent();
                tbTitle.Text = title;
                tbContenido.Text = body;
                // Subscribed to the TextChanged event of the TextBoxes and the SelectionChanged event of the ComboBox to validate the inputs
                tbTitle.TextChanged += ValidateInputs;
                tbContenido.TextChanged += ValidateInputs;
                cbPrioridad.SelectionChanged += ValidateInputs;

                if (priority == "Alta" || priority == "High")
                {
                    cbPrioridad.SelectedItem = cbPrioridad.Items[2];
                }
                else if (priority == "Media" || priority == "Medium" || priority == "Mitjana")
                {
                    cbPrioridad.SelectedItem = cbPrioridad.Items[1];
                }
                else
                {
                    cbPrioridad.SelectedItem = cbPrioridad.Items[0];
                }
                // Close HomeView
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        window.Close();
                    }
                }
                // Subscribed to the MainView's Closed event
                _mainView = new MainView();
                _mainView.Closed += MainView_Closed;

                translate();
            }
            else
            {
                string language = File.ReadAllText(@"./Language.txt");
                if (language.Equals("es"))
                {
                    MessageBox.Show(Application.Current.Resources["EditNoteViewCSErrorMessage"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
                else if (language.Equals("en"))
                {
                    MessageBox.Show(Application.Current.Resources["EN_EditNoteViewCSErrorMessage"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Application.Current.Resources["VA_EditNoteViewCSErrorMessage"] as string, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }


            }

        }
        // Validate save button
        private void ValidateInputs(object sender, EventArgs e)
        {

            btSave.IsEnabled = !string.IsNullOrWhiteSpace(tbTitle.Text) && tbTitle.Text.Length > 0 && tbTitle.Text.Length < 61
            && !string.IsNullOrWhiteSpace(tbContenido.Text) && tbContenido.Text.Length > 0 && tbContenido.Text.Length < 629
            && cbPrioridad.SelectedItem != null && !string.IsNullOrWhiteSpace(cbPrioridad.SelectedItem.ToString());

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!_editNoteViewModel.editNote(_userId, _idNote, tbTitle.Text, tbContenido.Text, cbPrioridad.Text))
            {
                return;
            }
            else
            {
                this.Close();
            }

        }

        // If the window closes, the MainView is opened
        private void Window_Closed(object sender, EventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
        }
        private void MainView_Closed(object sender, EventArgs e)
        {
            // Unsubscribe from the MainView's Closed event
            _mainView.Closed -= MainView_Closed;

            // Check if the application is closing
            if (System.Windows.Application.Current.ShutdownMode != System.Windows.ShutdownMode.OnExplicitShutdown)
            {
                // Check if there is an existing MainView and close it
                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        window.Close();
                        break;
                    }
                }


            }
            else
            {
                // Create a new MainView, show it, and subscribe to its Closed event
                _mainView = new MainView();
                //_mainView.Show();
                _mainView.Closed += MainView_Closed;
            }
        }

        private void translate()
        {
            string language = File.ReadAllText(@"./Language.txt");
            Debug.WriteLine("Language del archivo: " + language);
            if (language.Equals("es"))
            {

                editNoteViewWindow.Title = Application.Current.Resources["EditNoteTitle"] as string;
                TBTitle.Text = Application.Current.Resources["EditNoteTextBlockTitleNote"] as string;
                TBContent.Text = Application.Current.Resources["EditNoteTextBlockContentNote"] as string;
                TBPriority.Text = Application.Current.Resources["EditNoteTextBlockPriorityNote"] as string;
                CBILow.Content = Application.Current.Resources["EditNoteComboBoxItemLow"] as string;
                CBIMedium.Content = Application.Current.Resources["EditNoteComboBoxItemMedium"] as string;
                CBIHigh.Content = Application.Current.Resources["EditNoteComboBoxItemHigh"] as string;
                btSave.Content = Application.Current.Resources["EditNoteButtonSave"] as string;
            }
            else if (language.Equals("en"))
            {
                editNoteViewWindow.Title = Application.Current.Resources["EN_EditNoteTitle"] as string;
                TBTitle.Text = Application.Current.Resources["EN_EditNoteTextBlockTitleNote"] as string;
                TBContent.Text = Application.Current.Resources["EN_EditNoteTextBlockContentNote"] as string;
                TBPriority.Text = Application.Current.Resources["EN_EditNoteTextBlockPriorityNote"] as string;
                CBILow.Content = Application.Current.Resources["EN_EditNoteComboBoxItemLow"] as string;
                CBIMedium.Content = Application.Current.Resources["EN_EditNoteComboBoxItemMedium"] as string;
                CBIHigh.Content = Application.Current.Resources["EN_EditNoteComboBoxItemHigh"] as string;
                btSave.Content = Application.Current.Resources["EN_EditNoteButtonSave"] as string;
            }
            else
            {
                editNoteViewWindow.Title = Application.Current.Resources["VA_EditNoteTitle"] as string;
                TBTitle.Text = Application.Current.Resources["VA_EditNoteTextBlockTitleNote"] as string;
                TBContent.Text = Application.Current.Resources["VA_EditNoteTextBlockContentNote"] as string;
                TBPriority.Text = Application.Current.Resources["VA_EditNoteTextBlockPriorityNote"] as string;
                CBILow.Content = Application.Current.Resources["VA_EditNoteComboBoxItemLow"] as string;
                CBIMedium.Content = Application.Current.Resources["VA_EditNoteComboBoxItemMedium"] as string;
                CBIHigh.Content = Application.Current.Resources["VA_EditNoteComboBoxItemHigh"] as string;
                btSave.Content = Application.Current.Resources["VA_EditNoteButtonSave"] as string;
            }
        }

        private void editNoteViewWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double originalWidth = 1280;

            double newWidth = e.NewSize.Width;
            double newHeight = e.NewSize.Height;

            stackPanel.Margin = new Thickness(342, (newWidth * 88) / originalWidth, 382, 17);



        }
    }
}
