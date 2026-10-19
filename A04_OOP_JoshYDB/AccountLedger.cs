//header comments
namespace A04_OOP_JoshYDB
{
    //manages the collection of accounts,
    //called AccountLedger because "Account" VS "Accounts"
    //is not distinguishable enough for my taste when being refferred to elsewhere in the code
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
        //use the default Sort method of a normally instantiated list.
        internal void Sort()
        {
            accounts.Sort();
        }

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

        internal List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
