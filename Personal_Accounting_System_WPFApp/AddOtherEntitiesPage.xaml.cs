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
    /// Interaction logic for AddOtherEntitiesPage.xaml
    /// </summary>
    public partial class AddOtherEntitiesPage : Page
    {
        public AddOtherEntitiesPage()
        {
            InitializeComponent();
        }

        private void AddNewOtherEntities_Click(object sender, RoutedEventArgs e)
        {
            var otherEntitiesService = new OtherEntitiesService();
            var accountService = new AccountService();

            otherEntitiesService.AddOtherEntities(AddOtherEntitiesName.Text);

            var otherEntitiesId = otherEntitiesService.GetOtherEntitiesId(AddOtherEntitiesName.Text);
            
            accountService.CreateAccount(new AccountDto
            {
                OtherEntitiesId = otherEntitiesId
            });

            ShowOtherEntitiesPage showOtherEntitiesPage = new ShowOtherEntitiesPage();
            NavigationService.Navigate(showOtherEntitiesPage);
        }
    }
}
