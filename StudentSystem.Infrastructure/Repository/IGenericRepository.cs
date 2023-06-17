using System.Linq.Expressions;

namespace StudentSystem.Infrastructure.Repository
{
    public interface IGenericRepository<TEntity, TKey>
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        IQueryable<TEntity> SelectAll(
            Expression<Func<TEntity, bool>> predicate = null,
            string[] includes = null);
        ValueTask<TEntity> SelectByIdAsync(TKey id);
        ValueTask<TEntity> SelectByIdWithDetailsAsync(
            Expression<Func<TEntity, bool>> expression,
            string[] includes);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<TEntity> DeleteAsync(TEntity entity);
        ValueTask<int> SaveChangesAsync();
    }
}
