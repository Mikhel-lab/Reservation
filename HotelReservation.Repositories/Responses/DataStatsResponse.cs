
namespace HotelReservation.Repositories.Responses
{
    public class DataStatsResponse
    {
        public long TotalRooms { get; set; }
        public int FreeRooms { get; set; } 
        public int Occupancy { get; set; }
        public decimal Revnue { get; set; }
        public int CheckIns { get; set; }
        public int CheckOuts { get; set; }
    }
}
