using System.Collections.Generic;
using Generator.DataAccess.Abstract;
using Generator.DataAccess.EntitiyFramework;
using Generator.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Generator.DataAccess.Concrete
{
    public class EfObjectEntityDal : EfEntityRepositoryBase<ObjectEntity, GeneratorContext>, IObjectEntityDal
    {
        public List<string> ColumnNames(string tableName)
        {
            string constr = "User Id=CMS_APP_USER;Password=Panda1881;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.59)(PORT=1521))(CONNECT_DATA=(SID=ORCLSRV19)))";
            List<string> response = new List<string>();
            using OracleConnection con = new OracleConnection(constr);
            con.Open();
            string sqlQuery = "SELECT column_name FROM all_tab_cols WHERE table_name = '" + tableName + "'";
            using (OracleCommand com = new OracleCommand(sqlQuery, con))
            {
                using (OracleDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        response.Add((string)reader["column_name"]);
                    }
                }
            }

            con.Close();
            return response;
        }
    }
}