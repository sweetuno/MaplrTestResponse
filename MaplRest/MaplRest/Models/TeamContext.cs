using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplRest.Models;

namespace MaplRest.Models
{
    public class TeamContext:DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Team> Team { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<MaplRest.Models.Player> Player { get; set; }
    }
}
