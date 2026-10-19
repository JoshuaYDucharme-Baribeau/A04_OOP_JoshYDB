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

        internal Account GetAccountByAccountID(int accountID)
        {
            //allow the account to be null, exception will handle if it is null
            Account? account = accounts.FirstOrDefault(acct => acct.AccountID == accountID);
            if (account == null)
            {
                //throw an exception!
                //throw new AccountNotFoundException($"Account not found: {accountID}");
            }
            return account;
        }

        internal List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
