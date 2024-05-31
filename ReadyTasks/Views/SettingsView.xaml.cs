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

namespace ReadyTasks.Views
{

    public partial class SettingsView : UserControl
    {
        private int _userId;
        public SettingsView()
        {
            InitializeComponent();
            if (File.Exists(@"./ID.txt"))
            {
                _userId = int.Parse(File.ReadAllText(@"./ID.txt"));
                Debug.WriteLine("UserId del archivo: " + _userId);

            }
            translate();

        }

        private void Button_Click_DeleteAccount(object sender, RoutedEventArgs e)
        {
            SettingsViewModel settingsViewModel = new SettingsViewModel();
            settingsViewModel.deleteAllUser(_userId);
        }

        private void Button_Click_DeleteAllNotes(object sender, RoutedEventArgs e)
        {
            SettingsViewModel settingsViewModel = new SettingsViewModel();
            settingsViewModel.deleteAllNotes(_userId);
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLanguage.SelectedIndex == 0)
            {
                // Spanish
                // Create a file to write to.
                File.WriteAllText(@"./Language.txt", "es");
                Debug.WriteLine("Language: " + File.ReadAllText(@"./Language.txt"));

                // TextBlock Translated
                TBLanguage.Text = System.Windows.Application.Current.Resources["SettingsViewTextBlock"] as string;
                TBDeleteAllNotes.Text = System.Windows.Application.Current.Resources["SettingsViewTextBlockDeleteAllNotes"] as string;
                TBDeleteAccount.Text = System.Windows.Application.Current.Resources["SettingsViewTextBlockDeleteAccount"] as string;
                // Buttons Content
                BTDeleteAllNotes.Content = System.Windows.Application.Current.Resources["SettingsViewTextBlockDeleteAllNotesClick"] as string;
                BTDeleteAccount.Content = System.Windows.Application.Current.Resources["SettingsViewTextBlockDeleteAccountClick"] as string;
                // ComboBoxItem Content
                cbItem1.Content = System.Windows.Application.Current.Resources["SettingsViewComboBoxItem1"] as string;
                cbItem2.Content = System.Windows.Application.Current.Resources["SettingsViewComboBoxItem2"] as string;
                cbItem3.Content = System.Windows.Application.Current.Resources["SettingsViewComboBoxItem3"] as string;



                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;

                        mainWindow.tbGraphicNavBar.Text = System.Windows.Application.Current.Resources["MainViewDoGraphic"] as string;
                        mainWindow.tbNotesNavBar.Text = System.Windows.Application.Current.Resources["MainViewDashboard"] as string;
                        mainWindow.tbExportNotesNavBar.Text = System.Windows.Application.Current.Resources["MainViewExportAllNotes"] as string;
                        mainWindow.tbSettingsNavBar.Text = System.Windows.Application.Current.Resources["MainViewSettings"] as string;
                        mainWindow.tbHelpNavBar.Text = System.Windows.Application.Current.Resources["MainViewHelp"] as string;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["MainViewSettings"] as string;
                    }
                }
            }
            else if (cbLanguage.SelectedIndex == 1)
            {
                // English
                // Create a file to write to.
                File.WriteAllText(@"./Language.txt", "en");
                Debug.WriteLine("Language: " + File.ReadAllText(@"./Language.txt"));
                // TextBlock Translated
                TBLanguage.Text = System.Windows.Application.Current.Resources["EN_SettingsViewTextBlock"] as string;
                TBDeleteAllNotes.Text = System.Windows.Application.Current.Resources["EN_SettingsViewTextBlockDeleteAllNotes"] as string;
                TBDeleteAccount.Text = System.Windows.Application.Current.Resources["EN_SettingsViewTextBlockDeleteAccount"] as string;
                // Buttons Content
                BTDeleteAllNotes.Content = System.Windows.Application.Current.Resources["EN_SettingsViewTextBlockDeleteAllNotesClick"] as string;
                BTDeleteAccount.Content = System.Windows.Application.Current.Resources["EN_SettingsViewTextBlockDeleteAccountClick"] as string;
                // ComboBoxItem Content
                cbItem1.Content = System.Windows.Application.Current.Resources["EN_SettingsViewComboBoxItem1"] as string;
                cbItem2.Content = System.Windows.Application.Current.Resources["EN_SettingsViewComboBoxItem2"] as string;
                cbItem3.Content = System.Windows.Application.Current.Resources["EN_SettingsViewComboBoxItem3"] as string;


                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;

                        mainWindow.tbGraphicNavBar.Text = System.Windows.Application.Current.Resources["EN_MainViewDoGraphic"] as string;
                        mainWindow.tbNotesNavBar.Text = System.Windows.Application.Current.Resources["EN_MainViewDashboard"] as string;
                        mainWindow.tbExportNotesNavBar.Text = System.Windows.Application.Current.Resources["EN_MainViewExportAllNotes"] as string;
                        mainWindow.tbSettingsNavBar.Text = System.Windows.Application.Current.Resources["EN_MainViewSettings"] as string;
                        mainWindow.tbHelpNavBar.Text = System.Windows.Application.Current.Resources["EN_MainViewHelp"] as string;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["EN_MainViewSettings"] as string;
                    }
                }
            }
            else
            {
                // Valencian
                // Create a file to write to.
                File.WriteAllText(@"./Language.txt", "va");
                Debug.WriteLine("Language: " + File.ReadAllText(@"./Language.txt"));
                // TextBlock Translated
                TBLanguage.Text = System.Windows.Application.Current.Resources["VA_SettingsViewTextBlock"] as string;
                TBDeleteAllNotes.Text = System.Windows.Application.Current.Resources["VA_SettingsViewTextBlockDeleteAllNotes"] as string;
                TBDeleteAccount.Text = System.Windows.Application.Current.Resources["VA_SettingsViewTextBlockDeleteAccount"] as string;
                // Buttons Content
                BTDeleteAllNotes.Content = System.Windows.Application.Current.Resources["VA_SettingsViewTextBlockDeleteAllNotesClick"] as string;
                BTDeleteAccount.Content = System.Windows.Application.Current.Resources["VA_SettingsViewTextBlockDeleteAccountClick"] as string;
                // ComboBoxItem Content
                cbItem1.Content = System.Windows.Application.Current.Resources["VA_SettingsViewComboBoxItem1"] as string;
                cbItem2.Content = System.Windows.Application.Current.Resources["VA_SettingsViewComboBoxItem2"] as string;
                cbItem3.Content = System.Windows.Application.Current.Resources["VA_SettingsViewComboBoxItem3"] as string;

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;

                        mainWindow.tbGraphicNavBar.Text = System.Windows.Application.Current.Resources["VA_MainViewDoGraphic"] as string;
                        mainWindow.tbNotesNavBar.Text = System.Windows.Application.Current.Resources["VA_MainViewDashboard"] as string;
                        mainWindow.tbExportNotesNavBar.Text = System.Windows.Application.Current.Resources["VA_MainViewExportAllNotes"] as string;
                        mainWindow.tbSettingsNavBar.Text = System.Windows.Application.Current.Resources["VA_MainViewSettings"] as string;
                        mainWindow.tbHelpNavBar.Text = System.Windows.Application.Current.Resources["VA_MainViewHelp"] as string;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["VA_MainViewSettings"] as string;
                    }
                }



            }
        }
        private void translate()
        {
            // Read the file
            if (File.Exists(@"./Language.txt"))
            {
                string language = File.ReadAllText(@"./Language.txt");
                Debug.WriteLine("Language del archivo: " + language);
                if (language.Equals("es"))
                {
                    cbLanguage.SelectedIndex = 0;
                    TBLanguage.Text = System.Windows.Application.Current.Resources["SettingsViewTextBlock"] as string;
                }
                else if (language.Equals("en"))
                {
                    cbLanguage.SelectedIndex = 1;
                    TBLanguage.Text = System.Windows.Application.Current.Resources["EN_SettingsViewTextBlock"] as string;
                }
                else
                {
                    cbLanguage.SelectedIndex = 2;
                    TBLanguage.Text = System.Windows.Application.Current.Resources["VA_SettingsViewTextBlock"] as string;
                }
            }
        }
    }
}
