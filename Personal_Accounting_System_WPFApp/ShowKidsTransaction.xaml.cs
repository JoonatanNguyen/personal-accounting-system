
using System.Data;
using System.Windows.Controls;
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Services;


namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for ShowKidsTransaction.xaml
    /// </summary>
    public partial class ShowKidsTransaction
    {
        public int childRole;
        public ShowKidsTransaction(int _childRole)
        {
            InitializeComponent();

            childRole = _childRole;

            var userRoleService = new UserRoleService();
            var childList = userRoleService.GetChild();

            kidsListBox.ItemsSource = childList;
        }

        private void KidsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedItem = (UserRoleDto) kidsListBox.SelectedItems[0];
            kidsName.Content = selectedItem.ChildName;
            ChildrenTransactionLabel.Content = $"{selectedItem.ChildName}'s transactions";
        }
        private void Today_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = (UserRoleDto)kidsListBox.SelectedItems[0];
            var childrenId = selectedItem.UserId;

            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(childrenId, TransactionShowOption.Today);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == childrenId) ? "-" + transaction.Amount : "+" + transaction.Amount);
            }

            ChildrenTransaction.ItemsSource = table.DefaultView;
        }

        private void Monthly_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = (UserRoleDto)kidsListBox.SelectedItems[0];
            var childrenId = selectedItem.UserId;

            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(childrenId, TransactionShowOption.Monthly);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == childrenId) ? "-" + transaction.Amount : "+" + transaction.Amount);
            }

            ChildrenTransaction.ItemsSource = table.DefaultView;
        }

        private void Anual_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = (UserRoleDto)kidsListBox.SelectedItems[0];
            var childrenId = selectedItem.UserId;

            var transactionService = new TransactionService();
            var transactions = transactionService.GetTransactions(childrenId, TransactionShowOption.Anual);

            var table = new DataTable();

            table.Columns.Add("Date");
            table.Columns.Add("Name");
            table.Columns.Add("Amount");

            foreach (var transaction in transactions)
            {
                table.Rows.Add(transaction.Date.ToString("d"),
                    string.IsNullOrEmpty(transaction.PayerName) ? transaction.ReceiverName : transaction.PayerName,
                    (transaction.PayerId == childrenId) ? "-" + transaction.Amount : "+" + transaction.Amount);
            }

            ChildrenTransaction.ItemsSource = table.DefaultView;
        }
    }
}
