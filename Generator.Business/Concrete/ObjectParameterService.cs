using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class ObjectParameterService : IObjectParameterService
    {
        private readonly IObjectParameterDal _objectParameterDal;

        public ObjectParameterService(IObjectParameterDal objectParameterDal)
        {
            _objectParameterDal = objectParameterDal;
        }

        public void Add(ObjectParameter objectParameter)
        {
            _objectParameterDal.Add(objectParameter);
        }

        public string FindParameterType(string parameterName)
        {
            var result=_objectParameterDal.GetAll().LastOrDefault(p=>p.ParameterId==parameterName);
            return result!=null? result.DataType:null;
        }

        public List<ObjectParameter> GetAllByObjectId(string objectId)
        {
            var result = _objectParameterDal.GetAll(p => p.ObjectId == objectId);
            return result;
        }
    }
}
