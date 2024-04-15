using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetRemindersQuery: IRequest<IEnumerable<Reminder>>;
}

