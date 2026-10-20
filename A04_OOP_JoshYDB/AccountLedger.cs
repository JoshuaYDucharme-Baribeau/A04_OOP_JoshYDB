/*
 * FILE             : AccountLedger.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 18 2026
 * DESCRIPTION      : C# Source file for "AccountLedger.cs" containing "AccountLedger" class.
 *                    This class is responsible for handling the list of and methods related to transaction manipulation
 */
namespace A04_OOP_JoshYDB
{
   /*
    *	Class  	    :   AccountLedger
    *	DESCRIPTION	:   manages the collection of accounts,
    *	                called AccountLedger because "Account" VS "Accounts"
    *	                is not distinguishable enough for my taste when being 
    *	                refferred to elsewhere in the code
    */
    internal class AccountLedger
    {
        private List<Account> accounts = new List<Account>();

        internal void AddAccount(Account account)
        {
            accounts.Add(account);
        }
        internal void RemoveAccount(Account account)
        {
            accounts.Remove(account);
        }
        
        //this sort method needs to be added explicitly to the AccountLedger class since it cannot
        //use the default Sort method of a normally instantiated list, possibly due to how I instantiate the list/elements.
        internal void Sort()
        {
            accounts.Sort();
        }

        /*
         *	METHOD  	: GetAccountByAccountID
         *	DESCRIPTION	: returns an account that matches the parameter ID
         *  
         *	
         *	PARAMETERS	: int accountID : an integer of an account id
         *	
         *	
         *	
         *	RETURNS		: Account account   : the first account in the list with an id matching the parameter
         */
        internal Account GetAccountByAccountID(int accountID)
        {
            //allow the account to be null, exception will handle if it is null
            Account? account = accounts.FirstOrDefault(acct => acct.AccountID == accountID);
            if (account == null)
            {
                //throw an exception!
                throw new AccountNotFound($"Account \"{accountID}\" does not exist or cannot be accessed at this time.");
            }
            return account;
        }

        /*
         *	METHOD  	: GetAllAccounts
         *	DESCRIPTION	: returns the list of accounts
         *  
         *	
         *	PARAMETERS	: 
         *	
         *	
         *	
         *	RETURNS		: List<Account> accounts    : the list of accounts
         */
        internal List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
