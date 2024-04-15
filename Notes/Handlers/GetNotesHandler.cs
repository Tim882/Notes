using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
	public class GetNotesHandler: IRequestHandler<GetNotesQuery, IEnumerable<Note>>
	{
        private readonly IRepository<Note> _repository;

		public GetNotesHandler(IRepository<Note> repository)
		{
            _repository = repository;
		}

        public async Task<IEnumerable<Note>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ReadAll();
        }
    }
}

