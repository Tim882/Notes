using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
    public class GetReminderTagsHandler : IRequestHandler<GetReminderTagsQuery, IEnumerable<ReminderTag>>
    {
        private readonly IRepository<ReminderTag> _repository;

        public GetReminderTagsHandler(IRepository<ReminderTag> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReminderTag>> Handle(GetReminderTagsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ReadAll();
        }
    }
}

