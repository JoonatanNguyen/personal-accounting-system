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
    /// Interaction logic for ModifyOtherEntitiesPage.xaml
    /// </summary>
    public partial class ModifyOtherEntitiesPage : Page
    {
        public int otherEntitiesId;

        public ModifyOtherEntitiesPage(int _otherEntitiesId)
        {
            InitializeComponent();
            otherEntitiesId = _otherEntitiesId;
        }

        private void DisableOtherEntities_Click(object sender, RoutedEventArgs e)
        {
            var today = DateTime.Now.ToString();

            var otherEntitiesService = new OtherEntitiesService();
            otherEntitiesService.DisableOtheEntities(new OtherEntitiesDto
            {
                DisableTime = DateTime.Parse(today),
                OtherEntitiesId = otherEntitiesId
            });

            ShowOtherEntitiesPage showOtherEntitiesPage = new ShowOtherEntitiesPage();
            NavigationService.Navigate(showOtherEntitiesPage);
        }

        private void ModifyExistingOtherEntities_Click(object sender, RoutedEventArgs e)
        {
            var otherEntitiesService = new OtherEntitiesService();
            otherEntitiesService.ModifyOtherEntities(new OtherEntitiesDto
            {
                OtherEntitiesName = ModifyOtherEntitiesName.Text,
                OtherEntitiesId = int.Parse(ModifyOtherEntitiesId.Text)
            });

            ShowOtherEntitiesPage showOtherEntitiesPage = new ShowOtherEntitiesPage();
            NavigationService.Navigate(showOtherEntitiesPage);
        }
    }
}
