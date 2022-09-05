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

        public List<ObjectResult> GetAllByObjectId(string objectId, string profileId)
        {
            var result = _objectResultDal.GetAll(p => p.ObjectId == objectId && p.ProfileId == profileId);
            return result;
        }

        public List<string> GetResultIdByObjectId(string objectId, string profileId)
        {
            var result = _objectResultDal.GetAll(p => p.ObjectId == objectId && profileId == p.ProfileId).Select(p => p.ResultId).ToList();
            return result;
        }

        public List<OracleColumn> GetAll(string objectId, string profileId)
        {
            var list = new List<OracleColumn>();
            var result = _objectResultDal.GetAll(p => p.ObjectId == objectId && profileId == p.ProfileId).ToList();
            result.ForEach(p =>
            {
                list.Add(new OracleColumn { DataType = p.DataType, Name = p.ResultId });
            });
            return list;
        }
    }
}