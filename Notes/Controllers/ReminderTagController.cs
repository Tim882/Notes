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
    public class ReminderTagController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TagDto> _validator;

        public ReminderTagController(IMediator mediator, IValidator<TagDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("/tags")]
        public async Task<IActionResult> GetTagse()
        {
            try
            {
                var tags = await _mediator.Send(new GetReminderTagsQuery());
                return Ok(tags);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/tag")]
        public async Task<IActionResult> GetTagById(long Id)
        {
            try
            {
                var tag = await _mediator.Send(new GetReminderTagByIdQuery(Id));
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/tag/add")]
        public async Task<IActionResult> AddTag([FromBody] TagDto tag)
        {
            try
            {
                var validationResult = _validator.Validate(tag);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new AddReminderTagCommand(tag));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/tag/update")]
        public async Task<IActionResult> UpdateTag([FromBody] TagDto tag)
        {
            try
            {
                var validationResult = _validator.Validate(tag);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new UpdateReminderTagCommand(tag));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/tag/delete")]
        public async Task<IActionResult> DeleteTag(long Id)
        {
            try
            {
                await _mediator.Send(new DeleteReminderTagCommand(Id));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
    }
}

