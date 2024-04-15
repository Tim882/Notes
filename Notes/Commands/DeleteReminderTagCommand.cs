using System;
using DataBase.Models;
using MediatR;

namespace Notes.Commands
{
	public record DeleteReminderTagCommand(long Id): IRequest;
}

