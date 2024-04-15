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
    public class NoteTagController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TagDto> _validator;

        public NoteTagController(IMediator mediator, IValidator<TagDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("/notetags")]
        public async Task<IActionResult> GetTagse()
        {
            try
            {
                var tags = await _mediator.Send(new GetNoteTagsQuery());
                return Ok(tags);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/notetag")]
        public async Task<IActionResult> GetTagById(long Id)
        {
            try
            {
                var tag = await _mediator.Send(new GetNoteTagByIdQuery(Id));
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/notetag/add")]
        public async Task<IActionResult> AddTag([FromBody] TagDto tag)
        {
            try
            {
                var validationResult = _validator.Validate(tag);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new AddNoteTagCommand(tag));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/notetag/update")]
        public async Task<IActionResult> UpdateTag([FromBody] TagDto tag)
        {
            try
            {
                var validationResult = _validator.Validate(tag);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new UpdateNoteTagCommand(tag));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/notetag/delete")]
        public async Task<IActionResult> DeleteTag(long Id)
        {
            try
            {
                await _mediator.Send(new DeleteNoteTagCommand(Id));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
    }
}

