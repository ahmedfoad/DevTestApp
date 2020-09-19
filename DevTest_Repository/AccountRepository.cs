using System;
using System.Collections.Generic;
using System.Text;
using DevTest_Data.Models;
using DevTest_Repository.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace DevTest_Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly TestModel _dbContext;

        public AccountRepository(TestModel context) : base(context)
        {
            _dbContext = context;

        }
        public IEnumerable<Account> GetEmployeesByContain(string Search)
        {
            var items = _dbContext.Accounts.Where(a => a.ACC_Parent.Contains(Search)).ToList();
            return items;
        }
        public IEnumerable<Account> GetAccountAll()
        {
            var items = _dbContext.Accounts.Where(a => a.ACC_Parent == null).ToList();

            foreach (var item in items)
            {
                item.Balance = item.Balance ?? 0;
                var childAccounts = _dbContext.Accounts
                    .Where(a => a.ACC_Parent == item.Acc_Number)
                   .ToList();

                // Sum first node
                if (childAccounts != null && childAccounts.Count > 0)
                {
                    item.Balance += childAccounts.Select(a => (decimal?)a.Balance).Sum() ?? 0;
                }

                //sum evey chield node
                foreach (var child in childAccounts)
                {
                    item.Balance += Sum_Child(child);
                }

            }
            return items;
        }

        private decimal Sum_Child(Account account)
        {
            decimal balance = 0;
            var childAccounts = _dbContext.Accounts
                .Where(a => a.ACC_Parent == account.Acc_Number)
                .ToList();

            if (childAccounts != null && childAccounts.Count > 0)
            {
                //sum every child node
                foreach (var child in childAccounts)
                {
                    balance += Sum_Child(child);
                }
                balance += childAccounts.Select(a => (decimal?)a.Balance).Sum() ?? 0;
                return balance;
            }
            return 0;
        }

        public string GetAccountAll_Text(string Acc_Number)
        {


            var item = _dbContext.Accounts.FirstOrDefault(a => a.Acc_Number == Acc_Number);
            
            item.Balance = item.Balance ?? 0;
            var childAccounts = _dbContext.Accounts
                .Where(a => a.ACC_Parent == item.Acc_Number)
                .Include(a => a.Accounts1)
                .ToList();



            //sum evey chield node
            string message = "";
            
            foreach (var child in childAccounts)
            {
                message += "Account :" + item.Acc_Number.Trim() + "-";
                message += child.Acc_Number.Trim();
                message += Sum_Child_Text(child.Accounts1.ToList());
                decimal ChildNodes = Sum_ChildNodes(child.Accounts1.ToList());
                decimal Balance = child.Balance ?? 0;
                item.Balance = Balance + ChildNodes;
                message += " = " + (item.Balance ?? default(decimal)).ToString("#") + " \n ";
            }

            return message;
        }
        private string Sum_Child_Text(List<Account> childAccounts)
        {
            string message = "";


            if (childAccounts.Count > 0)
            {
                //sum every child node
                foreach (var child in childAccounts)
                {
                    message += "-" + child.Acc_Number.Trim() + Sum_Child_Text(child.Accounts1.ToList());
                    
                }

                return message;
            }
            return "";
        }

        private decimal Sum_ChildNodes(List<Account> childAccounts)
        {

            decimal balance = 0;
            if (childAccounts.Count > 0)
            {
                //sum every child node
                foreach (var child in childAccounts)
                {
                    balance += child.Balance ?? 0;
                    balance += Sum_ChildNodes(child.Accounts1.ToList());
                }

              
                return balance;
            }
            return 0;
        }
    }
}

