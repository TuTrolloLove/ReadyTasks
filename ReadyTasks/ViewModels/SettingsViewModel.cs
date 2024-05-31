using ReadyTasks.Models;
using ReadyTasks.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ReadyTasks.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private INoteRepository _noteRepository;
        private IUserRepository _userRepository;
        private INormalUserRepository _normalUserRepository;
        public SettingsViewModel()
        {
            _noteRepository = new NoteRepository();
            _userRepository = new UserRepository();
            _normalUserRepository = new NormalUserRepository();
        }

        public void deleteAllUser(int userId)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                // If the user is an admin
                if (_userRepository.isAdmin(userId))
                {
                    // Message can't delete account
                    MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBErrorAdminText"] as string, "Error", MessageBoxButton.OK);
                    return;
                }
                else
                {
                    // Confirmation MessageBox
                    if (MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountWarningText"] as string,
                        System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountWarningCaption"] as string,
                        MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (_noteRepository.deleteAllNotes(userId))
                        {
                            if (_normalUserRepository.deleteNormalUser(userId))
                            {
                                if (_userRepository.Remove(userId))
                                {
                                    MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountOKText"] as string,
                                        System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountOKCaption"] as string,
                                        MessageBoxButton.OK, MessageBoxImage.Information);

                                    // Finish the application
                                    Application.Current.Shutdown();
                                }
                            }
                            else
                            {
                                MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountError"] as string, "Error", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountError"] as string, "Error", MessageBoxButton.OK);
                        }

                    }
                }
            }
            else if (language.Equals("en"))
            {
                // If the user is an admin
                if (_userRepository.isAdmin(userId))
                {
                    // Message can't delete account
                    MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBErrorAdminText"] as string, "Error", MessageBoxButton.OK);
                    return;
                }
                else
                {
                    // Confirmation MessageBox
                    if (MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountWarningText"] as string,
                                               System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountWarningCaption"] as string,
                                                                      MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (_noteRepository.deleteAllNotes(userId))
                        {
                            if (_normalUserRepository.deleteNormalUser(userId))
                            {
                                if (_userRepository.Remove(userId))
                                {
                                    MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountOKText"] as string,
                                                                               System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountOKCaption"] as string,
                                                                                                                      MessageBoxButton.OK, MessageBoxImage.Information);

                                    // Finish the application
                                    Application.Current.Shutdown();
                                }
                            }
                            else
                            {
                                MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountError"] as string, "Error", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountError"] as string, "Error", MessageBoxButton.OK);
                        }

                    }
                }
            }
            else
            {
                // If the user is an admin
                if (_userRepository.isAdmin(userId))
                {
                    // Message can't delete account
                    MessageBox.Show(System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBErrorAdminText"] as string, "Error", MessageBoxButton.OK);
                    return;
                }
                else
                {
                    // Confirmation MessageBox
                    if (MessageBox.Show(System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountWarningText"] as string,
                                               System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountWarningCaption"] as string,
                                                                      MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (_normalUserRepository.deleteNormalUser(userId))
                        {
                            if (_userRepository.Remove(userId))
                            {
                                MessageBox.Show(System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountOKText"] as string,
                                                                           System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountOKCaption"] as string,
                                                                                                                  MessageBoxButton.OK, MessageBoxImage.Information);

                                // Finish the application
                                Application.Current.Shutdown();
                            }
                        }
                        else
                        {
                            MessageBox.Show(System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountError"] as string, "Error", MessageBoxButton.OK);
                        }
                    }




                }
            }
        }
        public void deleteAllNotes(int userId)
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {
                // Confirmation MessageBox
                if (MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountWarningText"] as string,
                        System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllUserTBDeleteAccountWarningCaption"] as string,
                        MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (_noteRepository.deleteAllNotesOnly(userId))
                    {

                        MessageBox.Show(System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllNotesTBTextOK"] as string,
                            System.Windows.Application.Current.Resources["SettingsViewModelDeleteAllNotesTBCaptionOK"] as string,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else if (language.Equals("en"))
            {
                // Confirmation MessageBox
                if (MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountWarningText"] as string,
                                           System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllUserTBDeleteAccountWarningCaption"] as string,
                                                                  MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (_noteRepository.deleteAllNotesOnly(userId))
                    {

                        MessageBox.Show(System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllNotesTBTextOK"] as string,
                                                       System.Windows.Application.Current.Resources["EN_SettingsViewModelDeleteAllNotesTBCaptionOK"] as string,
                                                                                  MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                // Confirmation MessageBox
                if (MessageBox.Show(System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountWarningText"] as string,
                                           System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllUserTBDeleteAccountWarningCaption"] as string,
                                                                  MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (_noteRepository.deleteAllNotesOnly(userId))
                    {

                        MessageBox.Show(System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllNotesTBTextOK"] as string,
                                                       System.Windows.Application.Current.Resources["VA_SettingsViewModelDeleteAllNotesTBCaptionOK"] as string,
                                                                                  MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
    }
}

