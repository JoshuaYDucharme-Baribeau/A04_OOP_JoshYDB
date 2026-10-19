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

        public override string ToString()
        {
            return $"Account ID: {accountID}, Transaction Type: {transactionType}, Amount: {amount:C}";
        }
    }
    internal enum TransactionKind
    {
        Deposit,
        Withdrawal
    }
}
