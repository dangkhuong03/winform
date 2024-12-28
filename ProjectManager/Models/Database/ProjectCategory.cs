using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("project_category")]
    public class ProjectCategory
    {
        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }  // Primary Key

        [Column("CategoryName")]
        [Required]
        public string CategoryName { get; set; }  // Not null
    }
}