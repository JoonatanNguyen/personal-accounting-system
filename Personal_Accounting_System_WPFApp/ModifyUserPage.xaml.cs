using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Services;
using System;
using System.Windows.Controls;


namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for EditUserPage.xaml
    /// </summary>
    public partial class ModifyUserPage : Page
    {
        private int userId;
        private DateTime disabledate;
        

        public ModifyUserPage(int _userId)
        {
            InitializeComponent();
            userId = _userId;
        }

        private void DisableUser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var today = DateTime.Now.ToString();
            //DateTime newDate = DateTime.Parse(today);

            var adminService = new AdminService();
            adminService.DisableUser(new UserDto
            {
                UserId = userId,
                DisableTime = DateTime.Parse(today)
            });
        }

        private void Modify_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var adminService = new AdminService();
            //var userData = adminService.SelectUserData(userId);
            //NameBox.Text = "Test";

            //foreach (var data in userData)
            //{
            //    NameBox.Text = data.Name;
            //    BirthBox.Text = data.DateOfBirth;
            //    EmailBox.Text = data.Email;
            //}


            adminService.ModifyUser(new UserDto
            {
                Name = NameBox.Text,
                DateOfBirth = BirthBox.Text,
                Email = EmailBox.Text
            },userId);

            ShowUsersTransactions showuser = new ShowUsersTransactions();
            NavigationService.Navigate(showuser);
        }

    }
}
