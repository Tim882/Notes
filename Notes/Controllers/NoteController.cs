using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Commands;
using Notes.Dto;
using Notes.Queries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.Controllers
{
    public class NoteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<NoteDto> _validator;

        public NoteController(IMediator mediator, IValidator<NoteDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("/notes")]
        public async Task<IActionResult> GetNotes()
        {
            try
            {
                var notes = await _mediator.Send(new GetNotesQuery());
                return Ok(notes);
            } catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/note")]
        public async Task<IActionResult> GetNoteById(long Id)
        {
            try
            {
                var note = await _mediator.Send(new GetNoteByIdQuery(Id));
                return Ok(note);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/note/add")]
        public async Task<IActionResult> AddNote([FromBody] NoteDto note)
        {
            try
            {
                var validationResult = _validator.Validate(note);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new AddNoteCommand(note));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/note/update")]
        public async Task<IActionResult> UpdateNote([FromBody] NoteDto note)
        {
            try
            {
                var validationResult = _validator.Validate(note);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new UpdateNoteCommand(note));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/note/delete")]
        public async Task<IActionResult> DeleteNote(long Id)
        {
            try
            {
                await _mediator.Send(new DeleteNoteCommand(Id));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            
        }
    }
}

