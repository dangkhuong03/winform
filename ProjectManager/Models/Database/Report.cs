using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models.Database
{
    [Table("report")]
    public class Report
    {
        [Key]
        [Column("ReportId")]
        public int ReportId { get; set; }  // Primary Key

        [Column("Path")]
        [Required]
        public string Path { get; set; }  // Not null
    }
}