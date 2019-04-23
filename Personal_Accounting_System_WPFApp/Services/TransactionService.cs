using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;

namespace Personal_Accounting_System_WPFApp.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository transactionRepository;
        
        public TransactionService()
        {
            transactionRepository = new TransactionRepository();
        }

        public void AddTransaction(TransactionDto transaction)
        {
            transactionRepository.AddTransaction(transaction);
        }

        public IEnumerable<TransactionDto> GetTransactions(int userId, TransactionShowOption selectionOption)
        {
            var incomeTransaction = transactionRepository.GetIncomeTransactions(userId, selectionOption);
            var outcomeTransaction = transactionRepository.GetOutcomeTransactions(userId, selectionOption);

            return incomeTransaction.Concat(outcomeTransaction);
        }
    }
}
