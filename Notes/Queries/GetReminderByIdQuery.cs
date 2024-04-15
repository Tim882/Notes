using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetReminderByIdQuery(long Id): IRequest<Reminder>;
}

