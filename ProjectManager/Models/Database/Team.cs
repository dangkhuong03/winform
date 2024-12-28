using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Database
{
    [Table("team")]
    public class Team
    {
        [Key]
        [Column("TeamId")]
        public int TeamId { get; set; }

        [Column("TeamName")]
        [Required]  
        public string TeamName { get; set; }

    }
}