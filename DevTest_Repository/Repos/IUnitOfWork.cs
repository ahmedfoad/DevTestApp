using System;
using System.Threading.Tasks;

namespace DevTest_Repository.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
