using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace PC.Common.Helpers
{
    public class DapperHelper<T>
    {
        public List<T> Query(string sql)
        {
            using(SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-F38H79UL\LI;Initial Catalog=Practial;Integrated Security=True"))
            {
                List<T> list = con.Query<T>(sql).ToList();
                return list;
            }
        }
        public int Execute(string sql)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-F38H79UL\LI;Initial Catalog=Practial;Integrated Security=True"))
            {
                int res = con.Execute(sql);
                return res;
            }
        }
    }
}
