using HotelReservation.Models.Entities;
using HotelReservation.Models.Enums;
using HotelReservation.Repositories.Interface;
using HotelReservation.Repositories.Responses;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Implemetation
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IMongoCollection<Room> _room;
        private readonly IMongoCollection<Customer> _customer;
        public DashboardRepository(IDbClient dbClient)
        {
            _room = dbClient.GetAllRoomCollection();
            _customer = dbClient.GetAllCustomerCollection();
        }

        public async Task<DataStatsResponse> DataStatsForDashboard()
        {
            return await Task.Run(()
                => new DataStatsResponse
                {
                    TotalRooms = TotalRooms(),
                    Revnue = Revnue(),
                    Occupancy = Occupancy(),
                    FreeRooms = FreeRooms(),
                    CheckIns = CheckIns(),
                    CheckOuts = CheckOuts()
                });
        }

        private int CheckIns()
        {
            var total = _customer.Find(c => c.ClientState.Equals(ClientState.CheckIn))
                .ToList().Count();
            return total;
        }

        private int CheckOuts()
        {
            var total = _customer.Find(c => c.ClientState.Equals(ClientState.CheckOut))
                .ToList().Count();
            return total;
        }

        private int FreeRooms()
        {
            var total = _room.Find(f => f.RoomState.Equals(RoomState.Free))
                .ToList().Count();
            return total;
        }

        private int Occupancy()
        {
            var total = _room.Find(f => f.RoomState.Equals(RoomState.Occupied))
                .ToList().Count();
            return total;
        }

        private decimal Revnue()
        {
            var aggr = _room.Aggregate().Single();
            return aggr.Price;
        }

        private long TotalRooms()
        {
            var total = _room.Find(book => true).ToList().Count();
            return total;
        }
    }
}
