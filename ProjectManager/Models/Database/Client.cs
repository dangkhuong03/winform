using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Database
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [Column("ClientId")]
        public int ClientId { get; set; }

        [Column("ClientName")]
        [Required]  // Not null
        public string ClientName { get; set; }

        [Column("Phone")]
        [Required]  // Not null
        public int Phone { get; set; }

        [Column("Fax")]
        [Required]  // Not null
        public string Fax { get; set; }

        [Column("Email")]
        [Required]  // Not null
        public string Email { get; set; }

        [Column("Address1")]
        [Required]  // Not null
        public string Address1 { get; set; }

        [Column("Address2")]
        [Required]  // Not null
        public string Address2 { get; set; }
        
        [Column("Contact")]
        [Required]  // Not null
        public string Contact { get; set; }

    }
}