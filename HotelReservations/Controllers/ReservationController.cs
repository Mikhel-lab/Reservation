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
	public class ReservationController : ControllerBase
	{
		private readonly IReservationRepository _reservationRepository;
		public ReservationController(IReservationRepository reservationRepository)
		{
			_reservationRepository = reservationRepository;
		}

		[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
		[HttpPost("reservation")]
		public async Task<IActionResult> BookARoom([FromBody] ReservationRequest reservation)
		{
			if (reservation == null)
				return BadRequest();
			await Task.Run(() => _reservationRepository.BookOrReserve(reservation));
			return Ok(reservation);
		}
	}
}
