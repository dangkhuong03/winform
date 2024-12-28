using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Database
{
    [Table("Issue_type")]
    public class Issue_type
    {
      
        
            [Key]
            [Column("type_id")]
            public int TYPE_ID { get; set; }

            [Column("issue_type")]
            [Required]  // Not null
            public string ISSUE_TYPE { get; set; }

            [Column("description")]
            [Required]  // Not null
            public string DESCRIPTION { get; set; }

        
    }
}