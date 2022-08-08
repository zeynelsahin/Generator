using System;
using System.Collections.Generic;
using System.Linq;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class ObjectEntityService: IObjectEntityService
    {
        private readonly IObjectEntityDal _objectEntityDal;

        public ObjectEntityService(IObjectEntityDal objectEntityDal)
        {
            _objectEntityDal = objectEntityDal;
        }

        public void Add(ObjectEntity objectEntity)
        {
            _objectEntityDal.Add(objectEntity);
        }

        public List<ObjectEntity> GetByObjectId(string objectId, string profileId = null,string schemaName=null)
        {
            List<ObjectEntity> result;
            if (profileId!=null)
            {
                if (schemaName!=null)
                {
                    result = _objectEntityDal.GetAll(entity => entity.ObjectId == objectId && entity.ProfileId == profileId && entity.SchemaName == schemaName);
                    return result;
                }
                result = _objectEntityDal.GetAll(entity => entity.ObjectId == objectId && entity.ProfileId == profileId);
                return result;
            }

            if (schemaName!=null)
            {
                result = _objectEntityDal.GetAll(entity => entity.ObjectId == objectId  && entity.SchemaName == schemaName);
                return result;
            }
        
            result = _objectEntityDal.GetAll(entity => entity.ObjectId == objectId);
            return result;

        }

        public List<string> GetAllObjectId()
        {
            var result = _objectEntityDal.GetAll().Select(entity => entity.ObjectId).Distinct().ToList();
            return result;
        }

        public List<ObjectEntity> GetByObjectIdContains(string objectId)
        {
            var result = _objectEntityDal.GetAll().Where(entity => entity.ObjectId.Contains(objectId)).ToList();
            return result;
        }

        public List<string> GetAllProfileId()
        {
            var result = _objectEntityDal.GetAll().Select(entity => entity.ProfileId).Distinct().ToList();
            return result;
        }

        public List<string> GetAllSchemaName()
        {
            var result = _objectEntityDal.GetAll().Select(entity => entity.SchemaName).Distinct().ToList();
            return result;
        }

        public string GetOracleTextBy(string objectId, string profileId, string schemaName)
        {
            var result = _objectEntityDal.Get(entity =>
                entity.ObjectId == objectId);

            return result.OracleText;

        }
    }
}
