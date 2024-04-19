using System.Linq.Expressions;
using YoutubeBlogMVC.Core.Entities;

namespace YoutubeBlogMVC.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        // task asenkron bir işlemi temsil eder.
        // <T> bir entity'yi temsil eder, örn -> Article

        // Expression<Func<T, bool>> predicate = null açıklaması;
        // bu bir LINQ sorgusunu karşılayan parametredir. 
        // Fakat burada hiçbir linq filtresi yazılmasa da default null old. için filtrelemeden değer döndürür.
        // Örnek kullanımı var articles = await context.Article.GetAllAsync(x => x.IsActive == true);

        // params Expression<Func<T, object>>[] includeProperties açıklaması;
        // await context.Article.Include(x=>x.Image).GetAllAsync(x => x.IsActive == true) için kullanılır.

        public Task AddAsync(T entity);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByGuidAsync (Guid id);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

    }
}
