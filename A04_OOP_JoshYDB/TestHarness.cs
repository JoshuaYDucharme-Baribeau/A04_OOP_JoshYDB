/*
 * FILE             : TestHarness.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "TestHarness.cs" containing "TestHarness" class.
 *                    This class is maintained to test the implementation of the application
 */
using System.Security.Principal;

namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        : TestHarness
     * 
     * DESCRIPTION  : This class is responsible for testing the application for the following:
     *                  a. All the properties and methods behave as required
     *                  b. Exceptions work correctly
     *                  c. Account objects can be compared and sorted correctly
     * 
     */
    internal class TestHarness
    {
        internal void StartTest()
        {

            
            //instantiate the classes that will manage collections that will be used across all tests
            //instantiate account ledger, where new accounts will be added
            AccountLedger all_accounts = new AccountLedger();
            //instantiate transactionledger, where transactions are stored
            TransactionLedger all_transactions = new TransactionLedger();

            //using a list of methods to run them in a loop and keep the test harness clean
            //had the idea and searched it, learned how from: https://stackoverflow.com/questions/23437970/how-to-create-a-list-of-methods-then-execute-them
            List<Action> tests_to_run = new List<Action>();
            
            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
            //add all the test methods to the list of Actions (methods) that will be run
            //use a lamda expression to place references to the lists I want as params within the "Action" (method)
            tests_to_run.Add(() => Test00(all_accounts, all_transactions)); //as I understand it, allows the action to be stored instead of called
            tests_to_run.Add(() => Test01(all_accounts, all_transactions));
            tests_to_run.Add(() => Test02(all_accounts, all_transactions));
            tests_to_run.Add(() => Test03(all_accounts, all_transactions));
            tests_to_run.Add(() => Test04(all_accounts, all_transactions));
            tests_to_run.Add(() => Test05(all_accounts, all_transactions));
            tests_to_run.Add(() => Test06(all_accounts, all_transactions));
            tests_to_run.Add(() => Test07(all_accounts, all_transactions));
            tests_to_run.Add(() => Test08(all_accounts, all_transactions));
            tests_to_run.Add(() => Test09(all_accounts, all_transactions));
            tests_to_run.Add(() => Test10(all_accounts, all_transactions));

            //get the amount of tests that wil run
            int max_tests = tests_to_run.Count; 


            //begin the tests by looping through stored methods
            UserInterface.DenoteNewTest(next_test_msg:"TEST 1 BEGINS: Create a savings account");
            for (int test_counter = 0; test_counter < max_tests; test_counter++)
            { 
                try
                {
                    tests_to_run[test_counter]();
                }
                catch (AccountNotFound ex)
                {
                    UserInterface.Display_message($"\nError: Account Not Found.\n\tDetails: {ex.Message}\nThe operation was not complete.\n\n");
                }
                catch (InsufficientFunds ex)
                {
                    UserInterface.Display_message($"\nError: Insufficient Funds.\n\tDetails: {ex.Message}\nThe operation was not complete.\n\n");
                }
                catch (InvalidDepositAmount ex)
                {
                    UserInterface.Display_message($"\nError: Invalid Deposit Amount.\n\tDetails: {ex.Message}\nThe operation was not complete.\n\n");
                }
                catch (InvalidWthdrawAmount ex)
                {
                    UserInterface.Display_message($"\nError: Invalid Withdrawal Amount.\n\tDetails: {ex.Message}\nThe operation was not complete.\n\n");
                }
                catch(Exception ex)
                {
                    UserInterface.Display_message($"Oops, an unespected error occurred. Details below.\n\n{ex.Message}\n\n");
                }

                if (test_counter < (max_tests - 1))
                {
                    UserInterface.DenoteNewTest($"TEST {test_counter + 1} CONCLUDED", $"TEST {test_counter + 2} BEGINS");
                }
                else
                {
                    //final test completed
                    UserInterface.DenoteNewTest(prev_test_msg: $"FINAL TEST ({test_counter + 1}) CONCLUDED");
                }
                
            }

            return;


        }

        /*
         * TESTS TO ADD
         * transfer money from one savings account to another
         */


        //need to pass the account and transaction ledgers in order to use them
        internal void Test00(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            SavingsAccount acct1 = new SavingsAccount();
            acct1.AccountID = 1001;
            acct1.AccountType = Account.AccountKind.Savings;
            acct1.Balance = 1275.83m;
            acct1.LastName = "Richards";
            acct1.FirstName = "Keith";

            all_accounts.AddAccount(acct1);

            //UserInterface.show_Sav_acct_details(acct1);
            UserInterface.Display_message(acct1.ToString());

            //
            return;
        }
        
        internal void Test01(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            SavingsAccount acct2 = new SavingsAccount();
            acct2.AccountID = 1002;
            acct2.AccountType = Account.AccountKind.Savings;
            acct2.Balance = 680.96m;
            acct2.LastName = "Jagger";
            acct2.FirstName = "Mick";

            all_accounts.AddAccount(acct2);

            UserInterface.Display_message("Attempting to display a previously and newly added account.");
            UserInterface.Display_message(("").PadRight(60, '-')); //prints nothing, padded 60 chars from the right by '-'
            UserInterface.Display_message(all_accounts.GetAccountByAccountID(1001).ToString());
            UserInterface.Display_message(("").PadRight(60, '-')); //prints nothing, padded 60 chars from the right by '-'
            UserInterface.Display_message(acct2.ToString());
            UserInterface.Display_message(("").PadRight(60, '-')); //prints nothing, padded 60 chars from the right by '-'

        }

        internal void Test02(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            SavingsAccount acct3 = new SavingsAccount();
            acct3.AccountID = 1003;
            acct3.AccountType = Account.AccountKind.Savings;
            acct3.Balance = 10450.01m;
            acct3.LastName = "Wood";
            acct3.FirstName = "Ronnie";

            all_accounts.AddAccount(acct3);

            UserInterface.Display_message("Attempting to print all accounts in a loop");
            
            foreach(Account account in all_accounts.GetAllAccounts())
            {
                UserInterface.Display_message(("").PadRight(60, '-')); //prints nothing, padded 60 chars from the right by '-'
                UserInterface.Display_message(account.ToString());
            }
            UserInterface.Display_message("\n");

        }

        internal void Test03(AccountLedger all_accounts, TransactionLedger all_transactions)
        {

            UserInterface.Display_message("Attempting transactions\n");
            
            UserInterface.Display_message($"\n\nInitial account:\n{all_accounts.GetAccountByAccountID(1001).ToString()}\n");

            Transaction transaction_alpha = new Transaction(1001, TransactionKind.Withdrawal, 97.50m);
            all_transactions.PostTransaction(transaction_alpha, all_accounts);
            
            UserInterface.Display_message($"Withdrawal from 1001: {transaction_alpha.ToString()}");
            UserInterface.Display_message($"Updated account:\n{all_accounts.GetAccountByAccountID(1001).ToString()}");

            
            UserInterface.Display_message($"\n\nInitial account:\n{all_accounts.GetAccountByAccountID(1002).ToString()}\n");

            Transaction transaction_beta = new Transaction(1002, TransactionKind.Deposit, 1200m);
            all_transactions.PostTransaction(transaction_beta, all_accounts);

            UserInterface.Display_message($"Deposit to 1002: {transaction_beta.ToString()}");
            UserInterface.Display_message($"Updated account:\n{all_accounts.GetAccountByAccountID(1002).ToString()}");

        }

        internal void Test04(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            SavingsAccount acct4 = new SavingsAccount();
            acct4.AccountID = 193;
            acct4.AccountType = Account.AccountKind.Savings;
            acct4.Balance = 405.55m;
            acct4.LastName = "Jimmy";
            acct4.FirstName = "Page";

            all_accounts.AddAccount(acct4);
            
            UserInterface.Display_message("Attempting to sort the accounts by ID\n\nBEFORE SORT");
            
            foreach (Account account in all_accounts.GetAllAccounts())
            {
                UserInterface.Display_message(("").PadRight(60, '-')); //prints nothing, padded 60 chars from the right by '-'
                UserInterface.Display_message(account.ToString());
            }

            all_accounts.Sort();
            UserInterface.Display_message("\nAFTER SORT\n\n");

            foreach (Account account in all_accounts.GetAllAccounts())
            {
                UserInterface.Display_message(("").PadRight(60, '-')); //prints nothing, padded 60 chars from the right by '-'
                UserInterface.Display_message(account.ToString());
            }
            UserInterface.Display_message("\n");

        }

        internal void Test05(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            

            UserInterface.Display_message("Attempting to get the interest rate of an account");

            if (all_accounts.GetAccountByAccountID(1003) is SavingsAccount a_savings_account)
            {
                UserInterface.Display_message($"\n{a_savings_account.ToString()}");
                UserInterface.Display_message
                    (
                        $"\nPer annum interest for Account {a_savings_account.AccountID.ToString()}" +
                        $"\nCalculated from {a_savings_account.Balance:C2}" +
                        $"\nat an interest rate of {(a_savings_account.Per_annum)*100}%" +
                        $"\nInterest sum: {a_savings_account.GetSumMonthOfInterest(a_savings_account.Balance):C2}"
                    );
                UserInterface.Display_message("\n");
            }

        }

        internal void Test06(AccountLedger all_accounts, TransactionLedger all_transactions)
        {

            UserInterface.Display_message("Attempting to an ACCOUNT NOT FOUND Exception");

            
            UserInterface.Display_message("\nSearching for Account 999 (which does not exist)\n");
            UserInterface.Display_message(all_accounts.GetAccountByAccountID(999).ToString());
            
            UserInterface.Display_message("\n");
        }

        internal void Test07(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            UserInterface.Display_message("Attempting to an INSUFFICIENT FUNDS Exception");

            UserInterface.Display_message($"\n\nInitial account:\n{all_accounts.GetAccountByAccountID(1002).ToString()}\n");
            
            UserInterface.Display_message("\nAttempting a withdrawal of $99999.99.\n");
            Transaction transaction_alpha = new Transaction(1002, TransactionKind.Withdrawal, 99999.99m);
                        
            all_transactions.PostTransaction(transaction_alpha, all_accounts);
            
            //will not reach following code due to exception
            UserInterface.Display_message($"Withdrawal from 1002: {transaction_alpha.ToString()}");
            UserInterface.Display_message($"Updated account:\n{all_accounts.GetAccountByAccountID(1001).ToString()}");
        }

        internal void Test08(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            UserInterface.Display_message("Attempting to an INVALID DEPOSIT AMOUNT Exception");

            UserInterface.Display_message($"\n\nInitial account:\n{all_accounts.GetAccountByAccountID(1002).ToString()}\n");
            
            UserInterface.Display_message("\nAttempting a deposit of -999.99.\n");
            Transaction transaction_alpha = new Transaction(1002, TransactionKind.Deposit, -999.99m);
                        
            all_transactions.PostTransaction(transaction_alpha, all_accounts);
            
            //will not reach following code due to exception
            UserInterface.Display_message($"Deposit to 1002: {transaction_alpha.ToString()}");
            UserInterface.Display_message($"Updated account:\n{all_accounts.GetAccountByAccountID(1001).ToString()}");
        }

        internal void Test09(AccountLedger all_accounts, TransactionLedger all_transactions)
        {
            UserInterface.Display_message("Attempting to an INVALID WITHDRAW AMOUNT Exception");

            UserInterface.Display_message($"\n\nInitial account:\n{all_accounts.GetAccountByAccountID(1002).ToString()}\n");
            
            UserInterface.Display_message("\nAttempting a withdrawal of $1005.00.\n");
            Transaction transaction_alpha = new Transaction(1002, TransactionKind.Withdrawal, 1005.00m);
                        
            all_transactions.PostTransaction(transaction_alpha, all_accounts);
            
            //will not reach following code due to exception
            UserInterface.Display_message($"Withdrawal from 1002: {transaction_alpha.ToString()}");
            UserInterface.Display_message($"Updated account:\n{all_accounts.GetAccountByAccountID(1001).ToString()}");
        }

        internal void Test10(AccountLedger all_accounts, TransactionLedger all_transactions)
        {



            UserInterface.Display_message
                (
                    $"\n\nInitial accounts:" +
                    $"\n{all_accounts.GetAccountByAccountID(1002).ToString()}" +
                    $"\n\n{all_accounts.GetAccountByAccountID(193).ToString()}"
                );

            UserInterface.Display_message($"\n\n1002 TRANSFERS $250 TO 193\n");

            if (all_accounts.GetAccountByAccountID(1002) is SavingsAccount a_savings_account)
            {
                a_savings_account.MoneyTransfer(193, 250, all_accounts, all_transactions);
            }
            else
            {
                UserInterface.Display_message("The specified account is not a savings account able to transfer money.");
            }

            UserInterface.Display_message
                (
                    $"\n\nUpdated accounts:" +
                    $"\n{all_accounts.GetAccountByAccountID(1002).ToString()}" +
                    $"\n\n{all_accounts.GetAccountByAccountID(193).ToString()}"
                );


        }
    }
}
