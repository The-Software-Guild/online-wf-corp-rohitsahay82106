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
    public class FreeAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Free)
            {
               response.Success = false;
               response.Message = "Error: a non free account hit the Free Withdraw Rule.  Contact IT";
               return response;
            }

            if (amount < -100)
            {
               response.Success = false;
               response.Message = "Free accounts cannot withdraw more than $100 at a time";
               return response;
            }

            if (amount >= 0)
            { 
               response.Success = false;
               response.Message = "Withdrawal amounts must be negative.";
               return response;
            }

            if ((account.Balance + amount) < 0 )
            {
                response.Success = false;
                response.Message = "Free accounts cannot overdraft!.";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            return response;
            
        }
    }
}
