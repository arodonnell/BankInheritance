using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankAccount
    {
        public string AccountHolder { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountHolder, string sortCode, string accountNumber, decimal balance)
        {
            AccountHolder = accountHolder;
            SortCode = sortCode;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", AccountNumber, AccountHolder);
        }

        public virtual string GetDetail()
        {
            return string.Format("{0}\n{1}\n{2}\n{3:C}", AccountHolder, SortCode, AccountNumber, Balance);
        }
    }//end of class

    class SavingsAccount : BankAccount
    {
        public decimal Rate { get; set; }

        public SavingsAccount
            (string accountHolder, string sortCode, string accountNumber, decimal balance, decimal rate)
            : base (accountHolder, sortCode, accountNumber, balance)
        {
            Rate = rate;
        }


        public override string GetDetail()
        {
            return base.GetDetail() + string.Format("\n{0:P}", Rate);
        }

    }//end of class
}
