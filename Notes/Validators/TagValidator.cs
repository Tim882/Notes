using System;
using DataBase.Models;
using FluentValidation;
using Notes.Dto;

namespace Notes.Validators
{
	public class TagValidator: AbstractValidator<TagDto>
	{
		public TagValidator()
		{
			RuleFor(t => t.Id).GreaterThan(0);
			RuleFor(t => t.Name).NotEmpty();
		}
	}
}

