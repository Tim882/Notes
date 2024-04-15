using System;
using DataBase.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Notes.Dto
{
	public class TagDto
	{
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }

        public NoteTag GetDbNoteTag()
        {
            var tag = new NoteTag();
            tag.Id = ParentId;
            tag.Name = Name;

            return tag;
        }

        public ReminderTag GetDbReminderTag()
        {
            var tag = new ReminderTag();
            tag.Id = ParentId;
            tag.Name = Name;

            return tag;
        }
    }
}

