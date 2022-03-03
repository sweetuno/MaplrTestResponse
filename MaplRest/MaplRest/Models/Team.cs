using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MaplRest.Models
{
    [Table("Team")]
    public class Team
    {
        /// <summary>
        /// Primary Key For Database (Auto Increment ID)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the coach
        /// </summary>
        [Column(TypeName = "nvarchar(250)")]
        public string Coach { get; set; }

        /// <summary>
        /// Year of team
        /// </summary>
        [Column(TypeName = "integer")]
        public int Year { get; set; }

        /// <summary>
        /// Adding Player for foreign key in DataBase
        /// </summary>
        public ICollection<Player> Players { get; set; }
    }
}
