using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class ServiceMethodService : IServiceMethodService
    {
        private readonly IServiceMethodDal _serviceMethodDal;

        public ServiceMethodService(IServiceMethodDal serviceMethodDal)
        {
            _serviceMethodDal = serviceMethodDal;
        }

        public ServiceMethod GetByObjectId(string objectId, string profileId, string classType = null)
        {
            return _serviceMethodDal.Get(p => p.ObjectId == objectId && p.ProfileId == profileId);
        }

        public void Add(ServiceMethod serviceMethod)
        {
            _serviceMethodDal.Add(serviceMethod);
        }

        public void Delete(ServiceMethod serviceMethod)
        {
            _serviceMethodDal.Delete(serviceMethod);
        }
    }
}