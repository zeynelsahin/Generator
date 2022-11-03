using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IPageOptionService
    {
        void Add(PageOption pageOption);
        PageOption Get(string domainId, string environment,string applicationId,string pageId);
    }
}