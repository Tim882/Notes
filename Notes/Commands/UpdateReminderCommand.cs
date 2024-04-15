using System;
using DataBase.Models;
using MediatR;
using Notes.Dto;

namespace Notes.Commands
{
	public record UpdateReminderCommand(ReminderDto reminder): IRequest;
}

