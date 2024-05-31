using System;
using System.Collections.Generic;
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
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.IO;
using ReadyTasks.ViewModels;
using System.Diagnostics;
using ReadyTasks.Models;
using ReadyTasks.Repositories;

namespace ReadyTasks.Views
{
    public partial class MainView : Window
    {
        public bool isAdmin;
        public IUserRepository _userRepository;
        public MainView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; // not cover the taskbar when maximizing the taskbar.
            _userRepository = new UserRepository();
            string idText = File.ReadAllText(@"./ID.txt");
            if (!string.IsNullOrWhiteSpace(idText))
            {
                if (_userRepository.isAdmin(int.Parse(File.ReadAllText(@"./ID.txt"))))
                {
                    isAdmin = true;
                }
                else
                {
                    isAdmin = false;
                }
            }

            if (isAdmin)
            {
                rbAdmin.Visibility = Visibility.Visible;
            }
            else
            {
                rbAdmin.Visibility = Visibility.Hidden;
            }
            translate();
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; // To work in monitors with different resolutions when change it
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            File.SetAttributes(@"./ID.txt", File.GetAttributes(@"./ID.txt") & ~FileAttributes.ReadOnly);
            File.Delete(@"./ID.txt");
            Application.Current.Shutdown();
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void translate()
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                tbNotesNavBar.Text = Application.Current.Resources["MainViewDashboard"] as string;
                tbGraphicNavBar.Text = Application.Current.Resources["MainViewDoGraphic"] as string;
                tbExportNotesNavBar.Text = Application.Current.Resources["MainViewExportAllNotes"] as string;
                tbSettingsNavBar.Text = Application.Current.Resources["MainViewSettings"] as string;
                tbHelpNavBar.Text = Application.Current.Resources["MainViewHelp"] as string;
            }
            else if (language.Equals("en"))
            {
                tbNotesNavBar.Text = Application.Current.Resources["EN_MainViewDashboard"] as string;
                tbGraphicNavBar.Text = Application.Current.Resources["EN_MainViewDoGraphic"] as string;
                tbExportNotesNavBar.Text = Application.Current.Resources["EN_MainViewExportAllNotes"] as string;
                tbSettingsNavBar.Text = Application.Current.Resources["EN_MainViewSettings"] as string;
                tbHelpNavBar.Text = Application.Current.Resources["EN_MainViewHelp"] as string;
            }
            else
            {
                tbNotesNavBar.Text = Application.Current.Resources["VA_MainViewDashboard"] as string;
                tbGraphicNavBar.Text = Application.Current.Resources["VA_MainViewDoGraphic"] as string;
                tbExportNotesNavBar.Text = Application.Current.Resources["VA_MainViewExportAllNotes"] as string;
                tbSettingsNavBar.Text = Application.Current.Resources["VA_MainViewSettings"] as string;
                tbHelpNavBar.Text = Application.Current.Resources["VA_MainViewHelp"] as string;
            }
        }
    }
}
