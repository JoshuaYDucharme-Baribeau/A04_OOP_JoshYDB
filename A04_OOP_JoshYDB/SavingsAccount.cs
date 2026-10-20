/*
 * FILE             : SavingsAccount.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "SavingsAccount.cs", a child class of "Account.cs".
 *                    Child class and object/property definition for a "savings account"
 */
using static A04_OOP_JoshYDB.Account;

namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        :SavingsAccount.cs
     * 
     * DESCRIPTION  : Child class and object/property definition for a "savings account"
     *                is a child class of "Account.cs".
     *                
     * 
     */
    internal class SavingsAccount : Account, IComparable<SavingsAccount>
    {
        private decimal per_annum;
        private decimal withdraw_limit;
        
        internal decimal Per_annum
        {
            get { return per_annum; }
            set { per_annum = value; }
        }
        internal decimal Withdraw_limit
        {
            get { return withdraw_limit; }
            set { withdraw_limit = value; }
        }

        //constructor        
        public SavingsAccount()
        {
            //instead of setting the ammount, per annum, one could call a method to retrieve the most up to date interest rate from the web/bank
            per_annum = 0.045m; //4.5% interest rate
            
            withdraw_limit = 1000m; 
        }


        /*
         *	METHOD  	: GetSumMonthOfInterest
         *	DESCRIPTION	: returns a sum of per-annum interest
         *  
         *	
         *	PARAMETERS	: decimal monthly_low_balance   : a balance with which to calculate the interest (i.e. a principal)
         *	
         *	
         *	
         *	RETURNS		: decimal interest_amount   : a decimal amount, hopefully a lot, unless it is a loan interest
         */
        internal decimal GetSumMonthOfInterest(decimal monthly_low_balance)
        {
            decimal interest_amount;
            interest_amount = (monthly_low_balance * this.Per_annum) / 12;
            return interest_amount;
        }

        /*
         *	METHOD  	: MoneyTransfer
         *	DESCRIPTION	: A method to facilitate a transfer of funds from "this" savings account to another account
         *  
         *	
         *	PARAMETERS	: int receiver_account_id           : account id of receiving account
         *	              decimal transfer_amount           : amount to be transferred
         *	              AccountLedger accounts            : list of accounts
         *	              TransactionLedger transactions    : list of transactions
         *	
         *	
         *	
         *	RETURNS		: VOID NOTHING
         */
        internal void MoneyTransfer(int receiver_account_id, decimal transfer_amount, AccountLedger accounts, TransactionLedger transactions)
        {

            Account receiver_account = accounts.GetAccountByAccountID(receiver_account_id);

            //a redundant null check, just in case
            if (this != null)
            {
                if(receiver_account != null)
                {
                    //remove from sender
                    Transaction send_transaction = new Transaction(this.AccountID, TransactionKind.Withdrawal, transfer_amount);

                    //deposit to receiver
                    Transaction receive_transaction = new Transaction(receiver_account_id, TransactionKind.Deposit, transfer_amount);

                    //post both together, in case there is an exception, they either both post or neither post
                    transactions.PostTransaction(send_transaction, accounts);
                    transactions.PostTransaction(receive_transaction, accounts);
                }
                else
                {
                    throw new AccountNotFound($"Account \"{receiver_account_id}\" does not exist or cannot be accessed at this time.");
                }
            }
            else
            {
                throw new AccountNotFound($"Account \"{this.AccountID}\" does not exist or cannot be accessed at this time.");
            }

            return;
        }


        //override the equals in case two identical Savingsaccounts are created and compared
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj != null && GetType() == obj.GetType())
            {
                Account other_account = (Account)obj;
                result = (this.AccountType == other_account.AccountType) && (this.AccountID == other_account.AccountID);
            }
            return result;
        }

        //override the hashcode return
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        //override the CompareTo so that the list of Savings Accounts can be sorted
        public int CompareTo(SavingsAccount account)
        {
            int result = 1;
            if (account != null)
            {
                result = this.AccountID.CompareTo(account.AccountID);
            }
            return result;
        }


    }



}
