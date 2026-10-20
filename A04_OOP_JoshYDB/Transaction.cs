/*
 * FILE             : Transaction.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 18 2026
 * DESCRIPTION      : C# Source file for a custom exception class.
 *                    Code provided by instructor during demos
 *                    
 */
namespace A04_OOP_JoshYDB
{
    internal class Transaction
    {
        private int accountID;
        private TransactionKind transactionType;
        private decimal amount;

        internal int AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        internal TransactionKind TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }
        internal decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        //constructors
        internal Transaction()
        {
            accountID = 0;
            //default type is deposit (Bank error in your favour!)
            transactionType = TransactionKind.Deposit;
            amount = 0;
        }
        internal Transaction(int accountID, TransactionKind transactionType, decimal amount)
        {
            this.accountID = accountID;
            this.transactionType = transactionType;
            this.amount = amount;
        }


        /*
         *	METHOD  	: ToString
         *	DESCRIPTION	: overriding the toString so that it prints transaction details 
         *	              as specified instead of just the type of object
         *  
         *	
         *	PARAMETERS	: 
         *	
         *	
         *	
         *	RETURNS		: a string :)
         */
        public override string ToString()
        {
            return $"Account ID: {accountID}, Transaction Type: {transactionType}, Amount: {amount:C}";
        }
    }
    //defining deifferent kinds of transactions
    internal enum TransactionKind
    {
        Deposit,
        Withdrawal
    }
}
