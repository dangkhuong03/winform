using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("project_comment")]
    public class ProjectComment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }  // Primary Key

        [Column("CommentId")]
        [Required]
        public int CommentId { get; set; }  // Not null

        [Column("ProjectId")]
        [Required]
        public int ProjectId { get; set; }  // Not null

        [Column("UserId")]
        [Required]
        public int UserId { get; set; }  // Not null
    }
}