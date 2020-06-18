using Dapper;
using PC.IDAL;
using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PC.DAL
{
    public class ActivityDal : IActivityDal
    {
        /// <summary>
        /// 显示查询活动列表
        /// </summary>
        /// <returns></returns>
        public List<Activity_DoTableModel> Show(string name)
        {
            using (SqlConnection connection = new SqlConnection("Data Source = 192.168.43.93; Initial Catalog = Practial; User ID = sa; Pwd = 12345"))
            {
                throw new NotImplementedException();
            }
        }

       
    }
}
