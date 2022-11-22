using Common.Repository.Interfaces;
using System;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using Common.Repositories.Model;

namespace Common.Repositories
{
    public abstract class GenericRepository<IdT, T, Context> : IGenericRepository<IdT, T, Context>
        where T : GenericEntity<IdT>
        where Context : DbContext
    {
        protected DbContext dbContext;
        protected DbSet<T> dbSet;

        protected GenericRepository() { }

        public GenericRepository(IdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        /** GET ALL */
        public async Task<IQueryable<T>> GetAllAsync(params string[] includes)
        {
            var result =  dbContext.Set<T>().AsQueryable();

            foreach (string refObj in includes)
            {
                result = result.Include(refObj);
            }

            return result;
        }

        /** GET BY ID */
        public async Task<T> GetByIdAsync(IdT id, params string[] includes)
        {

            var query = dbContext.Set<T>().AsQueryable();

            foreach (string refObj in includes)
            {
                query = query.Include(refObj);
            }

            T result = await query.Where(GetByIdSelector(id)).FirstAsync();

            return result;
        }

        /** INSERT */
        public async Task<T> InsertAsync(T item)
        {
            await dbContext.Set<T>().AddAsync(item);
            await dbContext.SaveChangesAsync();

            return item;
        }
        public async Task<T[]> InsertRangeAsync(params T[] items)
        {
            await dbContext.Set<T>().AddRangeAsync(items);
            await dbContext.SaveChangesAsync();

            return items;
        }

        /** UPDATE */
        public async Task<int> UpdateAsync(T item)
        {
            dbContext.Set<T>().Update(item);
            var result = await dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateRangeAsync(params T[] items)
        {
            dbContext.Set<T>().UpdateRange(items);
            var result = await dbContext.SaveChangesAsync();
            return result;
        }

        /** DELETE */
        public async Task DeleteAsync(IdT id)
        {
            T item = dbContext.Set<T>().Where(GetByIdSelector(id)).FirstOrDefault();
            await this.DeleteObjectAsync(item);
        }

        private async Task DeleteObjectAsync(T item)
        {
            dbContext.Remove(item);
            await dbContext.SaveChangesAsync();
        }


        public void Attach(object obj)
        {
            throw new NotImplementedException();
        }

        public void Detach(object obj)
        {
            throw new NotImplementedException();
        }

        public void MarkForDelete(T obj)
        {
            throw new NotImplementedException();
        }

        public void SetUnchanged(object obj)
        {
            throw new NotImplementedException();
        }

        /**
         *  ID Selector Expression
         */         
        private static readonly Expression<Func<T, IdT>> _keySelector = u => u.Id;

        private Expression<Func<T, bool>> GetByIdSelector(IdT id)
        {
            var keySelector = _keySelector;
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    keySelector.Body,
                    Expression.Constant(id)
                ),
                keySelector.Parameters.Single()
            );
        }



    }
}
