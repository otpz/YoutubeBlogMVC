using YoutubeBlogMVC.Data.Context;
using YoutubeBlogMVC.Data.Repositories.Abstractions;
using YoutubeBlogMVC.Data.Repositories.Concretes;

namespace YoutubeBlogMVC.Data.UnitOfWorks
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _appDbContext.DisposeAsync();
        }

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(_appDbContext);
        }
    }
}
