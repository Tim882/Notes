using System;
using DataBase.Models;
using MediatR;
using Notes.Dto;

namespace Notes.Commands
{
	public record AddReminderTagCommand(TagDto tag): IRequest;
}

