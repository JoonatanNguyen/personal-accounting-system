
using System.Data;
using System.Windows;
using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Services;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for ViewReportPage.xaml
    /// </summary>
    public partial class ViewReportPage
    {
        public int userId;
        public ViewReportPage(int _userId)
        {
            InitializeComponent();

            userId = _userId;
        }

        private void MonthlyReportShowButton_Click(object sender, RoutedEventArgs e)
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

            ReportShowBox.ItemsSource = table.DefaultView;
        }

        private void AnualReportShowButton_Click(object sender, RoutedEventArgs e)
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

            ReportShowBox.ItemsSource = table.DefaultView;
        }
    }
}
