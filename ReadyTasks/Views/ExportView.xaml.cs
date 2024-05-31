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
using System.Drawing;

namespace ReadyTasks.Views
{

    public partial class ExportView : UserControl
    {

        List<NoteModel> notes;

        public int _userId;

        public ExportView()
        {
            InitializeComponent();
            if (File.Exists(@"./ID.txt"))
            {
                _userId = int.Parse(File.ReadAllText(@"./ID.txt"));
                Debug.WriteLine("UserId del archivo: " + _userId);

            }
            translate();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            ExportViewModel exportViewModel = new ExportViewModel();
            exportViewModel.exportAllNotes(_userId, cbFormat.Text.ToString());
        }

        private void ExportView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double originalWidth = 1280;
            double originalHeight = 720;

            double newWidth = e.NewSize.Width;
            double newHeight = e.NewSize.Height;

            stackPanel.Margin = new Thickness(
                left: 128 * (newWidth / originalWidth),
                top: 69 * (newHeight / originalHeight),
                right: 108 * (newWidth / originalWidth),
                bottom: 78 * (newHeight / originalHeight)
            );

            rectangle.Width = 800 * (newWidth / originalWidth);
            rectangle.Height = 600 * (newHeight / originalHeight);



        }

        private void translate()
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                tbChooseFormat.Text = Application.Current.Resources["ExportFormatViewTextBlock1"] as string;
                btnExport.Content = Application.Current.Resources["ExportFormatViewButtonExport"] as string;
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["ExportViewCaption"] as string;
                    }
                }
            }
            else if (language.Equals("en"))
            {
                tbChooseFormat.Text = Application.Current.Resources["EN_ExportFormatViewTextBlock1"] as string;
                btnExport.Content = Application.Current.Resources["EN_ExportFormatViewButtonExport"] as string;
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["EN_ExportViewCaption"] as string;
                    }
                }
            }
            else
            {
                tbChooseFormat.Text = Application.Current.Resources["VA_ExportFormatViewTextBlock1"] as string;
                btnExport.Content = Application.Current.Resources["VA_ExportFormatViewButtonExport"] as string;
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["VA_ExportViewCaption"] as string;
                    }
                }
            }
        }
    }
}




