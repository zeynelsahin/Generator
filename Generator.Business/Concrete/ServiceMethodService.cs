using System;
using System.Collections.Generic;
using System.Text;
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

        public ServiceMethod GetByObjectId(string objectId, string profileId)
        {
            return _serviceMethodDal.Get(p => p.ObjectId == objectId && p.ProfileId == profileId);
        }
    }
}