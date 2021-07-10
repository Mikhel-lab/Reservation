using HotelReservation.Repositories.Responses;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Interface
{
    public interface IDashboardRepository
    {
        Task<DataStatsResponse> DataStatsForDashboard();
    }
}
