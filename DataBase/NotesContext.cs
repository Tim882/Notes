using System;
using System.Security.Principal;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
	public class NotesContext: DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<ReminderTag> ReminderTags { get; set; }

        public NotesContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

