using NUnit.Framework;
using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.IDAL
{
    public interface IActivityDal
    {
        /// <summary>
        /// 显示查询活动列表
        /// 
        /// </summary>
        /// <returns>通过</returns>
        List<Activity_DoTableModel> Show(string name);
    }
}
