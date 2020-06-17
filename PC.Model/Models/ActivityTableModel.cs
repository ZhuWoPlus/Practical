using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class ActivityTableModel
	 {
		 public int  Id { get; set; }
		 public int  ActivityType_Id { get; set; }
		 public string  Activity_Name { get; set; }
		 public string  Activity_Desc { get; set; }
		 public string  Activity_Data { get; set; }
		 public int  Activity_Product_Id { get; set; }
		 public int  Acticity_Department_Id { get; set; }
		 public int  Activity_DelState { get; set; }
	 }
}
