/*
 * FILE             : AccountNotFound.cs
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
     * CLASS        : AccountNotFound
     * 
     * DESCRIPTION  : Class for a custom exception
     *                occurs when a specified account does not exist
     */
    internal class AccountNotFound : Exception
    {
        private string message;
        internal string Message
        {
            get { return message; }
            set { message = value; }
        }
        internal AccountNotFound() { }
        internal AccountNotFound(string message)
        {
            this.message = message;
        }

        internal AccountNotFound(string message, Exception innerException) : base(message, innerException)
        {
            this.message = message;
        }
    }
}
