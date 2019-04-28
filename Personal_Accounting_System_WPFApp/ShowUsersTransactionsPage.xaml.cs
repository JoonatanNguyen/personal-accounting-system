using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Services;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for ShowUsersTransactionsPage.xaml
    /// </summary>
    public partial class ShowUsersTransactionsPage : Page
    {
        private int userId;
        public ShowUsersTransactionsPage(int _userId)
        {
            InitializeComponent();
            userId = _userId;
        }

        private void UserTodaysTransaction_Click(object sender, RoutedEventArgs e)
        {
            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(userId, TransactionShowOption.Today);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");
            table.Columns.Add("Product Name");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == userId) ? "-" + (double)transaction.Amount/100 : "+" + (double)transaction.Amount/100, transaction.ProductName);
            }

            UsersTransactions.ItemsSource = table.DefaultView;

        }

        private void UserMonthlyTransaction_Click(object sender, RoutedEventArgs e)
        {
            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(userId, TransactionShowOption.Monthly);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");
            table.Columns.Add("Product Name");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == userId) ? "-" + (double)transaction.Amount/100 : "+" + (double)transaction.Amount/100, transaction.ProductName);
            }

            UsersTransactions.ItemsSource = table.DefaultView;
            var sumExpense = transactionService.GetSumExpenses(userId, TransactionShowOption.Monthly) / 100;
            var sumIncome = transactionService.GetSumIncome(userId, TransactionShowOption.Monthly) / 100;
            TotalExpense.Content = sumExpense + " Euro";
            TotalIncome.Content = sumIncome + " Euro";
            TotalBalance.Content = (sumIncome - sumExpense) + " Euro";
        }

        private void UserAnualTransaction_Click(object sender, RoutedEventArgs e)
        {
            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(userId, TransactionShowOption.Anual);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");
            table.Columns.Add("Product Name");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == userId) ? "-" + (double)transaction.Amount/100 : "+" + (double)transaction.Amount/100, transaction.ProductName);
            }

            UsersTransactions.ItemsSource = table.DefaultView;
            var sumExpense = transactionService.GetSumExpenses(userId, TransactionShowOption.Anual) / 100;
            var sumIncome = transactionService.GetSumIncome(userId, TransactionShowOption.Anual) / 100;
            TotalExpense.Content = sumExpense + " Euro";
            TotalIncome.Content = sumIncome + " Euro";
            TotalBalance.Content = (sumIncome - sumExpense) + " Euro";
        }
    }
}
