/*
 * FILE             : UserInterface.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "UserInterface.cs" containing "UserInterface" class.
 *                    The only place where control and output for the program interface should occur.
 *                    The UI for this application should not ask for any user input as per instructions.
 *                    
 */
namespace A04_OOP_JoshYDB
{
    internal class UserInterface
    {
        //denotes a new test from the test harness has begun by writing formatted lines in the console
        //default param is empty in case the first test was run, second default is if it was the last test
        internal static void DenoteNewTest(string prev_test_msg = "BEGINNING OF TEST HARNESS", string next_test_msg = "END OF TEST HARNESS")
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(("").PadRight(60, 'X')); //prints nothing, padded 50 chars from the right by 'X'
            Console.WriteLine(("").PadLeft( (60 - prev_test_msg.Length) / 2, ' ') + (prev_test_msg) + ("").PadRight( (60-prev_test_msg.Length) / 2, ' '));
            Console.WriteLine(("").PadRight(60, 'X')); //prints nothing, padded 50 chars from the right by 'X'
            Console.WriteLine("\n\n");
            
            Console.WriteLine("\n\n");
            Console.WriteLine(("").PadRight(60, '+')); //prints nothing, padded 50 chars from the right by '+'
            Console.WriteLine(("").PadLeft( (60 - next_test_msg.Length) / 2, ' ') + (next_test_msg) + ("").PadRight( (60-next_test_msg.Length) / 2, ' '));
            Console.WriteLine(("").PadRight(60, '+')); //prints nothing, padded 50 chars from the right by '+'
            Console.WriteLine("\n\n");
        }

        //consider overriding a toString like the demo example
        internal static void show_acct_details(Account acct_shown)
        {
            Console.WriteLine($"Account ID:\t\t{acct_shown.AccountID}");
            Console.WriteLine($"Account Owner:\t{acct_shown.LastName}, {acct_shown.FirstName}");
            Console.WriteLine($"Account Type:\t{acct_shown.AccountType}");
            Console.WriteLine($"Balance:\t\t{acct_shown.Balance}");
        }
        
        
        //consider overriding a toString like the demo example
        //overloaded method for a savings account is unsafe since it is also the parent, changed method name for specifically savings account
        internal static void show_Sav_acct_details(SavingsAccount acct_shown)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Account ID:\t{acct_shown.AccountID}");
            Console.WriteLine($"Account Owner:\t{acct_shown.LastName}, {acct_shown.FirstName}");
            Console.WriteLine($"Account Type:\t{acct_shown.AccountType}");
            Console.WriteLine($"Balance:\t{acct_shown.Balance}");
            if (acct_shown is SavingsAccount)
            {
                Console.WriteLine($"\tWithdrawal Limit:\t{acct_shown.Withdraw_limit}");
                Console.WriteLine($"\tInterest rate:\t{acct_shown.Per_annum}");
            }
            Console.WriteLine("\n");

        }



        //recycled methods from previous assignments below

        /*
         * METHOD       : Block_program
         * 
         * DESCRIPTION  : displays a message and awaits for key input before continuing
         * 
         * PARAMETERS   : string message_prompt : a string that will be written to the console.
         * 
         * RETURNS      : NOTHING
         */
        internal static void Block_program(string message_prompt = "Press any key to continue...") //sets a default param to make the param optional.
        {
            Console.WriteLine(message_prompt);
            Console.ReadKey();
            return;
        }


        /*
         * METHOD       : Display_error_message
         * 
         * DESCRIPTION  : displays an informative error message and calls a method to block the program
         * 
         * PARAMETERS   : string error_message  : [OPTIONAL] A specific error message that will be displayed. 
         *              : string message_prompt : [OPTIONAL] [shadows the parameter it passes itself to] A prompt that will be passed to Block_Program when it is called.
         * 
         * RETURNS      : NOTHING
         */
        internal static void Display_error_message(string error_message = "An error has occurred.", string message_prompt = "Press any key to try again...") //Two default params
        {
            Console.WriteLine("\n\n" + error_message);
            Block_program(message_prompt);
            return;
        }

        /*
         * METHOD       : Display_message
         * 
         * DESCRIPTION  : displays a regular message without blocking the program
         * 
         * PARAMETERS   : string message  : [OPTIONAL] A message that will be displayed. 
         *
         * 
         * RETURNS      : NOTHING
         */
        internal static void Display_message(string message = "No message to display.") //default message for debugging
        {
            Console.WriteLine(message);
            return;
        }
    }
}

