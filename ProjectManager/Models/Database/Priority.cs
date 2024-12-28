using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectManager.Models.Database
{
    [Table("Priority")]
    public class Priority
    {
        [Key]
        [Column("ID")]
        public string ID { get; set; }  

        [Column("Priority_Level")]
        [Required]  // Not null
        public string Priority_Level { get; set; }  

       
    }
}