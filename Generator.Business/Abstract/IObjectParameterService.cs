using System;
using System.Collections.Generic;
using System.Text;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IObjectParameterService
    {
        void Add(ObjectParameter objectEntity);
        List<string> GetAllByObjectId(string objectId, string profileId);
        string FindParameterType(string parameterName);
        List<OracleColumn> GetAll(string objectId, string profileId);
    }
}