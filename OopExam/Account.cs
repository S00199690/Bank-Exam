using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopExam
{
    abstract class Account
    {
          public string FirstName { get; set; }

          public string LastName { get; set; }
          public double Balance { get; set; }

          public string InterestDate { get; set; }

          public int AccountNumber { get; set; }

          //Account constructor
          public Account(string firstname, string lastName, double balance, string interestDate, int accountNumber)
          {
            FirstName = firstname;
            LastName = lastName;
            Balance = balance;
            InterestDate = interestDate;
            AccountNumber = accountNumber;
          }

          public void Deposit(int deposit)
          {
            Balance += deposit;
          }

          public void WithDraw(int withdraw)
          {
            Balance -= withdraw;
          }

          //abstract interest method
          public abstract double CalculateInterest();

        }

        //Current Account class
        class CurrentAccount : Account
        {
            //InterestRate property
            public int InterestRate { get; set; }

            //overrides the abstract method in the base class and returns interest for current account
            public override double CalculateInterest()
            {
                return Balance * InterestRate;
            }

            //current account constructor which inherits base class constructor
            public CurrentAccount(string firstname, string lastname, double balance, string interestDate, int accountNumber) : base(firstname, lastname, balance, interestDate, accountNumber)
            {
                InterestRate = 3;
            }

            //ToString method that formats the current account output into a string
            public override string ToString()
            {
                return string.Format($"{AccountNumber}, {LastName}, {FirstName}");
            }

        }

        //savings account class
        class SavingsAccount : Account
        {
        //savings account properties
        public int InterestRate { get; set; }

        //overrides the abstract method in the base class and returns interest for savings account
        public override double CalculateInterest()
            {
                return Balance * 6;
            }

            //savings account constructor that inherits base class constructor
            public SavingsAccount(string firstname, string lastname, double balance, string interestDate, int accountNumber) : base(firstname, lastname, balance, interestDate, accountNumber)
            {
                InterestRate = 6;
            }

            //ToString method that formats the savings account output into a string
            public override string ToString()
            {
                return string.Format($"{AccountNumber}, {LastName}, {FirstName}");
            }

        }




    }
