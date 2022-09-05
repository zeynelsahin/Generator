using System;
using System.Collections.Generic;
using System.Text;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IServiceMethodService
    {
        ServiceMethod GetByObjectId(string objectId, string profileId);
    }
}