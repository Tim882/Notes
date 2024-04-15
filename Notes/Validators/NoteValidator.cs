using System;
using DataBase.Models;
using FluentValidation;
using Notes.Dto;

namespace Notes.Validators
{
	public class NoteValidator: AbstractValidator<NoteDto>
	{
		public NoteValidator()
		{
			RuleFor(n => n.Id).GreaterThan(0);
			RuleFor(n => n.Title).NotEmpty();
			RuleFor(n => n.Text).NotEmpty();
		}
	}
}

