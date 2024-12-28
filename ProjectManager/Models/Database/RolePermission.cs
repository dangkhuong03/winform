using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("role_permission")]
    public class RolePermission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }  // Primary Key

        [Column("UserId")]
        [Required]
        public int UserId { get; set; }  // Not null

        [Column("PermissionId")]
        [Required]
        public int PermissionId { get; set; }  // Not null
    }
}