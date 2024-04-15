using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetReminderTagsQuery: IRequest<IEnumerable<ReminderTag>>;
}

