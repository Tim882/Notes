using System;
using DataBase.Models;
using MediatR;
using Notes.Dto;

namespace Notes.Commands
{
	public record UpdateReminderTagCommand(TagDto tag): IRequest;
}

