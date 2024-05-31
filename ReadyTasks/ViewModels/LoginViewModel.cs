using ReadyTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReadyTasks.Repositories;
using ReadyTasks.Views;
using System.Security.Principal;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Permissions;

namespace ReadyTasks.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
            }
        }

        private IUserRepository userRepository;

        // Properties

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // Comands
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteLoginCommand);
        }



        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3
                || !IsValidEmail(Username))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                // Verify the email
                var match = Regex.Match(email, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
                return addr.Address == email && match.Success;
            }
            catch
            {
                return false;
            }
        }

        private void ExecuteLoginCommand(object obj)
        {

            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));

            if (isValidUser)
            {
                UserRepository ur = new UserRepository();
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                _userId = ur.findIdByLogin(new System.Net.NetworkCredential(Username, Password));
                string path = @"./ID.txt";
                if (File.Exists(path))
                {
                    File.SetAttributes(@"./ID.txt", File.GetAttributes(@"./ID.txt") & ~FileAttributes.ReadOnly);
                    File.Delete(path);
                }
                // Crear a file ID.txt and write the id of the user
                File.WriteAllText(path, _userId.ToString());
                // Do it read only
                File.SetAttributes(path, FileAttributes.ReadOnly);
                IsViewVisible = false;
            }
            else
            {
                string language = File.ReadAllText(@"./Language.txt");
                if (language.Equals("es"))
                {
                    ErrorMessage = Application.Current.Resources["LoginViewViewModelErrorLoginEmailOrPasswordWrong"] as string;
                }
                else if (language.Equals("en"))
                {
                    ErrorMessage = Application.Current.Resources["EN_LoginViewViewModelErrorLoginEmailOrPasswordWrong"] as string;
                }
                else
                {
                    ErrorMessage = Application.Current.Resources["VA_LoginViewViewModelErrorLoginEmailOrPasswordWrong"] as string;
                }

            }
        }

        private void ExecuteRegisterCommand(object obj)
        {
            // Read the file of the language
            string language = File.ReadAllText(@"./Language.txt");
            // Comprobe if the user exists and if the email exists
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            var isRegistered = userRepository.GetByMail(Username);
            if (isValidUser)
            {
                // Translation
                if (language.Equals("es"))
                {
                    Debug.WriteLine("Register command user exists");
                    ErrorMessage = Application.Current.Resources["LoginViewViewModelErrorEmailPasswordExists"] as string;
                }
                else if (language.Equals("en"))
                {
                    Debug.WriteLine("Register command user exists");
                    ErrorMessage = Application.Current.Resources["EN_LoginViewViewModelErrorEmailPasswordExists"] as string;
                }
                else
                {
                    Debug.WriteLine("Register command user exists");
                    ErrorMessage = Application.Current.Resources["VA_LoginViewViewModelErrorEmailPasswordExists"] as string;
                }

            }
            else if (isRegistered != null)
            {
                // Translation
                if (language.Equals("es"))
                {
                    Debug.WriteLine("Register command Mail Registered");
                    ErrorMessage = Application.Current.Resources["LoginViewViewModelErrorMailExists"] as string;
                }
                else if (language.Equals("en"))
                {
                    Debug.WriteLine("Register command Mail Registered");
                    ErrorMessage = Application.Current.Resources["EN_LoginViewViewModelErrorMailExists"] as string;
                }
                else
                {
                    Debug.WriteLine("Register command Mail Registered");
                    ErrorMessage = Application.Current.Resources["VA_LoginViewViewModelErrorMailExists"] as string;
                }

            }
            else if (isValidUser == false && isRegistered == null)
            {
                // Create the userModel, add properties and add it to the database. Also create the file ID.txt and write the id of the user.
                // Set LoginView to invisible too.
                UserRepository ur = new UserRepository();
                UserModel user = new UserModel();
                user.id = ur.findMaxId1();
                user.mail = Username;
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential(Username, Password);
                ur.AddUser(user, credential);
                string path = @"./ID.txt";
                // Set the Write property and write the id of the user
                File.SetAttributes(path, FileAttributes.Normal);
                File.WriteAllText(path, user.id.ToString());
                // Read only
                File.SetAttributes(path, FileAttributes.ReadOnly);
                IsViewVisible = false;
                _userId = ur.findIdByLogin(credential);
                // Add user to Normal_Users
                NormalUserRepository nur = new NormalUserRepository();
                int normalUserId = nur.findMaxId1();
                nur.addNormalUser(normalUserId, _userId);

            }
        }

        public int getUserIdGoogle(string mail)
        {
            UserRepository ur = new UserRepository();
            _userId = ur.getUserIdGoogle(mail);
            Debug.WriteLine("View model: " + _userId);
            return _userId;
        }

        private void userIdToAnotherClass(int id)
        {
            HomeView homeView = new HomeView(id);
        }
    }
}
