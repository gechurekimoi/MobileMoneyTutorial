using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileMoneyTutorial.Models;

namespace MobileMoneyTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiConfirmationResponsesController : ControllerBase
    {
        private readonly TestDbContext _context;

        public ApiConfirmationResponsesController(TestDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiConfirmationResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfirmationResponse>>> GetConfirmationResponses()
        {
            return await _context.ConfirmationResponses.ToListAsync();
        }

        // GET: api/ApiConfirmationResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfirmationResponse>> GetConfirmationResponse(int id)
        {
            var confirmationResponse = await _context.ConfirmationResponses.FindAsync(id);

            if (confirmationResponse == null)
            {
                return NotFound();
            }

            return confirmationResponse;
        }

        // PUT: api/ApiConfirmationResponses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfirmationResponse(int id, ConfirmationResponse confirmationResponse)
        {
            if (id != confirmationResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(confirmationResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfirmationResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiConfirmationResponses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConfirmationResponse>> PostConfirmationResponse(ConfirmationResponse confirmationResponse)
        {
            _context.ConfirmationResponses.Add(confirmationResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfirmationResponse", new { id = confirmationResponse.Id }, confirmationResponse);
        }

        // DELETE: api/ApiConfirmationResponses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfirmationResponse>> DeleteConfirmationResponse(int id)
        {
            var confirmationResponse = await _context.ConfirmationResponses.FindAsync(id);
            if (confirmationResponse == null)
            {
                return NotFound();
            }

            _context.ConfirmationResponses.Remove(confirmationResponse);
            await _context.SaveChangesAsync();

            return confirmationResponse;
        }

        private bool ConfirmationResponseExists(int id)
        {
            return _context.ConfirmationResponses.Any(e => e.Id == id);
        }
    }
}
