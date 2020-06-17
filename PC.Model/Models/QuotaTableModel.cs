using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class QuotaTableModel
	 {
		 public int  Id { get; set; }
		 public int  QRelation_UserId { get; set; }
		 public int  QRelation_ConferenceId { get; set; }
		 public int  QRelation_Number { get; set; }
		 public string  QRelation_Desc { get; set; }
	 }
}
