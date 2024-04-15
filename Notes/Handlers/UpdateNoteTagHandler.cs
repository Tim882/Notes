using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
	public class UpdateNoteTagHandler : IRequestHandler<UpdateNoteTagCommand>
	{
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<NoteTag> _tagRepository;

        public UpdateNoteTagHandler(
            IRepository<NoteTag> tagRepository,
            IRepository<Note> noteRepository)
        {
            _tagRepository = tagRepository;
            _noteRepository = noteRepository;
        }

        public async Task Handle(UpdateNoteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = request.tag.GetDbNoteTag();

            var Note = await _noteRepository.ReadById(request.tag.ParentId);
            tag.Note = Note;

            await _tagRepository.Update(tag);
        }
    }
}

