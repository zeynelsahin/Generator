using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IObjectParameterService
    {
        void Add(ObjectParameter objectEntity);
        List<string> GetAllByObjectId(string objectId, string profileId);
        string FindParameterType(string parameterName);
        List<OracleColumn> GetAll(string objectId, string profileId);
        ObjectParameter FindParameter(string parameterName);
        List<ObjectParameter> GetAllObjectParameter(string objectId, string profileId);
        void Delete(ObjectParameter objectParameter);
    }
}