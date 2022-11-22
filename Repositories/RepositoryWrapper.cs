using DataModel;
using Repositories.Interfaces;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TrefBlockDbContext _dbContext;

        public RepositoryWrapper(TrefBlockDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
