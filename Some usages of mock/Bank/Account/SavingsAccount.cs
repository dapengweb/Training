using System;

namespace Account
{
    public class SavingsAccount
    {
        public double CreditAccount(double amount)
        {
            Console.WriteLine("Account credit method invoked .. ");
            double balance = GetBalance();
            balance = balance + amount;
            balance = UpdateBalanceInDB(balance);
            return balance;
        }

        virtual protected double UpdateBalanceInDB(double balance)
        {
            Console.WriteLine("Updated Balance in Database ..");
            return balance;
        }

        virtual public double GetBalance()
        {
            Console.WriteLine("Retrieving account balance from Database ..");
            return 0.00;
        }

    }
}