using System.Configuration;
using System.Data;
using System.Windows;
using ReadyTasks.Views;

namespace ReadyTasks
{

    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();

                }
            };
        }
    }
}
