using System;
using System.ComponentModel.DataAnnotations;
using DataBase.Interfaces;

namespace DataBase.Models
{
	public class Note: IBaseDbModel
    {
		[Key]
		public long Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public List<NoteTag> NoteTags { get; set; }
	}
}

