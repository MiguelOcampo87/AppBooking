﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sygno.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Sygno.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Sygno.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerbyId;
using Sygno.Booking.Application.DataBase.User.Commands.DeleteUser;
using Sygno.Booking.Application.Exceptions;
using Sygno.Booking.Application.Features;

namespace Sygno.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
	[TypeFilter(typeof(ExceptionManager))]
	public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomerCommand,
			[FromServices] IValidator<CreateCustomerModel> validator) 
        {
			var validate = await validator.ValidateAsync(model);

			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await createCustomerCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateCustomerCommand,
			[FromServices] IValidator<UpdateCustomerModel> validator)
        {
			var validate = await validator.ValidateAsync(model);

			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await updateCustomerCommand.Execute(model);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
		}

		[HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
            [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteUserCommand.Execute(customerId);
            if(!data)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK));
		}

		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll([FromServices] IGetAllCustomerQuery getAllCustomerQuery)
		{
			var data = await getAllCustomerQuery.Execute();

			if (data.Count == 0)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

		}

		[HttpGet("get-by-id/{customerId}")]
		public async Task<IActionResult> GetById(
			int customerId,
			[FromServices] IGetCustomerbyIdQuery getCustomerByIdQuery)
		{
			if (customerId == 0)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			var data = await getCustomerByIdQuery.Execute(customerId);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
		}
		[HttpGet("get-by-documentNumber/{documentNumber}")]
		public async Task<IActionResult> GetByDocumentNumber(
			string documentNumber,
			[FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery)
		{
			if (string.IsNullOrEmpty(documentNumber))
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);
			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));


		}
	}
}
