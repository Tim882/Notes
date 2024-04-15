using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
	public class DeleteReminderTagHandler : IRequestHandler<DeleteReminderTagCommand>
	{
        private readonly IRepository<ReminderTag> _repository;

		public DeleteReminderTagHandler(IRepository<ReminderTag> repository)
		{
            _repository = repository;
		}

        public async Task Handle(DeleteReminderTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}

