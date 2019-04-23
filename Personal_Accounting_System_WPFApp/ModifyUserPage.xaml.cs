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
    }
}
