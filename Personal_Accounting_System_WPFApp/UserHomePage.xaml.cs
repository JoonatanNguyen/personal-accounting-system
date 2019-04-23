using System.Windows;
using Personal_Accounting_System_WPFApp.Repositories;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage
    {
        private string Email;
        public UserHomePage(string email)
        {
            InitializeComponent();
            Email = email;

            UserEmail.Content = Email;
        }

        private void CreatePayment_Click(object sender, RoutedEventArgs e)
        {
            HomePage.Content = new CreatePayment();
        }
        private void ViewTodaysTransaction_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            var currentUserId = userRepository.GetUserId(Email);

            HomePage.Content = new TodaysTransaction(currentUserId);
        }
        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            var currentUserId = userRepository.GetUserId(Email);

            HomePage.Content = new ViewReportPage(currentUserId);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
