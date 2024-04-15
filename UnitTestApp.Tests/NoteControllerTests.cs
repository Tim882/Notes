using DataBase.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Notes.Controllers;
using Notes.Dto;
using Notes.Queries;
using Xunit;

namespace UnitTestApp.Tests
{
    public class NoteControllerTests: IClassFixture<NoteFixture>
	{
		private readonly NoteFixture _fixture;

		public NoteControllerTests(NoteFixture fixture)
		{
			_fixture = fixture;
        }

        [Fact]
        public async Task GetNotes_CorrectRequest_SuccessfulResult()
        {
            // Arrange
            var noteController = new NoteController(_fixture.mediator.Object, _fixture.validator.Object);

            // Act
            var result = await noteController.GetNotes();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull((result as OkObjectResult)?.Value as IEnumerable<Note>);
            Assert.Equal(2, ((result as OkObjectResult)?.Value as IEnumerable<Note>)?.Count());
        }

        [Fact]
		public async Task GetNoteById_CorrectRequest_SuccessfulResult()
		{
			// Arrange
			const int id = 1;
			var noteController = new NoteController(_fixture.mediator.Object, _fixture.validator.Object);

			// Act
			var result = await noteController.GetNoteById(id);

			// Assert
			Assert.NotNull(result);
			Assert.IsType<OkObjectResult>(result);
			Assert.NotNull((result as OkObjectResult)?.Value as Note);
			Assert.Equal(id, ((result as OkObjectResult)?.Value as Note)?.Id);
		}

        [Fact]
        public async Task UpdateNote_ValidationError_BadREquestResult()
        {
            // Arrange
            var noteController = new NoteController(_fixture.mediator.Object, _fixture.validator.Object);

            // Act
            var result = await noteController.UpdateNote(_fixture.noteDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddNote_ValidationError_BadREquestResult()
        {
            // Arrange
            var noteController = new NoteController(_fixture.mediator.Object, _fixture.validator.Object);

            // Act
            var result = await noteController.AddNote(_fixture.noteDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateNote_CorrectRequest_SuccessfulResult()
        {
            // Arrange
            var noteController = new NoteController(_fixture.mediator.Object, _fixture.validator.Object);

            // Act
            var result = await noteController.UpdateNote(_fixture.correctNoteDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AddNote_CorrectRequest_SuccessfulResult()
        {
            // Arrange
            var noteController = new NoteController(_fixture.mediator.Object, _fixture.validator.Object);

            // Act
            var result = await noteController.AddNote(_fixture.correctNoteDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }
    }
}

