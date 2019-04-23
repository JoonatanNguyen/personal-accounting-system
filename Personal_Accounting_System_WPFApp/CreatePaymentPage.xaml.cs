
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Services;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Personal_Accounting_System_WPFApp
{
    /// <summary>
    /// Interaction logic for CreatePayment.xaml
    /// </summary>
    public partial class CreatePayment : Page
    {
        public CreatePayment()
        {
            InitializeComponent();
        }

        private void CreatePayment_Click(object sender, RoutedEventArgs e)
        {
            var transactionService = new TransactionService();

            transactionService.AddTransaction(new TransactionDto
            {
                Amount = int.Parse(AmountTextBox.Text),
                Date = new DateTime(2019, 04, 23),
                ProductName = ProductNameTextBox.Text,
                Explanation = ExplanationTextBox.Text,
                PayerAccount = int.Parse(PayerAccountTextBox.Text),
                ReceiverAccount = int.Parse(ReceiverAccountTextBox.Text),
                OwnerOfPurchase = int.Parse(OwnerOfPurchaseTextBox.Text),
                CategoryId = int.Parse(CategoryTextBox.Text)
            });
        }
    }
}
