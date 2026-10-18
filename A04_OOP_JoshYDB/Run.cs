/*
 * FILE             : Run.cs
 * PROJECT          : Assignment 4
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : October 10 2026
 * DESCRIPTION      : C# Source file for "Run.cs" containing "Run" class.
 *                    This class is responsible for the main logic of the application
 */
namespace A04_OOP_JoshYDB
{
    /*
     * CLASS        : Run
     * 
     * DESCRIPTION  : This class is responsible for the main logic of the application
     * 
     */
    internal class Run
    {
        internal void RunApp()
        {
            //instead of instantiating the test from Program, I do so here so that
            //when the application is no longer being tested, actual runtime logic would be placed here
            //future proofing, though not necessary for the assignment
            TestHarness initialized_test = new TestHarness();
            initialized_test.StartTest();
        }
    }
}
