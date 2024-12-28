using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectManager.Models.Database
{
    [Table("project")]
    public class Project
    {
        [Key]
        [Column("ProjectId")]
        public string ProjectId { get; set; }  // Project ID

        [Column("ProjectName")]
        [Required]  // Not null
        public string ProjectName { get; set; }  // Project Name

        [Column("CategoryId")]
        [Required]  // Not null
        public int CategoryId { get; set; }  // Category ID

        [Column("ClientId")]
        [Required]  // Not null
        public int ClientId { get; set; }  // Client ID

        [Column("Starred")]
        [Required]  // Not null
        public int Starred { get; set; }  // Starred (0 for false, 1 for true)

        [Column("IssueType")]
        [Required]  // Not null
        [DefaultValue("project")]  // Default value
        public string IssueType { get; set; } = "project";  // Issue Type

        [Column("TeamId")]
        [Required]  // Not null
        public int TeamId { get; set; }  // Team ID

        [Column("Priority")]
        [Required]  // Not null
        public string Priority { get; set; }  // Priority

        [Column("StartDate")]
        [Required]  // Not null
        public DateTime StartDate { get; set; }  // Start Date

        [Column("POReceiveDate")]
        [Required]  // Not null
        public DateTime POReceiveDate { get; set; }  // PO Receive Date

        [Column("DeliveryDate")]
        [Required]  // Not null
        public DateTime DeliveryDate { get; set; }  // Delivery Date

        [Column("DueDate")]
        [Required]  // Not null
        public DateTime DueDate { get; set; }  // Due Date

        [Column("FinishDate")]
        [Required]  // Not null
        public DateTime FinishDate { get; set; }  // Finish Date

        [Column("Stage")]
        [Required]  // Not null
        public string Stage { get; set; }  // Stage

        [Column("Status")]
        [Required]  // Not null
        public string Status { get; set; }  // Status

        [Column("Label")]
        [Required]  // Not null
        public string Label { get; set; }  // Label

        [Column("ReportId")]
        [Required]  // Not null
        public int ReportId { get; set; }  // Report ID

        [Column("Description")]
        [Required]  // Not null
        public string Description { get; set; }  // Description

        [Column("CreateAt")]
        [Required]  // Not null
        public DateTime CreateAt { get; set; }  // Created At

        [Column("UpdateAt")]
        [Required]  // Not null
        public DateTime UpdateAt { get; set; }  // Updated At

        [Column("ParentId")]
        [Required]  // Not null
        public int ParentId { get; set; }  // Parent ID

        [Column("Project_type")]
        [Required]  
        public int Project_type { get; set; }  
    }
}