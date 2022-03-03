using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaplRest.Models;

namespace MaplRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Updating player by setting captain
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/Player/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Captain/")]
        public async Task<IActionResult> PutPlayer(int id)
        {
            // Find player data by id 
            var player = await _context.Player.FindAsync(id);

            // Check existing player
            if (id != player.Id)
            {
                return BadRequest();
            }

            // Setting captain
            player.IsCaptain = true;

            // Saving changes
            _context.Entry(player).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
