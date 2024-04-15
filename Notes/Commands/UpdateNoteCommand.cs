using System;
using DataBase.Models;
using MediatR;
using Notes.Dto;

namespace Notes.Commands
{
	public record UpdateNoteCommand(NoteDto note): IRequest;
}

