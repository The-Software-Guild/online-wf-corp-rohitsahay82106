﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: a non Basic account hit the Basic Withdraw Rule.  Contact IT";
                return response;
            }

            if (amount < -500)
            {
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500 at a time";
                return response;
            }

            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative.";
                return response;
            }

            if ((account.Balance + amount) < -100)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit!";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            if (account.Balance < 0)    //Deduct overdraft fee of $10 if new balance is negative 
            {
                account.Balance -= 10;
            }
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            return response;
        }
    }
}
