using Common.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interfaces
{
    public interface IGenericService<IdT, T>
    {
        /// <summary>
        /// Retruns a List of an Entity objects
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync(params string[] includes);
        /// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="Id">Entity Id</param>
        /// <returns>
        /// Returns Entity Object
        /// </returns>
        Task<T> GetByIdAsync(IdT Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(IdT Id, params string[] includes);
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
        Task<T> UpdateAsync(T item);
        Task<T[]> UpdateRangeAsync(params T[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<string> DeleteAsync(IdT Id);


        void MarkForDelete(T obj);
        void Attach(object obj);
        void Detach(object obj);
        void SetUnchanged(object obj);
    }
}
