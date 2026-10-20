/*
 * FILE             : TransactionLedger.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 18 2026
 * DESCRIPTION      : C# Source file for "TransactionLedger.cs" containing "TransactionLedger" class.
 *                    This class is responsible for handling the list of and methods related to transaction manipulation
 */
namespace A04_OOP_JoshYDB
{

   /*
    * Class  	    :   TransactionLedger
    * DESCRIPTION	:   manages the collection of transactions
    *	                called AccountLedger because "Transaction" VS "Transactions" is not distinguishable enough for my taste
    */
    internal class TransactionLedger
    {
        private List<Transaction> transactions = new List<Transaction>();

        /*
         *	METHOD  	: AddTransaction
         *	DESCRIPTION	: adds a transaction to the list of transactions
         *  
         *	
         *	PARAMETERS	: Transaction a_transaction : a given transaction to add
         *	
         *	
         *	
         *	RETURNS		: VOID NOTHING
         */
        private void AddTransaction(Transaction a_transaction)
        {
            transactions.Add(a_transaction);
        }



        /*
         *	METHOD  	: PostTransaction
         *	DESCRIPTION	: applies a transaction to an account based on the kind of transaction
         *  
         *	
         *	PARAMETERS	: Transaction a_transaction     : a transaction to apply to an account
         *	              AccountLedger all_accounts    : list of accounts
         *	              
         *	
         *	RETURNS		: VOID NOTHING
         */
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
