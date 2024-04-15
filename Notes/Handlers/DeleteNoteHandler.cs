using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly IRepository<Note> _repository;

        public DeleteNoteHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}

