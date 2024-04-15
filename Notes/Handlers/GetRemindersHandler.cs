using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
    public class GetRemindersHandler : IRequestHandler<GetRemindersQuery, IEnumerable<Reminder>>
    {
        private readonly IRepository<Reminder> _repository;

        public GetRemindersHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Reminder>> Handle(GetRemindersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ReadAll();
        }
    }
}

