using System;
using DataBase.Models;

namespace Notes.Dto
{
	public class ReminderDto
	{
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime NotifyDateTime { get; set; }
        public List<long> ReminderTags { get; set; }

        public Reminder GetDbReminder()
        {
            var reminder = new Reminder();

            reminder.Id = Id;
            reminder.Title = Title;
            reminder.NotifyDateTime = NotifyDateTime;

            return reminder;
        }
    }
}

