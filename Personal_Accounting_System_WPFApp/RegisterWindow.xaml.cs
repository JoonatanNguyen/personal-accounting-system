using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Services;
using System;
using System.Windows;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow
    {

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userService = new UserService();
                userService.RegisterUser(new UserDto
                {
                    Name = NameRegister.Text,
                    DateOfBirth = DateOfBirthRegister.Text,
                    Email = EmailRegister.Text,
                }, PasswordRegister.Text);
                
                var userHomePage = new UserHomePage(EmailRegister.Text);
                userHomePage.Show();
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
