using HotelReservation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Interface
{
	public interface IRoomRepository
	{
		Task<Room> CreateAsync(Room room);
	}
}
