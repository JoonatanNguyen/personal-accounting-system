using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userService = new UserService();
                var accountService = new AccountService();

                userService.RegisterUser(new UserDto
                {
                    Name = addName.Text,
                    DateOfBirth = addDateOfBirth.Text,
                    Email = addEmail.Text,
                }, addPassword.Text);

                ShowUsersTransactions showUserTransactions = new ShowUsersTransactions();
                NavigationService.Navigate(showUserTransactions);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
