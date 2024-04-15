using System;
using DataBase.Models;
using MediatR;
using Moq;
using FluentValidation;
using Xunit;
using Notes.Dto;
using Notes.Queries;
using Notes.Commands;
using System.ComponentModel.DataAnnotations;

namespace UnitTestApp.Tests
{
	public class NoteFixture: IClassFixture<NoteFixture>
	{
		public readonly Mock<IMediator> mediator;
        public readonly Mock<IValidator<NoteDto>> validator;
		public readonly IEnumerable<Note> notes;
        public readonly NoteDto noteDto;
        public readonly NoteDto correctNoteDto;

        public NoteFixture()
		{
            notes = new List<Note> {
                new Note
                {
                    Id = 1, NoteTags = new List<NoteTag>(), Text = "string", Title = "string",
                },
                new Note
                {
                    Id = 2, NoteTags = new List<NoteTag>(), Text = "string", Title = "string"
                }
            };
            correctNoteDto = new NoteDto();
            correctNoteDto.Id = 1;
            correctNoteDto.Text = "string";
            correctNoteDto.Title = "string";
            var correctValidationResult = new Mock<FluentValidation.Results.ValidationResult>();
            correctValidationResult.Setup(vr => vr.IsValid).Returns(true);
            noteDto = new NoteDto();
            var validationResult = new Mock<FluentValidation.Results.ValidationResult>();
            validationResult.Setup(vr => vr.IsValid).Returns(false);
            validator = new Mock<IValidator<NoteDto>>();
            validator.Setup(v => v.Validate(noteDto)).Returns(validationResult.Object);
            validator.Setup(v => v.Validate(correctNoteDto)).Returns(correctValidationResult.Object);
            mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(new GetNotesQuery(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(notes));
            mediator.Setup(m => m.Send(new GetNoteByIdQuery(1), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(notes.First()));
            mediator.Setup(m => m.Send(new AddNoteCommand(noteDto), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(false));
            mediator.Setup(m => m.Send(new UpdateNoteCommand(noteDto), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(false));
        }
    }
}

