using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("permission")]
    public class Permission
    {
        [Key]
        [Column("PermissionId")]
        public int PermissionId { get; set; }  // Primary Key

        [Column("PermissionName")]
        [Required]
        public string PermissionName { get; set; }  // Not null

        [Column("Description")]
        [Required]
        public string Description { get; set; }  // Not null

        [Column("CreateAt")]
        [Required]
        public DateTime CreateAt { get; set; }  // Not null

        [Column("UpdateAt")]
        [Required]
        public DateTime UpdateAt { get; set; }  // Not null
    }
}