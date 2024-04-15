using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Queries;

namespace Notes.Handlers
{
    public class GetReminderByIdHandler: IRequestHandler<GetReminderByIdQuery, Reminder>
    {
        private readonly IRepository<Reminder> _repository;

        public GetReminderByIdHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<Reminder> Handle(GetReminderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ReadById(request.Id);
        }
    }
}

