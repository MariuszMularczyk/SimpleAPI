using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpGet]
        public async Task<ActionResult<List<TripList>>> GetAllTrips()
        {
            return await _tripService.GetAllTrips();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var result = await _tripService.GetTrip(id);
            if (result is null)
                return NotFound("Trip not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<TripList>>> AddTrip(Trip hero)
        {
            var result = await _tripService.AddTrip(hero);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult<List<TripList>>> UpdateTrip(Trip request)
        {
            var result = await _tripService.UpdateTrip(request);
            if (result is null)
                return NotFound("Trip not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TripList>>> DeleteHero(int id)
        {
            var result = await _tripService.DeleteTrip(id);
            if (result is null)
                return NotFound("Trip not found.");

            return Ok(result);
        }
        [HttpPost("tripRegister")]
        public async Task<ActionResult> TripRegister(TripMailVM model)
        {
            _tripService.TripRegister(model);
            return Ok();
        }
        [HttpPost("tripUnregister")]
        public async Task<ActionResult> TripUnregister(TripMailVM model)
        {
            _tripService.TripUnregister(model);
            return Ok();
        }
    }
}
