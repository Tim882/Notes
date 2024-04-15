using System;
using DataBase.Interfaces;
using DataBase.Models;
using MediatR;
using Notes.Commands;

namespace Notes.Handlers
{
    public class AddReminderHandler : IRequestHandler<AddReminderCommand>
    {
        private readonly IRepository<ReminderTag> _tagRepository;
        private readonly IRepository<Reminder> _remindersRepository;

        public AddReminderHandler(IRepository<Reminder> remindersRepository, IRepository<ReminderTag> tagRepository)
        {
            _remindersRepository = remindersRepository;
            _tagRepository = tagRepository;
        }

        public async Task Handle(AddReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = request.reminder.GetDbReminder();

            var tags = await _tagRepository.ReadAll();
            var reminderTags = tags.Where(t => request.reminder.ReminderTags.Contains(t.Id)).ToList();
            reminder.ReminderTags = reminderTags;
            //reminder.ReminderTags = (ICollection<ReminderTag>)reminderTags;

            await _remindersRepository.Create(reminder);
        }
    }
}

