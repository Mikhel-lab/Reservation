using HotelReservation.Repositories.Interface;
using HotelReservation.Repositories.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace HotelReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository dashboard;

        public DashboardController(IDashboardRepository dashboard)
        {
            this.dashboard = dashboard;
        }

        [ProducesResponseType(typeof(DataStatsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DataStatsResponse), (int)HttpStatusCode.InternalServerError)]
        [HttpGet("stats")]
        public async Task<IActionResult> GetDataStats()
            => Ok(await Task.Run(() => dashboard.DataStatsForDashboard()));
    }
}
