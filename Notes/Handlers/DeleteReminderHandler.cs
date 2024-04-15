using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
    public class DeleteReminderHandler : IRequestHandler<DeleteReminderCommand>
    {
        private readonly IRepository<Reminder> _repository;

        public DeleteReminderHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}

