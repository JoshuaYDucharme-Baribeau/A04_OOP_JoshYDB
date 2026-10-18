/*
 * FILE             : SavingsAccount.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "SavingsAccount.cs", a child class of "Account.cs".
 *                    Child class and object/property definition for a "savings account"
 */
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
    internal class SavingsAccount : Account
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


        
        public SavingsAccount()
        {
            //instead of setting the ammount, per annum could call a method to retrieve the most up to date interest rate from the web/bank
            per_annum = 0.045m; //4.5% interest rate
            
            withdraw_limit = 1000m; 
        }

        internal decimal GetSumMonthOfInterest(decimal monthly_low_balance)
        {
            decimal interest_amount;
            interest_amount = (monthly_low_balance * this.Per_annum) / 12;
            return interest_amount;
        }

    }



}
