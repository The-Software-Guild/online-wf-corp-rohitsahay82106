using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;
using SGBank.Models;

namespace SGBank.Data
{
    public class FileAccountRepository: IAccountRepository
    {
        private readonly string path = @"C:\Users\Rohit\Desktop\SoftwareGuild\Repos\SGBank\SGBank.Data\AccountsList\Accounts.txt";
        
        
        public Account LoadAccount(string AccountNumber)
        {
            bool AccountFound = false;
            Account account = new Account();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                while (((line = reader.ReadLine()) != null) && (!AccountFound))
                {
                    string[] columns = line.Split(',');
                    if (AccountNumber == columns[0])
                    {
                        AccountFound = true;
                        account.AccountNumber = columns[0];
                        account.Name = columns[1];
                        if (decimal.TryParse(columns[2], out decimal balance))
                        {
                            account.Balance = balance;
                        }
                        else
                        {
                            account.Balance = 0;
                        }
                        switch (columns[3])
                        {
                            case "F":
                                account.Type = AccountType.Free;
                                break;
                            case "P":
                                account.Type = AccountType.Premium;
                                break;

                            case "B":
                                account.Type = AccountType.Basic;
                                break;
                        }
                    }
                }
            }   
            
                       
            if (AccountFound)
            {
                return account;
            }
            else
            {
                return null;
            }
            
        }

        public void SaveAccount(Account account)
        {
                        
            string[] AccountListRows = File.ReadAllLines(path);
            
            for (int i=1;i<AccountListRows.Length;i++)
            {
                string[] columns = AccountListRows[i].Split(',');
                if (columns[0]== account.AccountNumber)
                {
                    columns[2] = account.Balance.ToString();
                }
                AccountListRows[i] = string.Join(",", columns);
            }

            File.WriteAllLines(path, AccountListRows);

                        
        }
    }
}
