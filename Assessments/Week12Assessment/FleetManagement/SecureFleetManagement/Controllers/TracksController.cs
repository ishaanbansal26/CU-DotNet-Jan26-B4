using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingService.Data;
using TrackingService.Dtos;
using TrackingService.Models;
using TrackingService.Services;

namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TracksController : ControllerBase
    {
        private readonly TrackingServiceContext _context;
        private readonly ITrackService _service;

        public TracksController(TrackingServiceContext context, ITrackService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTrack()
        {
            var x = await _service.GetAll();
            return Ok(x);
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            try
            {
                var track = await _service.GetById(id);
                return Ok(track);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        // PUT: api/Tracks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, UpdateTrackDto updateTrackDto)
        {
            try
            {
                await _service.Update(id, updateTrackDto);
                return Ok($"Truck Updated {id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        }

        // POST: api/Tracks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(CreateTrackDto createTrackDto)
        {
            try
            {
                var truck = await _service.Create(createTrackDto);
                return CreatedAtAction("GetTrack", new { id = truck.Id }, truck);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            try
            {
                await _service.Remove(id);
                return Ok($"{id} deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

    }
}
