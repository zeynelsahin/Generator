using System;
using System.Collections.Generic;
using System.Text;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IObjectParameterService
    {
      void Add(ObjectParameter objectEntity);
      List<ObjectParameter> GetAllByObjectId(string objectId);
        string FindParameterType(string parameterName);
    }
}
