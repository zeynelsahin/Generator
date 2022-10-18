using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IServiceOptionService
    {
        List<string> GetServiceId();
        List<ServiceOption> GetAll();
    }
}