using System;

namespace Personal_Accounting_System_WPFApp.Dtos
{
    public class TransactionDto
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public string Explanation { get; set; }
        public int PayerAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public int OwnerOfPurchase { get; set; }
        public int CategoryId { get; set; }
        public string PayerName { get; set; }
        public string ReceiverName { get; set; }
        public int PayerId { get; set; }
    }
}
