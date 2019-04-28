
using System.Data;
using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Services;

namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for TodaysTransaction.xaml
    /// </summary>
    public partial class TodaysTransaction
    {
        public int userId;
        public TodaysTransaction() { }

        public TodaysTransaction(int _userId)
        {
            InitializeComponent();

            userId = _userId;

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

            TodaysTransactionShow.ItemsSource = table.DefaultView;
        }
    }
}
