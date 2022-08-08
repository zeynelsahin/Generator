
using Generator.DataAccess.Abstract;
using Generator.DataAccess.EntitiyFramework;
using Generator.Entities;

namespace Generator.DataAccess.Concrete
{
    public class EfObjectEntityDal: EfEntityRepositoryBase<ObjectEntity,GeneratorContext>,IObjectEntityDal
    {
    }
}
