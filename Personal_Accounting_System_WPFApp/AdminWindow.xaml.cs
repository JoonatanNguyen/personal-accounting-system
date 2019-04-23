using Personal_Accounting_System_WPFApp.Repositories;
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

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow
    {
        public string Email;
        public AdminWindow(string _email)
        {
            InitializeComponent();
            Email = _email;

            UserEmail.Content = Email;
        }

        private void CreatePayment_Click(object sender, RoutedEventArgs e)
        {
            AdminHomePage.Content = new CreatePayment();
        }

        private void ViewTodaysTransaction_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            var currentUserId = userRepository.GetUserId(Email);

            AdminHomePage.Content = new TodaysTransaction(currentUserId);
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            var currentUserId = userRepository.GetUserId(Email);

            AdminHomePage.Content = new ViewReportPage(currentUserId);
        }

        private void ShowUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminHomePage.Content = new ShowUsersTransactions();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
