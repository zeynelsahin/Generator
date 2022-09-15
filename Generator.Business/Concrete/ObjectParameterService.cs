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
            var result = _objectParameterDal.GetAll().LastOrDefault(p => p.ParameterId == parameterName);
            return result != null ? result.DataType : null;
        }

        public List<OracleColumn> GetAll(string objectId, string profileId)
        {
            var result = _objectParameterDal.GetAll(p => p.ObjectId == objectId && p.ProfileId == profileId).ToList();
            var oracleColumn = result.Select(parameter => new OracleColumn() { DataType = parameter.DataType, Name = parameter.ParameterId }).ToList();
            return oracleColumn;
        }

        public List<string> GetAllByObjectId(string objectId, string profileId)
        {
            var result = _objectParameterDal.GetAll(p => p.ObjectId == objectId && p.ProfileId == profileId).Select(p => p.ParameterId).ToList();
            return result;
        }
        public ObjectParameter FindParameter(string parameterName)
        {
            var result = _objectParameterDal.GetAll().LastOrDefault(p => p.ParameterId == parameterName);
            return result ?? new ObjectParameter();
        }

        public List<ObjectParameter> GetAllObjectParameter(string objectId, string profileId)
        {
            var result = _objectParameterDal.GetAll(p => p.ObjectId == objectId && p.ProfileId == profileId).ToList();
            return result;
        }

        public void Delete(ObjectParameter objectParameter)
        {
            _objectParameterDal.Delete(objectParameter);
        }
    }
}