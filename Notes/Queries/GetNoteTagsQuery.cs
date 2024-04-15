using System;
using DataBase.Models;
using MediatR;

namespace Notes.Queries
{
	public record GetNoteTagsQuery: IRequest<IEnumerable<NoteTag>>;
}

