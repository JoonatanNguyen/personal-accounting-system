using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;

namespace Personal_Accounting_System_WPFApp.Services
{
    class AccountService
    {
        private readonly AccountRepository accountRepository;

        public AccountService()
        {
            accountRepository = new AccountRepository();
        }

        public void CreateAccount(AccountDto account)
        {
            accountRepository.CreatAccount(account);
        }

        public int GetAccountId(int userId)
        {
            return accountRepository.GetAccountId(userId);
        }
    }
}
