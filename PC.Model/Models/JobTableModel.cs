using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class JobTableModel
	 {
		 public int  Id { get; set; }
		 public string  Job_Name { get; set; }
		 public string  Job_Desc { get; set; }
		 public int  Job_State { get; set; }
		 public DateTime  Job_AddTime { get; set; }
		 public int  Job_PermissionId { get; set; }
		 public int  Job_DelState { get; set; }
	 }
}
