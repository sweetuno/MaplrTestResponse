using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplRest.Models;

namespace MaplRest.Models
{
    public class PlayerContext:DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public PlayerContext(DbContextOptions<PlayerContext> options):base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Player> Player { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<MaplRest.Models.Team> Team { get; set; }
    }
}
