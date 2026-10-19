/*
 * FILE             : InsufficientFunds.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for a custom exception class.
 *                    Code provided by instructor during demos
 *                    
 */
namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        : InsufficientFunds
     * 
     * DESCRIPTION  : Class for a custom exception
     *                occurs when insufficient funds exist for a transaction
     */
    internal class InsufficientFunds : Exception
    {
        private string message;
        internal string Message
        {
            get { return message; }
            set { message = value; }
        }

        internal InsufficientFunds() { }
        internal InsufficientFunds(string message)
        {
            this.message = message;
        }

        internal InsufficientFunds(string message, Exception innerException) : base(message, innerException)
        {
            this.message = message;
        }

    }
}
