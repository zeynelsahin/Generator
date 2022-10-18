using Generator.DataAccess.Abstract;
using Generator.DataAccess.EntityFramework;
using Generator.Entities;

namespace Generator.DataAccess.Concrete
{
    public class EfStringOptionDal:EfEntityRepositoryBase<StringOption, OracleContext>, IStringOptionDal
    {
    }
}