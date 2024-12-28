using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManager.Models.Database
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("UserName")]
        [Required]  // Not null
        public string UserName { get; set; }

        [Column("Password")]
        [Required]  // Not null
        public string Password { get; set; }

        [Column("FirstName")]
        [Required]  // Not null
        public string FirstName { get; set; }


        [Column("LastName")]
        [Required]  // Not null
        public string LastName { get; set; }

        [Column("EmployeeCode")]
        [Required]  // Not null
        public string EmployeeCode { get; set; }

        [Column("RoleId")]
        [Required]  // Not null
        public int RoleId { get; set; }

        [Column("TeamId")]
        [Required]  // Not null
        public int TeamId { get; set; }

        [Column("CreateAt")]
        [Required]  // Not null
        public DateTime CreateAt { get; set; }


        [Column("UpdateAt")]
        [Required]  // Not null
        public DateTime UpdateAt { get; set; }


        [Column("Status")]
        [Required]  // Not null
        public string Status { get; set; }


        [Column("Location")]
        [Required]  // Not null
        public string Location { get; set; }

        [Column("Phone")]
        [Required]  // Not null
        public string Phone { get; set; }


        [Column("Email")]
        [Required]  // Not null
        public string Email { get; set; }

        [Column("Address")]
        [Required]  // Not null
        public string Address { get; set; }

    }
}