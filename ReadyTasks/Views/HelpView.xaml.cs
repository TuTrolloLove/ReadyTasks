
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadyTasks.Views
{

    public partial class HelpView : System.Windows.Controls.UserControl
    {
        public HelpView()
        {
            InitializeComponent();
            tbHelp.TextChanged += ValidateInputs;
            translate();
        }

        // Validate send button
        private void ValidateInputs(object sender, EventArgs e)
        {
            // El botón se habilitará
            btSave.IsEnabled = !string.IsNullOrWhiteSpace(tbHelp.Text);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["HelpViewReportSent"] as string, System.Windows.Application.Current.Resources["HelpViewReportSentCaption"] as string, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (language.Equals("en"))
            {
                System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["EN_HelpViewReportSent"] as string, System.Windows.Application.Current.Resources["EN_HelpViewReportSentCaption"] as string, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show(System.Windows.Application.Current.Resources["VA_HelpViewReportSent"] as string, System.Windows.Application.Current.Resources["VA_HelpViewReportSentCaption"] as string, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            tbHelp.Text = "";
        }

        private void translate()
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                tblockHelp.Text = System.Windows.Application.Current.Resources["HelpViewTextBlock"] as string;
                btSave.Content = System.Windows.Application.Current.Resources["HelpViewSendButton"] as string;
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["HelpViewCaption"] as string;
                    }
                }
            }
            else if (language.Equals("en"))
            {
                tblockHelp.Text = System.Windows.Application.Current.Resources["EN_HelpViewTextBlock"] as string;
                btSave.Content = System.Windows.Application.Current.Resources["EN_HelpViewSendButton"] as string;
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["EN_HelpViewCaption"] as string;
                    }
                }
            }
            else
            {
                tblockHelp.Text = System.Windows.Application.Current.Resources["VA_HelpViewTextBlock"] as string;
                btSave.Content = System.Windows.Application.Current.Resources["VA_HelpViewSendButton"] as string;
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["VA_HelpViewCaption"] as string;
                    }
                }
            }
        }
    }
}
