using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MaplRest.Models
{
    [Table("Player")]
    public class Player
    {
        /// <summary>
        /// Player's ID in DataBase
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="integer")]
        public int Number { get; set; }
        /// <summary>
        /// Player's Name on team
        /// </summary>
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        /// <summary>
        /// Player's Last Name on team
        /// </summary>
        [Column(TypeName ="nvarchar(250)")]
        public string LastName { get; set; }

        /// <summary>
        /// Player's Position on team
        /// </summary>
        [Column(TypeName = "nvarchar(250)")]
        public string Position { get; set; }

        /// <summary>
        /// Player's Year in team
        /// </summary>
        [Column(TypeName = "bit")]
        public bool IsCaptain { get; set; }

        /// <summary>
        /// Foreign Key for Table Team in DataBase
        /// </summary>
        [Column(TypeName ="integer")]
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }


    }
}
