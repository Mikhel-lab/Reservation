using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Requests;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Interface
{
	public interface ICustomerRepository 
	{
		Task<Customer> CreateAsync(CustomerRegistrationRequest request);
	}
}
