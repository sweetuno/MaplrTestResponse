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
    public class TeamController : ControllerBase
    {
        private readonly TeamContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TeamController(TeamContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Find Team by year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns></returns>
        // GET: api/Team/5
        [HttpGet("{year}")]
        public ActionResult<Team> GetTeam(int year)
        {

            // Récupération des context
            var team = _context.Team.Where(t => t.Year == year).FirstOrDefault();
            var players = _context.Player.Where(p => p.TeamId == team.Id).ToList();

            // Association des deux objets
            team.Players = players;

            if (team == null)
            {
                return NotFound();
            }
            else
            {
                return team;
            }
        }

        // POST: api/Team
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{year}")]
        public async Task<ActionResult<Player>> PostTeam(Player player, int year)
        {
            // Get Context Team
            var team = _context.Team.Where(t => t.Year == year).FirstOrDefault();

            // Set teamId in player object
            player.TeamId = team.Id;

            // Add player to context
            _context.Player.Add(player);

            // Save changes
            await _context.SaveChangesAsync();

            // Return 
            if (player == null)
            {
                return NotFound();
            }
            return player;
        }
    }
}
