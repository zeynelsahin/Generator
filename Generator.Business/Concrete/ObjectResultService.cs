using System;
using System.Collections.Generic;
using System.Text;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;
using System.Linq;

namespace Generator.Business.Concrete
{
    public class ObjectResultService : IObjectResultService
    {
        private readonly IObjectResultDal _objectResultDal;

        public ObjectResultService(IObjectResultDal objectResultDal)
        {
            _objectResultDal = objectResultDal;
        }
        public void Add(ObjectResult entity)
        {
            _objectResultDal.Add(entity);
        }

        public void Delete(ObjectResult entity)
        {
            _objectResultDal.Delete(entity);
        }

        public void Update(ObjectResult entity)
        {
            _objectResultDal.Update(entity);
        }

        public void AddRange(IEnumerable<ObjectResult> entities)
        {
            _objectResultDal.AddRange(entities);
        }

        public void DeleteRange(IEnumerable<ObjectResult> entities)
        {
            _objectResultDal.DeleteRange(entities);
        }

        public void UpdateRange(IEnumerable<ObjectResult> entities)
        {
            _objectResultDal.UpdateRange(entities);
        }

        public string FindParameterType(string parameterName)
        {
            var result = _objectResultDal.GetAll().LastOrDefault(s => s.ResultId == parameterName);
            return result != null ? result.DataType : null;
        }

        public List<ObjectResult> GetAllByObjectId(string objectId)
        {
            var result= _objectResultDal.GetAll(p=>p.ObjectId==objectId);
            return result;
        }
    }
}
