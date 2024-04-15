using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetNotesQuery: IRequest<IEnumerable<Note>>;
}

