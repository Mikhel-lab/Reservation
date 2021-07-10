using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Interface;
using HotelReservation.Repositories.Requests;
using HotelReservation.Repositories.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotelReservations.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerRepository _customer;
		public CustomerController(ICustomerRepository customer)
		{
			_customer = customer;
		}

		[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
		[HttpPost("register")]
		public async Task<IActionResult> CustomerRegistration([FromBody] CustomerRegistrationRequest customer)
		{
			if (customer == null)
				return BadRequest();
			await Task.Run(() => _customer.CreateAsync(customer));
			return Ok(customer);
		}

	}
}
