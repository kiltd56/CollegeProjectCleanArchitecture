﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.ApiRoutingData;
using System.Net;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {

        private readonly IValidator<AddStudentCommand> _addvalidator;
        private readonly IValidator<EditStudentCommand> _editvalidator;
        public StudentController(IValidator<AddStudentCommand> Addvalidator, IValidator<EditStudentCommand> Editvalidator)
        {
            _addvalidator = Addvalidator;
            _editvalidator = Editvalidator;
        }
        [HttpGet(Routes.StudentRouting.List)]
        public async Task<IActionResult> GetStudentsList()
        {
            var response = await _mediator.Send(new GetStudentsListQuery());
            return NewResult(response);
        }

        [HttpGet(Routes.StudentRouting.Paginated)]
        public async Task<IActionResult> GetPaginatedStudentsList([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Routes.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Routes.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            var validation = await _addvalidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var errorMessages = validation.Errors.Select(error => error.ErrorMessage);
                var errorresponse = new ErrorValidationResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = errorMessages,
                };
                return BadRequest(errorresponse);
            }
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Routes.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var validation = await _editvalidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var errorMessages = validation.Errors.Select(error => error.ErrorMessage);
                var errorresponse = new ErrorValidationResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = errorMessages,
                };
                return BadRequest(errorresponse);
            }
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Routes.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }

    }
}
