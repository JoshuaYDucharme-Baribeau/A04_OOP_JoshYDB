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
                        throw new InvalidDepositAmount($"Deposit amount must be greater than zero: {a_transaction.AccountID}: {a_transaction.Amount:C2}");

                    }
                }
                else if (a_transaction.TransactionType == TransactionKind.Withdrawal)
                {
                    
                    if (account.Balance >= a_transaction.Amount)
                    {
                        //no problem, next check if it is below the withdraw amount
                    }
                    else
                    {
                        throw new InsufficientFunds($"Account \"{a_transaction.AccountID}\" has insufficient funds ({account.Balance:C2}) for withdrawal of ({a_transaction.Amount:C2})");
                    }
                    if(account is SavingsAccount a_savings_account)
                    {
                        if (a_transaction.Amount > a_savings_account.Withdraw_limit)
                        {
                            throw new InvalidWthdrawAmount($"The withdrawal limit of ({a_savings_account.Withdraw_limit:C2}) may not be exceeded. Account ID: ({account.AccountID}).");
                        }
                        else
                        {
                            //no exceptions to throw
                        }
                    }
                        account.Balance -= a_transaction.Amount;
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
