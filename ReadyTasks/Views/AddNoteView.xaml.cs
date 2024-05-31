using Microsoft.VisualBasic.ApplicationServices;
using ReadyTasks.Models;
using ReadyTasks.Repositories;
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


    public partial class AddNoteView : Window
    {
        private string _selectedComboBoxItem;
        private AddNoteViewModel _addNoteViewModel;
        private int _userId;
        private MainView _mainView;
        public string SelectedComboBoxItem
        {
            get => _selectedComboBoxItem;
            set
            {
                _selectedComboBoxItem = value;
            }
        }
        public AddNoteView(int userId)
        {
            _userId = userId;
            _addNoteViewModel = new AddNoteViewModel(_userId);
            InitializeComponent();
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

            // Subscribed to the TextBox and ComboBox events
            tbTitle.TextChanged += ValidateInputs;
            tbContenido.TextChanged += ValidateInputs;
            cbPrioridad.SelectionChanged += ValidateInputs;

            // Initial validation
            ValidateInputs(null, null);

            translate();

        }

        // Validate save button
        private void ValidateInputs(object sender, EventArgs e)
        {
            // Validations
            btSave.IsEnabled = !string.IsNullOrWhiteSpace(tbTitle.Text) && tbTitle.Text.Length > 0 && tbTitle.Text.Length < 61
            && !string.IsNullOrWhiteSpace(tbContenido.Text) && tbContenido.Text.Length > 0 && tbContenido.Text.Length < 629
            && cbPrioridad.SelectedItem != null && !string.IsNullOrWhiteSpace(cbPrioridad.SelectedItem.ToString());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _addNoteViewModel.AddNote(_userId, tbTitle.Text, tbContenido.Text, cbPrioridad.Text.ToString());
            this.Close();
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

                _mainView.Closed += MainView_Closed;
            }
        }
        private void translate()
        {
            // Read the file to set the language
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                windowTitle.Title = System.Windows.Application.Current.Resources["AddNoteTitle"] as string;
                TBTitle.Text = System.Windows.Application.Current.Resources["AddNoteLabelTitleNote"] as string;
                TBContent.Text = System.Windows.Application.Current.Resources["AddNoteLabelContentNote"] as string;
                TBPriority.Text = System.Windows.Application.Current.Resources["AddNoteLabelPriority"] as string;
                btSave.Content = System.Windows.Application.Current.Resources["AddNoteButtonSave"] as string;
                CBILow.Content = System.Windows.Application.Current.Resources["AddNoteComboBoxItemLow"] as string;
                CBIMedium.Content = System.Windows.Application.Current.Resources["AddNoteComboBoxItemMedium"] as string;
                CBIHigh.Content = System.Windows.Application.Current.Resources["AddNoteComboBoxItemHigh"] as string;
            }
            else if (language.Equals("en"))
            {
                windowTitle.Title = System.Windows.Application.Current.Resources["EN_AddNoteTitle"] as string;
                TBTitle.Text = System.Windows.Application.Current.Resources["EN_AddNoteLabelTitleNote"] as string;
                TBContent.Text = System.Windows.Application.Current.Resources["EN_AddNoteLabelContentNote"] as string;
                TBPriority.Text = System.Windows.Application.Current.Resources["EN_AddNoteLabelPriority"] as string;
                btSave.Content = System.Windows.Application.Current.Resources["EN_AddNoteButtonSave"] as string;
                CBILow.Content = System.Windows.Application.Current.Resources["EN_AddNoteComboBoxItemLow"] as string;
                CBIMedium.Content = System.Windows.Application.Current.Resources["EN_AddNoteComboBoxItemMedium"] as string;
                CBIHigh.Content = System.Windows.Application.Current.Resources["EN_AddNoteComboBoxItemHigh"] as string;
            }
            else
            {
                windowTitle.Title = System.Windows.Application.Current.Resources["VA_AddNoteTitle"] as string;
                TBTitle.Text = System.Windows.Application.Current.Resources["VA_AddNoteLabelTitleNote"] as string;
                TBContent.Text = System.Windows.Application.Current.Resources["VA_AddNoteLabelContentNote"] as string;
                TBPriority.Text = System.Windows.Application.Current.Resources["VA_AddNoteLabelPriority"] as string;
                btSave.Content = System.Windows.Application.Current.Resources["VA_AddNoteButtonSave"] as string;
                CBILow.Content = System.Windows.Application.Current.Resources["VA_AddNoteComboBoxItemLow"] as string;
                CBIMedium.Content = System.Windows.Application.Current.Resources["VA_AddNoteComboBoxItemMedium"] as string;
                CBIHigh.Content = System.Windows.Application.Current.Resources["VA_AddNoteComboBoxItemHigh"] as string;
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
