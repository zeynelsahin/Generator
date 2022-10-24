using System.Collections.Generic;
using Generator.DataAccess.Abstract;
using Generator.DataAccess.EntityFramework;
using Generator.Entities;
using Oracle.ManagedDataAccess.Client;

namespace Generator.DataAccess.Concrete
{
    public class EfObjectEntityDal : EfEntityRepositoryBase<ObjectEntity, GeneratorContext>, IObjectEntityDal
    {
        public List<string> ColumnNames(string tableName)
        {
            var constr =
                "User Id=CMS_APP_USER;Password=Panda1881;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.59)(PORT=1521))(CONNECT_DATA=(SID=ORCLSRV19)))";
            var response = new List<string>();
            using var con = new OracleConnection(constr);
            con.Open();
            var sqlQuery = "SELECT column_name FROM all_tab_cols WHERE table_name = '" + tableName + "'";
            using (var com = new OracleCommand(sqlQuery, con))
            {
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read()) response.Add((string)reader["column_name"]);
                }
            }

            con.Close();
            return response;
        }

        public List<OracleColumn> ColumnNamesAndType(string tableName)
        {
            var constr =
                "User Id=CMS_APP_USER;Password=Panda1881;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.59)(PORT=1521))(CONNECT_DATA=(SID=ORCLSRV19)))";
            var response = new List<OracleColumn>();
            using var con = new OracleConnection(constr);
            con.Open();
            var sqlQuery = "SELECT column_name,data_type FROM all_tab_cols WHERE table_name = '" + tableName + "'";
            using (var com = new OracleCommand(sqlQuery, con))
            {
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read())
                        response.Add(new OracleColumn
                            { Name = (string)reader["column_name"], DataType = (string)reader["data_type"] });
                }
            }

            con.Close();
            return response;
        }
    }
}