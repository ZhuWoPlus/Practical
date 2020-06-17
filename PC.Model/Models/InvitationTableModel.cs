using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class InvitationTableModel
	 {
		 public int  Id { get; set; }
		 public int  Inviter_User_Id { get; set; }
		 public int  Invitee_Medic_Id { get; set; }
		 public int  Invitation_State { get; set; }
		 public DateTime  Invitation_CreateTime { get; set; }
		 public DateTime  Invitation_UpdateTime { get; set; }
	 }
}
