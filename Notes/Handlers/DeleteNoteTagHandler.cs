using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
	public class DeleteNoteTagHandler : IRequestHandler<DeleteNoteTagCommand>
	{
        private readonly IRepository<NoteTag> _repository;

		public DeleteNoteTagHandler(IRepository<NoteTag> repository)
		{
            _repository = repository;
		}

        public async Task Handle(DeleteNoteTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}

