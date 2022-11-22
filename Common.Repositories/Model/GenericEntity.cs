using System.ComponentModel.DataAnnotations;

namespace Common.Repositories.Model
{
    public abstract class GenericEntity<IdT> : IGenericEntity //<IdT>
    {
        public IdT Id { get; set; }

        [ConcurrencyCheck]
        public int RowVersion { get; set; }
    }
}
