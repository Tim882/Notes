using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
	public class GetNoteTagByIdHandler : IRequestHandler<GetNoteTagByIdQuery, NoteTag>
    {
		private readonly IRepository<NoteTag> _repository;

		public GetNoteTagByIdHandler(IRepository<NoteTag> repository)
		{
			_repository = repository;
		}

		public async Task<NoteTag> Handle(GetNoteTagByIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.ReadById(request.Id);
		}
	}
}

