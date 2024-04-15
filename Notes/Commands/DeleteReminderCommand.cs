using System;
using DataBase.Models;
using MediatR;

namespace Notes.Commands
{
	public record DeleteReminderCommand(long Id): IRequest;
}

