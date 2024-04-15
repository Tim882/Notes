using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
	public class GetReminderTagByIdHandler : IRequestHandler<GetReminderTagByIdQuery, ReminderTag>
    {
		private readonly IRepository<ReminderTag> _repository;

		public GetReminderTagByIdHandler(IRepository<ReminderTag> repository)
		{
			_repository = repository;
		}

		public async Task<ReminderTag> Handle(GetReminderTagByIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.ReadById(request.Id);
		}
	}
}

