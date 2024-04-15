using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
    public class GetNoteByIdHandler: IRequestHandler<GetNoteByIdQuery, Note>
    {
        private readonly IRepository<Note> _repository;

        public GetNoteByIdHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ReadById(request.Id);
        }
    }
}

