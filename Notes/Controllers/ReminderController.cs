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

namespace Reminders.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<ReminderDto> _validator;

        public ReminderController(IMediator mediator, IValidator<ReminderDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("/reminders")]
        public async Task<IActionResult> GetReminders()
        {
            try
            {
                var reminders = await _mediator.Send(new GetRemindersQuery());
                return Ok(reminders);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet("/reminder")]
        public async Task<IActionResult> GetReminderById(long Id)
        {
            try
            {
                var reminder = await _mediator.Send(new GetReminderByIdQuery(Id));
                return Ok(reminder);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/reminder/add")]
        public async Task<IActionResult> AddReminder([FromBody] ReminderDto reminder)
        {
            try
            {
                var validationResult = _validator.Validate(reminder);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new AddReminderCommand(reminder));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            
        }

        [HttpPut("/reminder/update")]
        public async Task<IActionResult> UpdateReminder([FromBody] ReminderDto reminder)
        {
            try
            {
                var validationResult = _validator.Validate(reminder);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                await _mediator.Send(new UpdateReminderCommand(reminder));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/reminder/delete")]
        public async Task<IActionResult> DeleteReminder(long Id)
        {
            try
            {
                await _mediator.Send(new DeleteReminderCommand(Id));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

