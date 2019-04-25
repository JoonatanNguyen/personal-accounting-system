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
    /// Interaction logic for ShowCategoriesPage.xaml
    /// </summary>
    public partial class ShowCategoriesPage : Page
    {
        public ShowCategoriesPage()
        {
            InitializeComponent();

            var categoryService = new CategoryService();
            var categoryList = categoryService.GetAllCategories();

            CategoryListBox.ItemsSource = categoryList;
        }

        private void CategoryListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategoryItem = (CategoryDto)CategoryListBox.SelectedItems[0];
            var categoryId = selectedCategoryItem.CategoryId;
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryPage addCategoryPage = new AddCategoryPage();
            NavigationService.Navigate(addCategoryPage);
        }

        private void ModifyCategoryContent_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategoryItem = (CategoryDto)CategoryListBox.SelectedItems[0];
            var categoryId = selectedCategoryItem.CategoryId;

            ModifyCategoryPage modifyCategoryPage = new ModifyCategoryPage(categoryId);
            NavigationService.Navigate(modifyCategoryPage);
        }
    }
}
