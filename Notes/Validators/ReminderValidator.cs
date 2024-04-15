using System;
using DataBase.Models;
using FluentValidation;
using Notes.Dto;

namespace Notes.Validators
{
	public class ReminderValidator: AbstractValidator<ReminderDto>
	{
		public ReminderValidator()
		{
			RuleFor(r => r.Id).GreaterThan(0);
			RuleFor(r => r.Title).NotEmpty();
		}
	}
}

