using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetNoteByIdQuery(long Id): IRequest<Note>;
}

