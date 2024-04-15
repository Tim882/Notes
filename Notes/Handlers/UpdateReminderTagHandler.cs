using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
	public class UpdateReminderTagHandler : IRequestHandler<UpdateReminderTagCommand>
	{
        private readonly IRepository<Reminder> _reminderRepository;
        private readonly IRepository<ReminderTag> _tagRepository;

        public UpdateReminderTagHandler(
            IRepository<ReminderTag> tagRepository,
            IRepository<Reminder> reminderRepository)
        {
            _tagRepository = tagRepository;
            _reminderRepository = reminderRepository;
        }

        public async Task Handle(UpdateReminderTagCommand request, CancellationToken cancellationToken)
        {
            var tag = request.tag.GetDbReminderTag();

            var reminder = await _reminderRepository.ReadById(request.tag.ParentId);
            tag.Reminder = reminder;

            await _tagRepository.Update(tag);
        }
    }
}

