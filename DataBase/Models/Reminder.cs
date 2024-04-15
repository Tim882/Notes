using System;
using System.ComponentModel.DataAnnotations;
using DataBase.Interfaces;

namespace DataBase.Models
{
	public class Reminder: IBaseDbModel
    {
		[Key]
		public long Id { get; set; }
		public string Title { get; set; }
		public DateTime NotifyDateTime { get; set; }
		public List<ReminderTag> ReminderTags { get; set; }
	}
}

