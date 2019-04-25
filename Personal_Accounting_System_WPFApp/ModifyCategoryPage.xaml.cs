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
    /// Interaction logic for ModifyCategoryPage.xaml
    /// </summary>
    public partial class ModifyCategoryPage : Page
    {
        public int categoryId;
        public ModifyCategoryPage(int _categoryId)
        {
            InitializeComponent();

            categoryId = _categoryId;
        }

        private void ModifyCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categoryService = new CategoryService();
                categoryService.ModifyCategory(new CategoryDto
                {
                    CategoryId = categoryId,
                    CategoryName = ChangeCategoryName.Text,
                    FinancialTypeId = int.Parse(ChangeCategoryFinancialTypeId.Text)
                });
                ShowCategoriesPage showCategoriesPage = new ShowCategoriesPage();
                NavigationService.Navigate(showCategoriesPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void DisableCategory_Click(object sender, RoutedEventArgs e)
        {
            var today = DateTime.Now.ToString();

            try
            {
                var categoryService = new CategoryService();
                categoryService.DisableCategory(new CategoryDto
                {
                    CategoryId = categoryId,
                    DisableTime = DateTime.Parse(today)
                });
                ShowCategoriesPage showCategoriesPage = new ShowCategoriesPage();
                NavigationService.Navigate(showCategoriesPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
