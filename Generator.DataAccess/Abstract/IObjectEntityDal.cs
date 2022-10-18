using System.Collections.Generic;
using Generator.DataAccess.EntityFramework;
using Generator.Entities;

namespace Generator.DataAccess.Abstract
{
    public interface IObjectEntityDal : IEntityRepository<ObjectEntity>
    {
        List<string> ColumnNames(string tableName);
        List<OracleColumn> ColumnNamesAndType(string tableName);
    }
}