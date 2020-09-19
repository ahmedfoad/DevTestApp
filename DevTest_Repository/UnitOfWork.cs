using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevTest_Data.Models;
using DevTest_Repository.Repos;

namespace DevTest_Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestModel _dbContext;
        public AccountRepository _Repository { get; private set; }
        public UnitOfWork(TestModel context)
        {
            _dbContext = context;
            _Repository = new AccountRepository(context);
        }

    

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}


