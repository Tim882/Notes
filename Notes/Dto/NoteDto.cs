using System;
using DataBase.Models;
using System.ComponentModel.DataAnnotations;

namespace Notes.Dto
{
	public class NoteDto
	{
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<long> NoteTags { get; set; }

        public Note GetDbNote()
        {
            var note = new Note();
            note.Id = Id;
            note.Title = Title;
            note.Text = Text;

            return note;
        }
    }
}

