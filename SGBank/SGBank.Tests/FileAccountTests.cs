using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
   [TestFixture]
   public class FileAccountTests
   {
        [TestCase("12345", "Free Customer", 500, AccountType.Free, true)]
        [TestCase("33333", "Premium Customer", 1000, AccountType.Premium, true)]
        [TestCase("31343", "Premium Customer", 91000.54, AccountType.Premium, true)]
        [TestCase("22222", "Basic Customer", 500, AccountType.Basic, true)]
        [TestCase("11456", "Free Customer", 1000, AccountType.Free, true)]
        [TestCase("23222", "Basic Customer", 5000, AccountType.Basic, true)]
        [TestCase("52222", "Basic Customer", 500, AccountType.Basic, false)]
        public void CanLoadAccountFromFile(string accountNumber, string name, decimal balance, AccountType accountType, bool result)
        {
            AccountManager manager = AccountManagerFactory.Create();
            AccountLookupResponse response = manager.LookupAccount(accountNumber);
            Assert.AreEqual(result, response.Success);
            
        }
        
        [TestCase("31343", "Premium Customer", 91000.54, AccountType.Premium, true,0.46,91001)]
        [TestCase("11456", "Free Customer", 1000, AccountType.Free, true,100,1100)]
        [TestCase("23222", "Basic Customer", 5000, AccountType.Basic, true,2000,7000)]
        public void CanDepositAccountFromFile(string accountNumber, string name, decimal balance, AccountType accountType, bool result,decimal deposit,decimal newBalance)
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            AccountDepositResponse response = accountManager.Deposit(accountNumber, deposit);
                       
            Assert.AreEqual(newBalance, response.Account.Balance);
            Assert.AreEqual(result, response.Success);
            
            
        }

        [TestCase("31343", "Premium Customer", 91001.00, AccountType.Premium, true, -0.46, 91000.54)]
        [TestCase("11456", "Free Customer", 1100, AccountType.Free, true, -100, 1000)]
        [TestCase("23222", "Basic Customer", 7000, AccountType.Basic, true, -500, 6500)]
        [TestCase("23222", "Basic Customer", 6500, AccountType.Basic, true, -500, 6000)]
        [TestCase("23222", "Basic Customer", 6000, AccountType.Basic, true, -500, 5500)]
        [TestCase("23222", "Basic Customer", 5500, AccountType.Basic, true, -500, 5000)]
        public void CanWithdrawAccountFromFile(string accountNumber, string name, decimal balance, AccountType accountType, bool result, decimal Withdraw, decimal newBalance)
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            AccountDepositResponse response = accountManager.Withdraw(accountNumber, Withdraw);

            Assert.AreEqual(newBalance, response.Account.Balance);
            Assert.AreEqual(result, response.Success);


        }


    }
}
