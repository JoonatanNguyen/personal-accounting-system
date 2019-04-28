
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Services;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for CreatePayment.xaml
    /// </summary>
    public partial class CreatePayment : Page
    {
        public string email;

        public CreatePayment(string _email)
        {
            InitializeComponent();

            email = _email;
            var userService = new UserService();
            var accountService = new AccountService();
            var categoryService = new CategoryService();

            var userId = userService.GetUserId(_email);
            var accountId = accountService.GetAccountId(userId);
            AccountId.Content = accountId;

            var categoryList = categoryService.GetAllCategories();
            var table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Category");
            foreach(var category in categoryList)
            {
                table.Rows.Add(category.CategoryId, category.CategoryName);
            }
            CategoryList.ItemsSource = table.DefaultView;
        }

        private void CreatePayment_Click(object sender, RoutedEventArgs e)
        {
            var transactionService = new TransactionService();

            var date = DateTime.Parse(DateInput.SelectedDate.ToString()); 

            transactionService.AddTransaction(new TransactionDto
            {
                Amount = int.Parse(AmountTextBox.Text),
                Date = date,
                ProductName = ProductNameTextBox.Text,
                Explanation = ExplanationTextBox.Text,
                PayerAccount = int.Parse(PayerAccountTextBox.Text),
                ReceiverAccount = int.Parse(ReceiverAccountTextBox.Text),
                OwnerOfPurchase = int.Parse(OwnerOfPurchaseTextBox.Text),
                CategoryId = int.Parse(CategoryTextBox.Text)
            });

            TodaysTransaction todaysTransaction = new TodaysTransaction();
            NavigationService.Navigate(todaysTransaction);
        }
    }
}
