using System.Collections.Generic;
using DevTest_Data.Models;

namespace DevTest_Repository.Repos
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetEmployeesByContain(string Search);

    }
}
