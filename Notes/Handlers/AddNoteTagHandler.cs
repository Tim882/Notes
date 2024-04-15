using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
	public class AddNoteTagHandler : IRequestHandler<AddNoteTagCommand>
	{
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<NoteTag> _tagRepository;

        public AddNoteTagHandler(
            IRepository<NoteTag> tagRepository,
            IRepository<Note> noteRepository)
		{
            _tagRepository = tagRepository;
            _noteRepository = noteRepository;
        }

        public async Task Handle(AddNoteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = request.tag.GetDbNoteTag();

            var note = await _noteRepository.ReadById(request.tag.ParentId);
            tag.Note = note;

            await _tagRepository.Create(tag);
        }
    }
}

