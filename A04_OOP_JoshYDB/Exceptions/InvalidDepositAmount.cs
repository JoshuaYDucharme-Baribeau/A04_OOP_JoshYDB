/*
 * FILE             : InvalidDepositAmount.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for a custom exception class.
 *                    
 */
namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        : InvalidDepositAmount
     * 
     * DESCRIPTION  : Class for a custom exception
     *                occurs when a deposit amount is negative
     */
    internal class InvalidDepositAmount : Exception
    {
        private string message;
        internal string Message
        {
            get { return message; }
            set { message = value; }
        }
        internal InvalidDepositAmount() { }
        internal InvalidDepositAmount(string message)
        {
            this.message = message;
        }

        internal InvalidDepositAmount(string message, Exception innerException) : base(message, innerException)
        {
            this.message = message;
        }
    }
}
