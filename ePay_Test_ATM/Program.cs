using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ePay_Test_ATM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // initiate the value of notes type
            // and empty list for combantion
            List<int> combanations = new List<int>();
            List<int> billType = new List<int>() { 10, 50, 100 };
            // ask the user to input the amount  which we can replace by an array and loop runs through the test cases
            // I did not like the output of that
            // though I wrote the code to work with either method.

            //Console.WriteLine("How much would you like to withdraw?");
            //Console.Write("Enter Amount: ");
            //// to get and validate the user input
            //int withdraw = GetWithdrawAmount();
            //Change(combanations, billType, 0, 0, withdraw);


            List<int> withdraw = new List<int>(){30,50,60,80,140,230,370,610,980};
            foreach(int amount in withdraw)
            {
                Console.WriteLine("combinations for amount " + amount + " are:");
                Change(combanations, billType, 0, 0, amount);
            }

        }

        static int GetWithdrawAmount()
        {
            bool valid = false;
            int withdrawAmount = Convert.ToInt32(Console.ReadLine());
            while (!valid)
            {
                if (withdrawAmount == 0)
                {
                    Console.WriteLine("enter correct amoount. the amount should not be less than 10€");   
                }
                else if (withdrawAmount < 10)
                {
                    Console.WriteLine("enter correct amoount. the amount should not be less than 10€");
                }
                else if (withdrawAmount % 10 != 0)
                {
                    Console.WriteLine("enter correct amoount. the amount should not be multply by 10");
                }
                else
                {
                    valid = true;
                    break;
                }
                Console.Write("Enter Amount: ");
                withdrawAmount = Convert.ToInt32(Console.ReadLine());
            }
            return withdrawAmount;
        }


        static void Change(List<int> combanations, List<int> billType, int top, int total, int amount)
        {
            // check if are meet the withdraw amount
            if (total == amount)
            {
                Display(combanations, billType);
                return;
            }

            // to check if we did not exceeds the amount
            if (total > amount)
            {
                return;
            }

            // Loop through amounts.
            foreach (int value in billType)
            {
                // add higher or equal amounts.
                if (value >= top)
                {
                    List<int> copy = new List<int>(combanations);
                    copy.Add(value);
                    Change(copy, billType, value, total + value, amount);
                }
            }
        }

        static void Display(List<int> combanations, List<int> billType)
        {
            foreach (int bill in billType)
            {
                int count = combanations.Count(value => value == bill);
                Console.WriteLine("{0}: {1}", bill, count);
            }
            Console.WriteLine();
        }
    }
}