using System.ComponentModel.DataAnnotations;

namespace Common.Repositories.Model
{
    public interface IGenericEntity// <out TKey>
    {
         //TKey Id { get; }

        [ConcurrencyCheck]
        int RowVersion { get; set; }
    }

}
