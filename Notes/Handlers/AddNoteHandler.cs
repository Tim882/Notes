using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
    public class AddNoteHandler : IRequestHandler<AddNoteCommand>
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<NoteTag> _tagRepository;

        public AddNoteHandler(IRepository<Note> noteRepository, IRepository<NoteTag> tagRepository)
        {
            _noteRepository = noteRepository;
            _tagRepository = tagRepository;
        }

        public async Task Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var note = request.note.GetDbNote();

            var tags = await _tagRepository.ReadAll();
            var noteTags = tags.Where(t => request.note.NoteTags.Contains(t.Id)).ToList();
            noteTags = noteTags;
            //note.NoteTags = (ICollection<NoteTag>)noteTags;

            await _noteRepository.Create(note);
        }
    }
}

