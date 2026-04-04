using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VagaBondAPI.Data;
using VagaBondAPI.DTOs;
using VagaBondAPI.Exceptions;
using VagaBondAPI.Models;
using VagaBondAPI.Service;

namespace VagaBondAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController( IDestinationService service)
        {
            _service = service;
        }

        // GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {
            try
            {
                var x = await _service.GetAllAsync();
                return Ok(x);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Destinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            try
            {
                var x = await _service.GetByIdAsync(id);
                return x;
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT: api/Destinations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, UpdateDestinationDto updateDestinationDto)
        {
            try
            {
                var x = await _service.UpdateAsync(id,updateDestinationDto);
                return Ok(x);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Destinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(CreateDestinationDto createDestinationDto)
        {
            try
            {
                 await _service.AddAsync(createDestinationDto);
                return Ok("Destination created successfully");
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                var destination = await _service.DeleteAsync(id);
                return Ok(destination);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
