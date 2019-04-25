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
                        var query = $@"select receiver.Name, Transactions.Amount, Date, sender.UserId from Transactions
                            inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                            inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                            inner join Users sender on senderAccount.OwnerUsers = sender.UserId
                            inner join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
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
                        var query = $@"select receiver.Name, Transactions.Amount, Date, sender.UserId from Transactions
                            inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                            inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                            inner join Users sender on senderAccount.OwnerUsers = sender.UserId
                            inner join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
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
                        var query = $@"select receiver.Name, Transactions.Amount, Date, sender.UserId from Transactions
                            inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                            inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                            inner join Users sender on senderAccount.OwnerUsers = sender.UserId
                            inner join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
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
                        var query = $@"select sender.Name, Transactions.Amount, Date, sender.UserId from Transactions
                            inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                            inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                            inner join Users sender on senderAccount.OwnerUsers = sender.UserId
                            inner join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
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
                        var query = $@"select sender.Name, Transactions.Amount, Date, sender.UserId from Transactions
                            inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                            inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                            inner join Users sender on senderAccount.OwnerUsers = sender.UserId
                            inner join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
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
                        var query = $@"select sender.Name, Transactions.Amount, Date, sender.UserId from Transactions
                            inner join Accounts senderAccount on Transactions.PayerAccount = senderAccount.Id
                            inner join Accounts receiverAccount on Transactions.ReceiverAccount = receiverAccount.Id
                            inner join Users sender on senderAccount.OwnerUsers = sender.UserId
                            inner join Users receiver on receiverAccount.OwnerUsers = receiver.UserId
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
    }
}
