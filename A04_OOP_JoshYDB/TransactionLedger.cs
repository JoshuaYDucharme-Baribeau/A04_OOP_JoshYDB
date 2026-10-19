//file header
using System.Transactions;

namespace A04_OOP_JoshYDB
{
    //manages the collection of transactions
    //called AccountLedger because "Transaction" VS "Transactions" is not distinguishable enough for my taste
    internal class TransactionLedger
    {
        private List<Transaction> transactions = new List<Transaction>();


        private void AddTransaction(Transaction a_transaction)
        {
            transactions.Add(a_transaction);
        }

        //applies a transaction to an account based on the kind of transaction
        internal void PostTransaction(Transaction a_transaction, AccountLedger accounts)
        {
            Account account = accounts.GetAccountByAccountID(a_transaction.AccountID);
            if (account != null)
            {
                if (a_transaction.TransactionType == TransactionKind.Deposit)
                {
                    if (a_transaction.Amount >= 0)
                    {
                        account.Balance += a_transaction.Amount;
                    }
                    else
                    {
                        //throw new InvalidDepositAmountException($"Deposit amount must be greater than zero: {a_transaction.AccountID}: {a_transaction.Amount}");

                    }
                }
                else if (a_transaction.TransactionType == TransactionKind.Withdrawal)
                {
                    if (account.Balance >= a_transaction.Amount)
                    {
                        account.Balance -= a_transaction.Amount;
                    }
                    else
                    {
                        //throw new InsufficientFundsException("Insufficient funds for withdrawal: {transaction.AccountID}");
                    }
                }

                AddTransaction(a_transaction);
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

    }
}
