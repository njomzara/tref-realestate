using Common.Repository.Interfaces;
using Common.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Common.Service
{

    public class GenericService<IdT, T, RepositoryT> : IGenericService<IdT, T>
        where RepositoryT : IGenericRepository<IdT, T>
        where T : new()
    {

        protected RepositoryT repository;

        public GenericService(RepositoryT repository)
        {
            this.repository = repository;
        }

        /** GET ALL */
        public async Task<List<T>> GetAllAsync()
        {
            return await GetAllAsync(new string[0]);
        }

        public async Task<List<T>> GetAllAsync(params string[] includes)
        {
            var query = await repository.GetAllAsync(includes);
            return query.ToList();
        }

        /** GET BY ID */
        public async Task<T> GetByIdAsync(IdT Id, params string[] includes)
        {
            T result = await repository.GetByIdAsync(Id, includes);
            return result;
        }

        public async Task<T> GetByIdAsync(IdT Id)
        {
            return await GetByIdAsync(Id, new string[0]);
        }

        /** INSERT */
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                T result = new T();
                using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await repository.InsertAsync(item);
                    ts.Complete();
                    ts.Dispose();
                }

                return result;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task<T[]> InsertRangeAsync(params T[] items)
        {
            try
            {

                T[] results = items;
                using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await repository.InsertRangeAsync(items);
                    ts.Complete();
                    ts.Dispose();
                }

                return items;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }
        /** UPDATE */
        public async Task<T> UpdateAsync(T item)
        {
            try
            {

                T result = item;
                using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await repository.UpdateAsync(item);
                    ts.Complete();
                    ts.Dispose();
                }

                return result;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }
        public async Task<T[]> UpdateRangeAsync(params T[] items)
        {
            try
            {

                T[] results = items;
                using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await repository.UpdateRangeAsync(items);
                    ts.Complete();
                    ts.Dispose();
                }

                return results;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        /** DELETE */
        public async Task<string> DeleteAsync(IdT Id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await repository.DeleteAsync(Id);
                    ts.Complete();
                }

                return "Ok";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
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
        }

        public void SetUnchanged(object obj)
        {
        }

        #region IGenericService Members

    }
    #endregion
}
