/*
 * FILE             : Account.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "Account.cs" containing "Account" class.
 *                    Class and object/property definition for an "account"
 */
namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        : Account.cs
     * 
     * DESCRIPTION  : Class and object/property definition for an "account"
     *                Has a child class "SavingsAccount"
     *                
     * 
     */
    internal abstract class Account : IComparable<Account>
    {
        private int accountID;
        private AccountKind accountType;
        private decimal balance;
        private string lastName;
        private string firstName;
        
        //get set for properties
        internal int AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }
        internal AccountKind AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        internal decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        internal string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        internal string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }


        //constructors follow
        internal Account()
        {
            accountID = 0;
            accountType = AccountKind.Savings; //default account is always savings
            balance = 0;

        }
        internal Account(int accountID, AccountKind accountType, decimal balance, string firstName, string lastName)
        {
            this.accountID = accountID;
            this.accountType = accountType;
            this.balance = balance;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //abstract of equals that will be overriden in child class
        public abstract override bool Equals(object obj);

        /*
         *	METHOD  	: CompareTo
         *	DESCRIPTION	: CompareTo method so that the list of accounts can be sorted, even if they aren't Savings Accounts
         *  
         *	
         *	PARAMETERS	: Account account   : a given account to which "this" account should be compared
         *	
         *	
         *	
         *	RETURNS		: int result:   an integer indicating greater than or less than
         */
        public int CompareTo(Account account)
        {
            int result = 1;
            if (account != null)
            {
                //SavingsAccount other_account = (SavingsAccount)account;
                result = this.AccountID.CompareTo(account.AccountID);
            }
            return result;
        }

        /*
         *	METHOD  	: ToString
         *	DESCRIPTION	: overriding the toString so that it prints account details as specified instead of just the type of object
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
            return $"Account ID:\t{AccountID}\nAccount Owner:\t{LastName}, {FirstName}\nAccount Type:\t{AccountType}\nBalance:\t{Balance:C2}";
        }

        //defining kinds of accounts
        internal enum AccountKind
        {
            Savings,
            Chequing //not used but here for future-proofing/as an example
        }

    }
}
