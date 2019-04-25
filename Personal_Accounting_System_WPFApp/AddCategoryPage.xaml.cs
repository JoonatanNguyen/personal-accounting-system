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
    /// Interaction logic for AddCategoryPage.xaml
    /// </summary>
    public partial class AddCategoryPage : Page
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void AddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categoryService = new CategoryService();
                categoryService.AddCategory(new CategoryDto
                {
                    CategoryName = CategoryName.Text,
                    FinancialTypeId = int.Parse(FinancialTypeId.Text)
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
