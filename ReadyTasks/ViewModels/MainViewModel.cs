using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using ReadyTasks.Models;
using ReadyTasks.Repositories;

namespace ReadyTasks.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        private INoteRepository noteRepository;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowExportViewCommand { get; }
        public ICommand ShowGraphicViewCommand { get; }
        public ICommand ShowSettingsViewCommand { get; }
        public ICommand ShowAdminViewCommand { get; }
        public ICommand ShowHelpViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //LoadCurrentUserData();

            // Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowExportViewCommand = new ViewModelCommand(ExecuteShowExportViewCommand);
            ShowGraphicViewCommand = new ViewModelCommand(ExecuteShowGraphicViewCommand);
            ShowSettingsViewCommand = new ViewModelCommand(ExecuteShowSettingsViewCommand);
            ShowAdminViewCommand = new ViewModelCommand(ExecuteShowAdminViewCommand);
            ShowHelpViewCommand = new ViewModelCommand(ExecuteShowHelpViewCommand);

            // Default view
            ExecuteShowHomeViewCommand(null);


        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = Application.Current.Resources["MainViewDashboard"] as string;
            Icon = IconChar.Home;
        }
        public void ExecuteShowExportViewCommand(object obj)
        {
            CurrentChildView = new ExportViewModel();
            Caption = Application.Current.Resources["MainViewExportAllNotes"] as string;
            Icon = IconChar.ArrowUpFromBracket;
        }
        private void ExecuteShowGraphicViewCommand(object obj)
        {
            CurrentChildView = new GraphicViewModel();
            Caption = Application.Current.Resources["MainViewDoGraphic"] as string;
            Icon = IconChar.PieChart;
        }
        private void ExecuteShowSettingsViewCommand(object obj)
        {
            CurrentChildView = new SettingsViewModel();
            Caption = Application.Current.Resources["MainViewSettings"] as string;
            Icon = IconChar.Tools;
        }
        private void ExecuteShowAdminViewCommand(object obj)
        {
            CurrentChildView = new AdminViewModel();
            Caption = "Admin";
            Icon = IconChar.UserTie;
        }
        private void ExecuteShowHelpViewCommand(object obj)
        {
            CurrentChildView = new HelpViewModel();
            Caption = Application.Current.Resources["MainViewHelp"] as string;
            Icon = IconChar.Question;
        }

    }
}
