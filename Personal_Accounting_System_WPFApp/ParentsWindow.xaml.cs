using System.Windows;
using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Services;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for ParentsWindow.xaml
    /// </summary>
    public partial class ParentsWindow
    {
        public string Email;
        public ParentsWindow(string email)
        {
            InitializeComponent();
            Email = email;

            UserEmail.Content = Email;
        }

        private void CreatePayment_Click(object sender, RoutedEventArgs e)
        {
            ParentHomePage.Content = new CreatePayment();
        }
        private void ViewTodaysTransaction_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            var currentUserId = userRepository.GetUserId(Email);

            ParentHomePage.Content = new TodaysTransaction(currentUserId);
        }
        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            var currentUserId = userRepository.GetUserId(Email);

            ParentHomePage.Content = new ViewReportPage(currentUserId);
        }

        private void ShowKids_Click(object sender, RoutedEventArgs e)
        {
            var userRoleService = new UserRoleService();
            var child = userRoleService.GetUserRole(2);

            ParentHomePage.Content = new ShowKidsTransaction(child);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

    }
}
