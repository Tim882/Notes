using System;
namespace DataBase.Models
{
	public class NoteTag: Tag
	{
		public long? NoteId { get; set; }
		public Note? Note { get; set; }
	}
}

