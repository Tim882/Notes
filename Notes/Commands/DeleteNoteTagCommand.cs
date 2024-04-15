using System;
using DataBase.Models;
using MediatR;

namespace Notes.Commands
{
	public record DeleteNoteTagCommand(long Id): IRequest;
}

