using System;
namespace DataBase.Models
{
	public class ReminderTag: Tag
    {
		public long? ReminderId { get; set; }
		public Reminder? Reminder { get; set; }
	}
}

