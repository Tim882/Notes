using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
    public class GetNoteTagsHandler : IRequestHandler<GetNoteTagsQuery, IEnumerable<NoteTag>>
    {
        private readonly IRepository<NoteTag> _repository;

        public GetNoteTagsHandler(IRepository<NoteTag> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NoteTag>> Handle(GetNoteTagsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ReadAll();
        }
    }
}

