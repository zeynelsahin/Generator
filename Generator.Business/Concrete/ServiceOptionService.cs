using System.Collections.Generic;
using System.Linq;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class ServiceOptionService : IServiceOptionService
    {
        private readonly IServiceOptionDal _serviceOptionDal;

        public ServiceOptionService(IServiceOptionDal serviceOptionDal)
        {
            _serviceOptionDal = serviceOptionDal;
        }

        public List<string> GetServiceId()
        {
            return _serviceOptionDal.GetAll().Where(p => p.DomainId == "UXLocal").Select(option => option.ServiceId)
                .ToList();
        }

        public List<ServiceOption> GetAll()
        {
            return _serviceOptionDal.GetAll().ToList();
        }
    }
}