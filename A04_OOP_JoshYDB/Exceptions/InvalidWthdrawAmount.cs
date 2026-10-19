/*
 * FILE             : InvalidWthdrawAmount.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for a custom exception class.
 *                    
 */
namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        : InvalidWthdrawAmount
     * 
     * DESCRIPTION  : Class for a custom exception
     *                occurs when a withdrawal amount does not fall within the savings account's withdrawal property
     */
    internal class InvalidWthdrawAmount : Exception
    {
        private string message;
        internal string Message
        {
            get { return message; }
            set { message = value; }
        }
        internal InvalidWthdrawAmount() { }
        internal InvalidWthdrawAmount(string message)
        {
            this.message = message;
        }

        internal InvalidWthdrawAmount(string message, Exception innerException) : base(message, innerException)
        {
            this.message = message;
        }
    }
}
