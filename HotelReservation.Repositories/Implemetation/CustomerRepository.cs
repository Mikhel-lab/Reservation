using Hangfire;
using HotelReservation.Domain.Configuration;
using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Interface;
using HotelReservation.Repositories.Requests;
using HotelReservation.Service.Services.EmailService;
using HotelReservation.Service.Services.HangFireService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Implemetation
{
	public class CustomerRepository : ICustomerRepository
	{
		//private readonly IDbClient _dbclient;
		private readonly IEmailSending sending;
		private readonly IMongoCollection<Customer> _customer;
		public CustomerRepository(IDbClient dbClient, IEmailSending emailSending)
		{
			_customer = dbClient.GetAllCustomerCollection();
			sending = emailSending;
		}
		public async Task<Customer> CreateAsync(CustomerRegistrationRequest request)
		{
			var customer = new Customer
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				IDNumber = request.IDNumber,
				Phone = request.Phone,
				ClientState = request.ClientState
			};
			  await _customer.InsertOneAsync(customer);
			 sending.SendEmailAsync(customer.Email, "Customer Registration Successful on Hotel Reservation", "Email sending", CancellationToken.None);
			
			return customer;
		}

		
	}
}
