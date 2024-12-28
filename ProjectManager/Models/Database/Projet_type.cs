using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Database
{
    [Table("Projet_type")]
    public class Projet_type
    {


        [Key]
        [Column("type_id")]
        public int TYPE_ID { get; set; }

        [Column("Project_type")]
        [Required]  // Not null
        public string PROJECT_TYPE { get; set; }

        [Column("Type_description")]
        [Required]  // Not null
        public string TYPE_DESCRIPTION { get; set; }


    }
}