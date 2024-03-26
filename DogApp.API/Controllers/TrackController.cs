using DogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackController : Controller
    {
        private readonly ITrackService? _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService ?? throw new ArgumentNullException(nameof(trackService));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task CreateTask(Track track)
        {

            // Call the service method to create the task
            if (track == null)
            {
                throw new ArgumentNullException(nameof(track));
            }
            await _trackService.CreateTrack(track);
           

        }
    }
}
