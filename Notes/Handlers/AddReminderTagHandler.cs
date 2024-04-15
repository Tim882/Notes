using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
	public class AddReminderTagHandler : IRequestHandler<AddReminderTagCommand>
	{
        private readonly IRepository<Reminder> _noteRepository;
        private readonly IRepository<ReminderTag> _tagRepository;

        public AddReminderTagHandler(
            IRepository<ReminderTag> tagRepository,
            IRepository<Reminder> noteRepository)
		{
            _tagRepository = tagRepository;
            _noteRepository = noteRepository;
        }

        public async Task Handle(AddReminderTagCommand request, CancellationToken cancellationToken)
        {
            var tag = request.tag.GetDbReminderTag();

            var note = await _noteRepository.ReadById(request.tag.ParentId);
            tag.Reminder = note;

            await _tagRepository.Create(tag);
        }
    }
}

