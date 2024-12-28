using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        [Column("CommentId")]
        public int CommentId { get; set; }  // Primary Key

        [Column("Content")]
        [Required]
        public string Content { get; set; }  // Not null

        [Column("CreateAt")]
        [Required]
        public DateTime CreateAt { get; set; }  // Not null, default to CURRENT_TIMESTAMP

        [Column("UpdateAt")]
        [Required]
        public DateTime UpdateAt { get; set; }  // Not null, default to CURRENT_TIMESTAMP
    }
}