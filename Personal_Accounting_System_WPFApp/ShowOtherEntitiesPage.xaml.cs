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
    /// Interaction logic for ShowOtherEntitiesPage.xaml
    /// </summary>
    public partial class ShowOtherEntitiesPage : Page
    {
        public ShowOtherEntitiesPage()
        {
            InitializeComponent();

            var otherEntitiesService = new OtherEntitiesService();
            var otherEntitiesList = otherEntitiesService.GetOtherEntities();

            OtherEntitiesListBox.ItemsSource = otherEntitiesList;
        }

        private void OtherEntitiesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (OtherEntitiesDto)OtherEntitiesListBox.SelectedItems[0];
            var otherEntitiesId = selectedItem.OtherEntitiesId;

        }

        private void AddOtherEntities_Click(object sender, RoutedEventArgs e)
        {
            AddOtherEntitiesPage addOtherEntitiesPage = new AddOtherEntitiesPage();
            NavigationService.Navigate(addOtherEntitiesPage); 
        }

        private void ModifyOtherEntities_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (OtherEntitiesDto)OtherEntitiesListBox.SelectedItems[0];
            var otherEntitiesId = selectedItem.OtherEntitiesId;

            ModifyOtherEntitiesPage modifyOtherEntitiesPage = new ModifyOtherEntitiesPage(otherEntitiesId);
            NavigationService.Navigate(modifyOtherEntitiesPage);
        }
    }
}
