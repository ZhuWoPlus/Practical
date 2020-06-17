using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class Activity_DoTableModel
	 {
		 public int  Id { get; set; }
		 public int  Activity_Do_Activity_Id { get; set; }
		 public string  Activity_Do_Hospital { get; set; }
		 public int  Activity_Do_User_Id { get; set; }
		 public DateTime  Activity_Do_CreateTime { get; set; }
		 public DateTime  Activity_Do_EndTime { get; set; }
		 public bool  Activity_Do_State { get; set; }
		 public string  Activity_Message_Desc { get; set; }
		 public int  Activity_Do_Con_Id { get; set; }
		 public int  Activity_Do_Inviter_User_Id { get; set; }
		 public string  Activity_Do_Final { get; set; }
		 public string  Activity_Do_Picture { get; set; }
	 }
}
