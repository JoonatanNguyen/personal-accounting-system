using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == userId) ? "-" + transaction.Amount : "+" + transaction.Amount);
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

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == userId) ? "-" + transaction.Amount : "+" + transaction.Amount);
            }

            UsersTransactions.ItemsSource = table.DefaultView;
        }

        private void UserAnualTransaction_Click(object sender, RoutedEventArgs e)
        {
            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(userId, TransactionShowOption.Anual);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == userId) ? "-" + transaction.Amount : "+" + transaction.Amount);
            }

            UsersTransactions.ItemsSource = table.DefaultView;
        }
    }
}
