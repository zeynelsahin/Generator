using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IObjectResultService
    {
        void Add(ObjectResult entity);
        void Delete(ObjectResult entity);
        void Update(ObjectResult entity);

        void AddRange(IEnumerable<ObjectResult> entities);
        void DeleteRange(IEnumerable<ObjectResult> entities);

        void UpdateRange(IEnumerable<ObjectResult> entities);

        string FindResultType(string resultId);

        List<ObjectResult> GetAllByObjectId(string objectId, string profileId);
        List<string> GetResultIdByObjectId(string objectId, string profileId);
        List<OracleColumn> GetAll(string objectId, string profileId);

        ObjectResult FindResult(string resultId);
    }
}