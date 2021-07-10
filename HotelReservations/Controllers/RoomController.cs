using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Interface;
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
	public class RoomController : ControllerBase
	{
		private readonly IRoomRepository _room;
		public RoomController(IRoomRepository room)
		{
			_room = room;
		}

		[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
		[HttpPost("room")]
		public async Task<IActionResult> RoomChecking([FromBody] Room room)
		{
			if (room == null)
				return BadRequest();
			await Task.Run(() => _room.CreateAsync(room));
			return Ok(room);
		}
	}
}
