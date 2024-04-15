using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetReminderTagByIdQuery(long Id): IRequest<ReminderTag>;
}

