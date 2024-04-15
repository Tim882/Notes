using System;
using DataBase.Models;
using MediatR;

namespace Notes.Commands
{
	public record DeleteNoteCommand(long Id): IRequest;
}

