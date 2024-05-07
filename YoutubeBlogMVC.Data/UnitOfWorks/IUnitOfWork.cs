
using YoutubeBlogMVC.Core.Entities;
using YoutubeBlogMVC.Data.Repositories.Abstractions;

namespace YoutubeBlogMVC.Data.UnitOfWorks   
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
