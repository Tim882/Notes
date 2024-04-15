using System;
using DataBase.Models;
using MediatR;
using Notes.Dto;

namespace Notes.Commands
{
	public record AddReminderCommand(ReminderDto reminder): IRequest;
}

