using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.Interfaces
{
    public interface IGenericRepository<IdT, T>
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<IQueryable<T>> GetAllAsync(params string[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<T> InsertAsync(T item);
        Task<T[]> InsertRangeAsync(params T[] items);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T item);
        Task<int> UpdateRangeAsync(params T[] items);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(IdT id, params string[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(IdT id);


        void MarkForDelete(T obj);
        void Attach(object obj);
        void Detach(object obj);
        void SetUnchanged(object obj);
    }

    public interface IGenericRepository<IdT, T, DatabaseContext> : IGenericRepository<IdT, T>
    {

    }
}
