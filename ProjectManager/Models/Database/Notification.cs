using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("notification")]
    public class Notification
    {
        [Key]
        [Column("NotificationId")]
        public int NotificationId { get; set; }  // Primary Key

        [Column("UserId")]
        [Required]
        public int UserId { get; set; }  // Not null

        [Column("Message")]
        [Required]
        public string Message { get; set; }  // Not null

        [Column("Type")]
        [Required]
        public string Type { get; set; }  // Not null

        [Column("IsRead")]
        [Required]
        public bool IsRead { get; set; }  // 0 for false, 1 for true

        [Column("CreateAt")]
        [Required]
        public DateTime CreateAt { get; set; }  // Not null
    }
}