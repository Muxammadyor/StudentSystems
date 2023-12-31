﻿
using Microsoft.EntityFrameworkCore;
using StudentSystem.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace StudentSystem.Infrastructure.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
    where TEntity : class
    {
        private readonly AppDbContext appDbContext;

        public GenericRepository(AppDbContext appDbContext) =>
            this.appDbContext = appDbContext;

        public async ValueTask<TEntity> InsertAsync(
            TEntity entity)
        {
            var entityEntry = await this.appDbContext
                .Set<TEntity>()
                .AddAsync(entity);

            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }


        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null)
        {
            IQueryable<TEntity> query = appDbContext.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }


            return query;
        }



        public async ValueTask<TEntity> SelectByIdWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes = null)
        {
            IQueryable<TEntity> entities = this.SelectAll();

            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }

            return await entities.FirstOrDefaultAsync(expression);
        }



        public async ValueTask<TEntity> SelectByIdAsync(TKey id) =>
            await this.appDbContext.Set<TEntity>().FindAsync(id);





        public async ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            var entityEntry = this.appDbContext
                .Update<TEntity>(entity);

            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<TEntity> DeleteAsync(TEntity entity)
        {
            var entityEntry = this.appDbContext
                .Set<TEntity>()
                .Remove(entity);

            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<int> SaveChangesAsync() =>
            await this.appDbContext
                .SaveChangesAsync();

    }
}
