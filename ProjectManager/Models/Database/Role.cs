using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }  // Primary Key

        [Column("Name")]
        [Required]
        public string Name { get; set; }  // Not null
    }
}