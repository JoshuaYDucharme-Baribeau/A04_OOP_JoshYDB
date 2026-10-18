/*
 * FILE             : TestHarness.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "TestHarness.cs" containing "TestHarness" class.
 *                    This class is maintained to test the implementation of the application
 */
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
            //using a list of methods to run them in a loop and keep the test harness clean
            //https://stackoverflow.com/questions/23437970/how-to-create-a-list-of-methods-then-execute-them
            List<Action> tests_to_run = new List<Action>();
            tests_to_run.Add(Test00);

            int max_tests = tests_to_run.Count; 
            //begin the first test
            UserInterface.DenoteNewTest(next_test_msg:"TEST 1 BEGINS: Create a savings account");
            for(int test_counter = 0; test_counter < max_tests; test_counter++)
            {
                tests_to_run[test_counter]();
                if(test_counter < (max_tests-1))
                {
                    UserInterface.DenoteNewTest($"TEST {test_counter+1} CONCLUDED", $"TEST {test_counter+2} BEGINS");
                }
                else
                {
                    //final test completed
                    UserInterface.DenoteNewTest(prev_test_msg:$"FINAL TEST ({test_counter+1}) CONCLUDED");
                }
            }


            return;


        }

        internal void Test00()
        {
            SavingsAccount acct1 = new SavingsAccount();
            acct1.AccountID = 1001;
            acct1.AccountType = Account.AccountKind.Savings;
            acct1.Balance = 1275.83m;
            acct1.LastName = "Richards";
            acct1.FirstName = "Keith";

            UserInterface.show_Sav_acct_details(acct1);


            //
            return;
        }

    }
}
