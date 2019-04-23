using Personal_Accounting_System_WPFApp.Services;
using System;
using System.Windows;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userService = new UserService();
                var loginStatus = userService.LoginUser(EmailLogin.Text, PasswordLogin.Text);
                var parentsRole = userService.IsParents(EmailLogin.Text);
                var adminRole = userService.IsAdmin(EmailLogin.Text);

                if (loginStatus)
                {
                    if (adminRole)
                    {
                        AdminWindow adminWindow = new AdminWindow(EmailLogin.Text);
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        if (parentsRole)
                        {
                            ParentsWindow parentHomeWindow = new ParentsWindow(EmailLogin.Text);
                            parentHomeWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            UserHomePage userHomeWindow = new UserHomePage(EmailLogin.Text);
                            userHomeWindow.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    LoginStatusLabel.Content = "Wrong Email or Password.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RegisterRedirectButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
