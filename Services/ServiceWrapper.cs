using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IRepositoryWrapper _repository;

        public ServiceWrapper(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

    }
}
