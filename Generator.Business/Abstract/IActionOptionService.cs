using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IActionOptionService
    {
        void Add(ActionOption actionOption);
        List<ActionOption> GetAll(string domainId, string environment, string applicationId, string actionId);
        ActionOption Get(string domainId, string environment, string applicationId, string actionId);
    }
}