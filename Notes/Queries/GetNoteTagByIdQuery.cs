using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetNoteTagByIdQuery(long Id): IRequest<NoteTag>;
}

