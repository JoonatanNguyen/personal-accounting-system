using Personal_Accounting_System_WPFApp.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Personal_Accounting_System_WPFApp.Repositories
{
    public enum TransactionShowOption
    {
        Today,
        Monthly,
        Anual
    };
    class TransactionRepository
    {
        public void AddTransaction(TransactionDto transaction)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");

                SqlCommand command = new SqlCommand("INSERT INTO Transactions (Amount, Date, ProductName, Explanation, PayerAccount, ReceiverAccount, OwnerOfPurchase, CategoryId) " +
                    "VALUES (@amount, @date, @product, @explain, @payer, @receiver, @owner, @category)", conn);
                command.Parameters.AddWithValue("@amount", transaction.Amount);
                command.Parameters.AddWithValue("@date", transaction.Date);
                command.Parameters.AddWithValue("@product", transaction.ProductName);
                command.Parameters.AddWithValue("@explain", transaction.Explanation);
                command.Parameters.AddWithValue("@payer", transaction.PayerAccount);
                command.Parameters.AddWithValue("@receiver", transaction.ReceiverAccount);
                command.Parameters.AddWithValue("@owner", transaction.OwnerOfPurchase);
                command.Parameters.AddWithValue("@category", transaction.CategoryId);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<TransactionDto> GetOutcomeTransactions(int userId, TransactionShowOption selectionOption)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
            var transactions = new List<TransactionDto>();
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var today = DateTime.Now.Date.ToString("yyyyMMdd");

            Console.WriteLine(today);

            switch (selectionOption)
            {
                case TransactionShowOption.Today:
                    try
                    {
                        var query = $@"select 
                                        (case 
                                        when receiver.Name is null then otherEntitiesReceiver.EntitiesName 
                                        when otherEntitiesReceiver.EntitiesName is null then receiver.Name
                                        end) as Name,
                                        Transactions.Amount, Transactions.ProductName, Date, sender.UserId from Transactions
                                        left join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                                        left join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                                        left join Users sender on senderAccount.OwnerUsers = sender.UserId
                                        left join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
                                        left join OtherEntities otherEntitiesReceiver on receiverAccount.OtherOwnerEntities = otherEntitiesReceiver.Id
                                        where sender.UserId = {userId} AND cast(Transactions.Date as date) IN ('{today}')";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionDto
                                {
                                    ReceiverName = reader["Name"]?.ToString(),
                                    Amount = int.Parse(reader["Amount"]?.ToString() ?? "0"),
                                    ProductName = reader["ProductName"]?.ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]?.ToString()),
                                    PayerId = int.Parse(reader["UserId"]?.ToString() ?? "0")
                                });
                            }
                        }
                        conn.Close();
                        return transactions;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        return transactions;
                    }
                case TransactionShowOption.Monthly:
                    try
                    {
                        var query = $@"select 
                                    (case 
                                    when receiver.Name is null then otherEntitiesReceiver.EntitiesName 
                                    when otherEntitiesReceiver.EntitiesName is null then receiver.Name
                                    end) as Name,
                                    Transactions.Amount, Transactions.ProductName, Date, sender.UserId 
                                    from Transactions
                                    left join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                                    left join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                                    left join Users sender on senderAccount.OwnerUsers = sender.UserId
                                    left join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
                                    left join OtherEntities otherEntitiesReceiver on receiverAccount.OtherOwnerEntities = otherEntitiesReceiver.Id
                                    where sender.UserId = {userId} AND MONTH(Date) = {currentMonth} AND YEAR(Date) = {currentYear}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionDto
                                {
                                    ReceiverName = reader["Name"]?.ToString(),
                                    Amount = int.Parse(reader["Amount"]?.ToString() ?? "0"),
                                    ProductName = reader["ProductName"]?.ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]?.ToString()),
                                    PayerId = int.Parse(reader["UserId"]?.ToString() ?? "0")
                                });
                            }
                        }
                        conn.Close();
                        return transactions;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        return transactions;
                    }
                case TransactionShowOption.Anual:
                    try
                    {
                        var query = $@"select 
                                        (case 
                                        when receiver.Name is null then otherEntitiesReceiver.EntitiesName 
                                        when otherEntitiesReceiver.EntitiesName is null then receiver.Name
                                        end) as Name,
                                        Transactions.Amount, Transactions.ProductName, Date, sender.UserId 
                                        from Transactions
                                        left join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                                        left join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                                        left join Users sender on senderAccount.OwnerUsers = sender.UserId
                                        left join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
                                        left join OtherEntities otherEntitiesReceiver on receiverAccount.OtherOwnerEntities = otherEntitiesReceiver.Id
                                        where sender.UserId = {userId} AND YEAR(Date) = {currentYear}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionDto
                                {
                                    ReceiverName = reader["Name"]?.ToString(),
                                    Amount = int.Parse(reader["Amount"]?.ToString() ?? "0"),
                                    ProductName = reader["ProductName"]?.ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]?.ToString()),
                                    PayerId = int.Parse(reader["UserId"]?.ToString() ?? "0")
                                });
                            }
                        }
                        conn.Close();
                        return transactions;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        return transactions;
                    }
            }

            return transactions;
        }

        public IEnumerable<TransactionDto> GetIncomeTransactions(int userId, TransactionShowOption selectionOption)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
            var transactions = new List<TransactionDto>();
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var today = DateTime.Now.Date.ToString("yyyyMMdd");

            switch (selectionOption)
            {
                case TransactionShowOption.Today:
                    try
                    {
                        var query = $@"select
                                        (case 
                                        when sender.Name is null then otherEntitiesSender.EntitiesName
                                        when otherEntitiesSender.EntitiesName is null then sender.Name
                                        end) as Name,
                                        Transactions.Amount, Transactions.ProductName, Date, 
                                        (case when sender.UserId is null then 0
                                        when sender.UserId is not null then sender.UserId end) as UserId 
                                        from Transactions
                                        inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                                        inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                                        left join Users sender on senderAccount.OwnerUsers = sender.UserId
                                        left join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
                                        left join OtherEntities otherEntitiesSender on senderAccount.OtherOwnerEntities = otherEntitiesSender.Id
                                        where receiver.UserId = {userId} AND cast(Transactions.Date as date) IN ('{today}')";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionDto
                                {
                                    PayerName = reader["Name"]?.ToString(),
                                    Amount = int.Parse(reader["Amount"]?.ToString() ?? "0"),
                                    ProductName = reader["ProductName"]?.ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]?.ToString()),
                                    PayerId = int.Parse(reader["UserId"]?.ToString() ?? "0")
                                });
                            }
                        }
                        conn.Close();
                        return transactions;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        return transactions;
                    }
                case TransactionShowOption.Monthly:
                    try
                    {
                        var query = $@"select
                                        (case 
                                        when sender.Name is null then otherEntitiesSender.EntitiesName
                                        when otherEntitiesSender.EntitiesName is null then sender.Name
                                        end) as Name,
                                        Transactions.Amount, Transactions.ProductName, Date, 
                                        (case 
                                        when sender.UserId is null then 0
                                        when sender.UserId is not null then sender.UserId end) as UserId 
                                        from Transactions
                                        inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                                        inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                                        left join Users sender on senderAccount.OwnerUsers = sender.UserId
                                        left join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
                                        left join OtherEntities otherEntitiesSender on senderAccount.OtherOwnerEntities = otherEntitiesSender.Id
                                        where receiver.UserId = {userId} AND MONTH(Date) = {currentMonth} AND YEAR(Date) = {currentYear}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionDto
                                {
                                    PayerName = reader["Name"]?.ToString(),
                                    Amount = int.Parse(reader["Amount"]?.ToString() ?? "0"),
                                    ProductName = reader["ProductName"]?.ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]?.ToString()),
                                    PayerId = int.Parse(reader["UserId"]?.ToString() ?? "0")
                                });
                            }
                        }
                        conn.Close();
                        return transactions;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        return transactions;
                    }
                case TransactionShowOption.Anual:
                    try
                    {
                        var query = $@"select
                                        (case 
                                        when sender.Name is null then otherEntitiesSender.EntitiesName
                                        when otherEntitiesSender.EntitiesName is null then sender.Name
                                        end) as Name,
                                        Transactions.Amount, Transactions.ProductName, Date, 
                                        (case 
                                        when sender.UserId is null then 0
                                        when sender.UserId is not null then sender.UserId end) as UserId 
                                        from Transactions
                                        inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                                        inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                                        left join Users sender on senderAccount.OwnerUsers = sender.UserId
                                        left join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
                                        left join OtherEntities otherEntitiesSender on senderAccount.OtherOwnerEntities = otherEntitiesSender.Id
                                        where receiver.UserId = {userId} AND YEAR(Date) = {currentYear}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new TransactionDto
                                {
                                    PayerName = reader["Name"]?.ToString(),
                                    Amount = int.Parse(reader["Amount"]?.ToString() ?? "0"),
                                    ProductName = reader["ProductName"]?.ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]?.ToString()),
                                    PayerId = int.Parse(reader["UserId"]?.ToString() ?? "0")
                                });
                            }
                        }
                        conn.Close();
                        return transactions;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        return transactions;
                    }
            }

            return transactions;
        }
        public int GetSumExpenses(int userId, TransactionShowOption _sumSelection)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            switch(_sumSelection)
            {
                case TransactionShowOption.Monthly:
                    try
                    {
                        var query = $@"Select sum(Amount) as expenseSum from Transactions
                                inner join Accounts ON PayerAccount = Accounts.OwnerUsers
                                inner join Users ON Accounts.OwnerUsers = Users.UserId
                                where Users.UserId = {userId} AND MONTH(Date) = {currentMonth}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return int.Parse(reader["expenseSum"]?.ToString() ?? "0");
                            }
                        }
                        conn.Close();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case TransactionShowOption.Anual:
                    try
                    {
                        var query = $@"Select sum(Amount) as expenseSum from Transactions
                                inner join Accounts ON PayerAccount = Accounts.OwnerUsers
                                inner join Users ON Accounts.OwnerUsers = Users.UserId
                                where Users.UserId = {userId} AND YEAR(Date) = {currentYear}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return int.Parse(reader["expenseSum"]?.ToString() ?? "0");
                            }
                        }
                        conn.Close();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
            return 0;
        }
        public int GetSumIncome(int userId, TransactionShowOption _sumSelection)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            switch(_sumSelection)
            {
                case TransactionShowOption.Monthly:
                    try
                    {
                        var query = $@"Select sum(Amount) as incomeSum from Transactions
                                 inner join Accounts ON ReceiverAccount = Accounts.OwnerUsers
                                 inner join Users ON Accounts.OwnerUsers = Users.UserId
                                 where Users.UserId = {userId} AND MONTH(Date) = {currentMonth}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return int.Parse(reader["incomeSum"]?.ToString() ?? "0");
                            }
                        }
                        conn.Close();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case TransactionShowOption.Anual:
                    try
                    {
                        var query = $@"Select sum(Amount) as incomeSum from Transactions
                                 inner join Accounts ON ReceiverAccount = Accounts.OwnerUsers
                                 inner join Users ON Accounts.OwnerUsers = Users.UserId
                                 where Users.UserId = {userId} AND YEAR(Date) = {currentYear}";

                        conn.Open();
                        var command = new SqlCommand(query, conn);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return int.Parse(reader["incomeSum"]?.ToString() ?? "0");
                            }
                        }
                        conn.Close();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }

            return 0;
        }
    }
}
