using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IServiceMethodService
    {
        ServiceMethod GetByObjectId(string objectId, string profileId, string classType = null);
        void Add(ServiceMethod serviceMethod);
        void Delete(ServiceMethod serviceMethod);
    }
}